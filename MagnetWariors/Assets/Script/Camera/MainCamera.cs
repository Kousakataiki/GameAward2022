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

    [SerializeField, Range(0.01f, 0.9f)] float MoveSpeed;   // 移動速度
    [SerializeField] float StartAnimSec;
    [SerializeField] float GoalAnimSec;

    [SerializeField] float FocusDistanceMargin;
    GameObject Player;
    Volume volume;
    DepthOfField dof;

    Vector3 TargetPos;  // 目標座標
    bool isMoving;      // 移動中フラグ

    float cnt;
    Vector3 StartPos;

    void Start()
    {
        volume = transform.Find("Global Volume").GetComponent<Volume>();
        volume.profile.TryGet<DepthOfField>(out dof);

        //----- 一番近いエリアを開始エリアに指定 -----
        // オブジェクトを取得
        Player = GameObject.FindWithTag("Player");
        GameObject[] areas = GameObject.FindGameObjectsWithTag("Area");

        // オブジェクトの距離を比較
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

        // 開始エリアを設定
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
                    // 目標の座標に向けて移動
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
                    // 目標の座標に向けて移動
                    transform.position = Vector3.Lerp(transform.position, TargetPos, MoveSpeed);

                    // 距離が一定以下になったら移動を終わる
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
                    // 目標の座標に向けて移動
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

    //===== 目標座標を設定 =====
    public void SetTargetPos(Vector3 _pos)
    {
        TargetPos = _pos;
        isMoving = true;
    }
}
