using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartAnim : MonoBehaviour
{
    [SerializeField] Vector3 TargetPos;     // 目標位置
    [SerializeField] float MoveSpeed;       // 移動速度
    Vector3 StartPos;   // 開始位置

    [SerializeField] Quaternion TargetRot;  // 回転角度
    [SerializeField] float RotateSpeed;     // 回転速度
    Quaternion StartRot;    // 開始角度


    [SerializeField] bool isPlaying;  // 再生判定
    [SerializeField] bool isMoving;   // 移動判定
    [SerializeField] bool isRotating; // 旋回判定

    float AnimCnt;  // 開始アニメーション用カウンタ

    Rigidbody rb;
    Collider col;


    private void OnDrawGizmos()
    {
        if (!isPlaying)
        {
            //----- 移動先の表示 -----
            CapsuleCollider capsule = GetComponent<CapsuleCollider>();
            Vector3 center = transform.position + TargetPos;
            center.y += capsule.height / 2f;
            Gizmos.color = new Color(1, 0, 0, 1);
            Gizmos.DrawWireCube(center, new Vector3(capsule.radius * 2, capsule.height, capsule.radius * 2));

            //----- 回転角度の表示 -----
            Gizmos.color = new Color(0, 0, 1, 1);
            Gizmos.DrawLine(center, center + TargetRot * Vector3.forward);
        }
    }

    void Start()
    {
        //===== 変数の初期化 =====
        StartPos = transform.position;
        isPlaying = false;
        isMoving = false;
        isRotating = false;
        AnimCnt = 0f;

        // 移動方向を向く
        transform.LookAt(StartPos + TargetPos);
        StartRot = transform.rotation;

        // 物理演算オフ
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    void Update()
    {
        if (!isPlaying) return;

        //----- 移動 -----
        if(isMoving)
        {
            AnimCnt = Mathf.Min(1f, AnimCnt + MoveSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(StartPos, StartPos + TargetPos, AnimCnt);
            if (AnimCnt >= 1.0f)
            {
                AnimCnt = 0f;
                isMoving = false;
                isRotating = true;

                // 扉を閉める
                GameObject.FindWithTag("StartPos").GetComponentInChildren<Door>().Close();
                // カメラを動かす
                GameObject.FindWithTag("MainCamera").GetComponent<MainCamera>().PlayStartAnim();
            }
        }

        //----- 回転 -----
        else if(isRotating)
        {
            AnimCnt = Mathf.Min(1f, AnimCnt + RotateSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(StartRot, TargetRot, AnimCnt);
            if(AnimCnt >= 1.0f)
            {
                AnimCnt = 0f;
                isRotating = false;
                isPlaying = false;

                //----- ステージ開始処理 -----
                rb.useGravity = true;
                col.enabled = true;
                GetComponent<Player>().enabled = true;
                Destroy(this);
            }
        }
    }

    
    public void Play()
    {
        isPlaying = true;
        isMoving = true;
        AnimCnt = 0f;
    }
}
