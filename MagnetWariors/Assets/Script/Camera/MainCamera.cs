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

    [SerializeField, Range(0.01f, 0.9f)] float MoveSpeed;   // 移動速度
    [SerializeField] float StartAnimSec;

    Vector3 TargetPos;  // 目標座標
    bool isMoving;      // 移動中フラグ

    float cnt;
    Vector3 startpos;

    void Start()
    {
        //----- 一番近いエリアを開始エリアに指定 -----
        // オブジェクトを取得
        GameObject player = GameObject.FindWithTag("Player");
        GameObject[] areas = GameObject.FindGameObjectsWithTag("Area");

        // オブジェクトの距離を比較
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

        // 開始エリアを設定
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
                    // 目標の座標に向けて移動
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

    //===== 目標座標を設定 =====
    public void SetTargetPos(Vector3 _pos)
    {
        TargetPos = _pos;
        isMoving = true;
    }
}
