using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MainCamera : MonoBehaviour
{
    public enum CAMERA_MODE
    {
        StartAnim,
        Game,
        GoalAnim,
    }

    CAMERA_MODE Mode;

    [SerializeField, Range(0.01f, 0.9f)] float MoveSpeed;   // �ړ����x
    [SerializeField] float StartAnimSec;
    [SerializeField] float GoalAnimSec;

    [SerializeField] float FocusDistanceMargin;
    GameObject Player;
    Volume volume;
    DepthOfField dof;

    Vector3 TargetPos;  // �ڕW���W
    bool isMoving;      // �ړ����t���O

    float cnt;
    Vector3 StartPos;

    void Start()
    {
        volume = transform.Find("Global Volume").GetComponent<Volume>();
        volume.profile.TryGet<DepthOfField>(out dof);

        //----- ��ԋ߂��G���A���J�n�G���A�Ɏw�� -----
        // �I�u�W�F�N�g���擾
        Player = GameObject.FindWithTag("Player");
        GameObject[] areas = GameObject.FindGameObjectsWithTag("Area");

        // �I�u�W�F�N�g�̋������r
        GameObject startArea = null;
        float minDis = 9999f;
        foreach(GameObject area in areas)
        {
            float dis = Vector3.Distance(Player.transform.position, area.transform.position);
            if(minDis > dis)
            {
                minDis = dis;
                startArea = area;
            }
        }

        // �J�n�G���A��ݒ�
        SetTargetPos(startArea.GetComponent<StageArea>().CameraPos);


        StartPos = transform.position;
        cnt = 0f;
        isMoving = false;
    }


    void Update()
    {
        switch(Mode)
        {
            case CAMERA_MODE.StartAnim:
                if(isMoving)
                {
                    // �ڕW�̍��W�Ɍ����Ĉړ�
                    cnt = Mathf.Min(1f, cnt + (1 / StartAnimSec) * Time.deltaTime);
                    transform.position = Vector3.Lerp(StartPos, TargetPos, cnt);

                    if(cnt >= 1f)
                    {
                        SetCameraMode(CAMERA_MODE.Game);
                        isMoving = false;
                    }
                }
                break;

            case CAMERA_MODE.Game:

                if (isMoving)
                {
                    // �ڕW�̍��W�Ɍ����Ĉړ�
                    transform.position = Vector3.Lerp(transform.position, TargetPos, MoveSpeed);

                    // ���������ȉ��ɂȂ�����ړ����I���
                    if (Vector3.Distance(transform.position, TargetPos) < 0.01f)
                    {
                        transform.position = TargetPos;
                        isMoving = false;
                    }
                }

                break;

            case CAMERA_MODE.GoalAnim:

                if(isMoving)
                {
                    // �ڕW�̍��W�Ɍ����Ĉړ�
                    cnt = Mathf.Min(1f, cnt + (1 / GoalAnimSec) * Time.deltaTime);
                    transform.position = Vector3.Lerp(StartPos, TargetPos, cnt);

                    if (cnt >= 1f)
                    {
                        isMoving = false;
                    }
                }

                break;
        }

        dof.focusDistance.value = Vector3.Distance(transform.position, Player.transform.position) + FocusDistanceMargin;
    }


    public void SetCameraMode(CAMERA_MODE mode)
    {
        Mode = mode;
        StartPos = transform.position;
        isMoving = false;
    }


    public void PlayStartAnim()
    {
        if(Mode == CAMERA_MODE.StartAnim)
        {
            cnt = 0f;
            isMoving = true;
        }
    }

    public void PlayGoalAnim()
    {
        if (Mode == CAMERA_MODE.GoalAnim)
        {
            cnt = 0f;
            isMoving = true;
        }
    }

    //===== �ڕW���W��ݒ� =====
    public void SetTargetPos(Vector3 _pos)
    {
        TargetPos = _pos;
        isMoving = true;
    }
}
