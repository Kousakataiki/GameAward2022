using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public enum CAMERA_MODE
    {
        StartAnim,
        Game,
    }

    public CAMERA_MODE Mode { get; set; }

    [SerializeField, Range(0.01f, 0.9f)] float MoveSpeed;   // �ړ����x
    [SerializeField] float StartAnimSec;

    Vector3 TargetPos;  // �ڕW���W
    bool isMoving;      // �ړ����t���O

    float cnt;
    Vector3 startpos;

    void Start()
    {
        //----- ��ԋ߂��G���A���J�n�G���A�Ɏw�� -----
        // �I�u�W�F�N�g���擾
        GameObject player = GameObject.FindWithTag("Player");
        GameObject[] areas = GameObject.FindGameObjectsWithTag("Area");

        // �I�u�W�F�N�g�̋������r
        GameObject startArea = null;
        float minDis = 9999f;
        foreach(GameObject area in areas)
        {
            float dis = Vector3.Distance(player.transform.position, area.transform.position);
            if(minDis > dis)
            {
                minDis = dis;
                startArea = area;
            }
        }

        // �J�n�G���A��ݒ�
        SetTargetPos(startArea.GetComponent<StageArea>().CameraPos);


        startpos = transform.position;
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
                    transform.position = Vector3.Lerp(startpos, TargetPos, cnt);

                    if(cnt == 1f)
                    {
                        Mode = CAMERA_MODE.Game;
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
        }
    }

    public void PlayStartAnim()
    {
        if(Mode == CAMERA_MODE.StartAnim)
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
