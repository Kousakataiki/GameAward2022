using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAround : MagnetType
{
    // 向いている方向
    public enum Dir
    {
        Left = 0,
        Right,
        Up,
        Down,
        MAX_DIR
    }

    // リジッドボディ
    Rigidbody rb;
    // 敵パラメータ
    [SerializeField] public float fSpd;
    [SerializeField] public float fSmooth;
    private Vector3 vDir = Vector3.zero;
    private Quaternion Rot;
    public Dir dir;


    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得
        rb = GetComponent<Rigidbody>();

        // 向いている方向を初期化
        //if (this.gameObject.tag == "FloatEnemyVertical")
        //    dir = Dir.Down;
        //else
        //    dir = Dir.Left;

    }

    // Update is called once per frame
    void Update()
    {
        // 反転デバッグ操作
        if(Controller.GetKeyTrigger(Controller.ControllerButton.Y))
        {
            dir++;
            if(dir > Dir.Right)
            {
                dir = Dir.Left;
            }
        }

        // アタッチされているオブジェクトのタグで処理を変更する
        // 敵の移動
        if(this.gameObject.tag == "Enemy")
        {
            EnemyMove();
        }

        // 浮いている「縦」移動の敵
        else if(this.gameObject.tag == "FloatEnemyVertical")
        {
            VerticalMove();
        }

        // 浮いている「横」移動の敵
        else if (this.gameObject.tag == "FloatEnemyHorizontal")
        {
            HorizontalMove();
        }
    }

    private void EnemyMove()
    {
        // 向いている方向によって処理を変更する
        switch (dir)
        {
            // 左を向いている
            case Dir.Left:
                vDir.z = -1.0f;
                Rot = Quaternion.LookRotation(vDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            // 右を向いている
            case Dir.Right:
                vDir.z = 1.0f;
                Rot = Quaternion.LookRotation(vDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            default:
                break;
        }
        // 左右移動
        rb.velocity = new Vector3((rb.velocity.x + vDir.z) * fSpd, rb.velocity.y, rb.velocity.z);
    }

    private void HorizontalMove()
    {
        // 向いている方向によって処理を変更する
        switch (dir)
        {
            // 左を向いている
            case Dir.Left:
                vDir.x = -1.0f;
                Rot = Quaternion.LookRotation(vDir);
                // 回転
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            // 右を向いている
            case Dir.Right:
                vDir.x = 1.0f;
                Rot = Quaternion.LookRotation(vDir);
                // 回転
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            default:
                break;
        }
        // 左右移動
        rb.velocity = new Vector3((rb.velocity.x + vDir.x) * fSpd, rb.velocity.y, rb.velocity.z);
    }

    private void VerticalMove()
    {
        // 正面に固定
        gameObject.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);

        // Dirの状態によって処理を切り替え
        switch (dir)
        {
            // 上
            case Dir.Up:
                vDir.y = 1.0f;
                break;

            // 下
            case Dir.Down:
                vDir.y = -1.0f;
                break;

            default:
                break;
        }

        // 上下移動
        rb.velocity = new Vector3(rb.velocity.x, (rb.velocity.y + vDir.y) * fSpd, rb.velocity.z);
    }

    // 反転処理
    private void OnTriggerEnter(Collider other)
    {
        // タグ「反転壁」に触れた
        if(other.gameObject.tag == "ReverseWall")
        {
            // 敵反転
            if(this.gameObject.tag == "FloatEnemyVertical")
            {
                dir++;
                if (dir > Dir.Down)
                    dir = Dir.Up;
            }
            else
            {
                dir++;
                if (dir > Dir.Right)
                    dir = Dir.Left;
            }

        }
    }
}
