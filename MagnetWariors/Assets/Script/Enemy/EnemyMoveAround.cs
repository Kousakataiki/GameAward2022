using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAround : MagnetType
{
    public enum Dir
    {
        L = 0,
        R,
        MAX_DIR
    }

    // リジッドボディ
    Rigidbody rb;

    // 敵パラメータ
    [SerializeField] public float fSpd;
    [SerializeField] public float fSmooth;
    public Vector3 vDir = Vector3.zero;
    private Quaternion Rot;
    // フラグ
    private bool bN = false;    
    private bool bS = false;
    public Dir dir;
    //GameObject goParent;



    // Start is called before the first frame update
    void Start()
    {
        // 親コンポーネント取得
        //goParent = transform.parent.gameObject;
        //rb = goParent.GetComponent<Rigidbody>();
        
        // コンポーネント取得
        rb = GetComponent<Rigidbody>();

        // 向いている方向初期化
        dir = Dir.L;
    }

    // Update is called once per frame
    void Update()
    {
        // 反転デバッグ
        if(Controller.GetKeyTrigger(Controller.ControllerButton.Y))
        {
            dir++;
            if(dir > Dir.R)
            {
                dir = Dir.L;
            }
        }
        /*
          地面が無かったり、障害物に触れるとキャラクターが反転する。
          但し、プレイヤーに触れた場合は反転しない。
          N極の磁力、S極の磁力のどちらかを帯びている。
          N極ならS極の状態のプレイヤーに触れるとやられる。
          S極ならN極の状態のプレイヤーに触れるとやられる。
          プレイヤーが飛ばしたオブジェクトに触れると死亡する
          帯びている磁力がプレイヤーのものと同じ場合、互いに反発する。
          このとき、プレイヤー側が敵から少し押し返される。
         */

        switch(dir)
        {
            // 左を向いている
            case Dir.L:
                vDir.z = -1.0f;
                //vDir.x = -1.0f;
                Rot = Quaternion.LookRotation(vDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            // 右を向いている
            case Dir.R:
                vDir.z = 1.0f;
                //vDir.x = 1.0f;
                Rot = Quaternion.LookRotation(vDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            default:
                break;
        }
        rb.velocity = new Vector3((rb.velocity.x + vDir.z) * fSpd, rb.velocity.y, rb.velocity.z);
        //rb.velocity = new Vector3((rb.velocity.x + vDir.x) * fSpd, rb.velocity.y, rb.velocity.z);
    }

    // 反転
    private void OnTriggerEnter(Collider other)
    {
        // タグ「反転壁」に触れた
        if(other.gameObject.tag == "ReverseWall")
        {
            // 敵反転
            dir++;
            if (dir > Dir.R)
            {
                dir = Dir.L;
            }
        }
    }
}
