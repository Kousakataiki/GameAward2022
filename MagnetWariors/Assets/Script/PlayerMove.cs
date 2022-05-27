using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private GameObject MagnetObj;

    private Vector2 Lstick;
    Rigidbody rb;

    private float moveSpeed = 5.0f;
    private float jumpPower = 5.0f;

    private bool bJump = true;

    public  Vector3 DebugRestartPos;
    public  Vector3 RestartPos;
    public bool bDeath = false;         // プレイヤー死亡中は有効
    public bool bSpark = false;         // プレイヤー感電中は有効
    public bool bFade = false;          // フェード処理中は有効
    public bool bStopPlayer = false;    // プレイヤー死亡時や感電時に操作を不可能にするためのフラグ

    private bool bMoveBGM = false;
    private bool bMove = true;

    private bool bMagnet = false;

    private bool bRight = false;
    private bool bLeft = false;

    private bool bRightTurn = false;
    private bool bLeftTurn = false;

    private Vector3 vDir = Vector3.zero;
    private Quaternion Rot;
    private float fSmooth = 4f;

    private Animator anim;
    private GameObject goFadeIn;
    private FadeIn FI;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = VariableManager.playerMoveSpeed_s;
        jumpPower = VariableManager.playerJumpPower_s;

        rb = GetComponent<Rigidbody>();
        DebugRestartPos = new Vector3(transform.position.x, 0.6f, transform.position.z);
        RestartPos = DebugRestartPos;

        anim = GetComponent<Animator>();

        MagnetObj = transform.Find("Magnet").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤー停止フラグが無効なら処理
        if(!bStopPlayer)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

            if (transform.Find("Magnet").gameObject.activeSelf)
            {
                bool bValidMagnet = transform.Find("Magnet").gameObject.GetComponent<PlayerMagnetForce>().MagnetFlg();
                if (bValidMagnet)
                {
                    bMagnet = true;
                }
                else
                {
                    bMagnet = false;
                }
            }
            else
            {
                transform.Find("Magnet").gameObject.GetComponent<PlayerMagnetForce>().UnValidMagnet();
                bMagnet = false;
            }

            if (!bMagnet)
            {
                Lstick = Controller.StickValue(Controller.ControllerStick.LStick);
                if (Lstick.x >= 0.1f)
                {
<<<<<<< HEAD
                    if (!bRight)
=======
                    rb.velocity = new Vector3(Lstick.x * moveSpeed, rb.velocity.y, rb.velocity.z);
                    if (!bRightTurn)
                    {
                        bRightTurn = true;
                        bLeftTurn = false;
                    }
                    //transform.rotation = Quaternion.Euler(0, 90, 0);
                    //MagnetObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            }
            else if (Lstick.x <= -0.1f)
            {
                if (!bLeft)
                {
                    rb.velocity = new Vector3(Lstick.x * moveSpeed, rb.velocity.y, rb.velocity.z);
                    if(!bLeftTurn)
                    {
                        bLeftTurn = true;
                        bRightTurn = false;
                    }
                    //transform.rotation = Quaternion.Euler(0, -90, 0);
                    //MagnetObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            }
            else
            {
                if (bJump)
                {
                    rb.velocity = new Vector3(rb.velocity.x * 0.1f, rb.velocity.y, rb.velocity.z);
                    if (rb.velocity.x >= 0.01f)
>>>>>>> origin/Yuuki
                    {
                        rb.velocity = new Vector3(Lstick.x * moveSpeed, rb.velocity.y, rb.velocity.z);
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        MagnetObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                }
                else if (Lstick.x <= -0.1f)
                {
                    if (!bLeft)
                    {
                        rb.velocity = new Vector3(Lstick.x * moveSpeed, rb.velocity.y, rb.velocity.z);
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        MagnetObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                }
                else
                {
                    if (bJump)
                    {
                        rb.velocity = new Vector3(rb.velocity.x * 0.1f, rb.velocity.y, rb.velocity.z);
                        if (rb.velocity.x >= 0.01f)
                        {
                            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                        }
                    }
                }
            }

            if (Controller.GetKeyTrigger(Controller.ControllerButton.A))
            {
                if (bJump)
                {
                    bJump = false;
                    AudioManager.instance.Play("PlayerJump");
                    anim.SetTrigger("Jump");
                    rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
                }
            }

            if (Controller.GetKeyTrigger(Controller.ControllerButton.Select))
            {
                transform.position = DebugRestartPos;
            }
        }
        

        if (rb.velocity.magnitude >= 2)
        {
            if (bJump && !bMoveBGM)
            {
                AudioManager.instance.BGMStart("PlayerWalk");
                bMoveBGM = true;
            }
        }
        else
        {
            if(bMoveBGM)
            {
                AudioManager.instance.BGMStop("PlayerWalk");
                bMoveBGM = false;
            }
        }

        // プレイヤー停止フラグが有効時は重力を解除する
        if(bStopPlayer)
        {
            // 重力解除
            rb.isKinematic = true;
            // 停止
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.isKinematic = false;
        }


        // プレイヤー死亡フラグが有効でフェード処理実行中で無ければ処理を行う
        if (bDeath && !bFade)
        {
            // フェードイン(リスタート処理)開始
            StartFade();
        }
    }

    void FixedUpdate()
    {
        if(bRightTurn)
        {
            vDir.x = 1.0f;
            Rot = Quaternion.LookRotation(vDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
        }
        if (bLeftTurn)
        {
            vDir.x = -1.0f;
            Rot = Quaternion.LookRotation(vDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
        }
        Debug.Log("Velo" + rb.velocity.magnitude);
        if(rb.velocity.magnitude >= 20f)
        {
            rb.velocity /= (rb.velocity.magnitude / 20f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            Vector3 colPos = collision.gameObject.transform.position;
            Vector3 colSize = collision.gameObject.GetComponent<BoxCollider>().bounds.size;
            Vector3 colPoint = collision.contacts[0].point;
            if (colPos.x - colSize.x / 2 <= colPoint.x && colPos.x + colSize.x / 2 >= colPoint.x && colPos.y + colSize.y / 2 <= colPoint.y + 0.8f)
            {
                bJump = true;
            }
<<<<<<< HEAD
            // フェード中でなければ効果音を再生
            if(!bFade)
            {
                AudioManager.instance.Play("PlayerLanding");
            }
            anim.SetTrigger("Landing");
=======
            if(rb.velocity.magnitude >= 5.0f)
            {
                AudioManager.instance.Play("PlayerLanding");
                anim.SetTrigger("Landing");
            }
>>>>>>> origin/Yuuki
        }

        if (collision.gameObject.tag == "Box")
        {
            Vector3 colPos = collision.gameObject.transform.position;
            Vector3 colSize = collision.gameObject.GetComponent<BoxCollider>().bounds.size;
            Vector3 colPoint = collision.contacts[0].point;
            if (colPos.x - colSize.x / 2 <= colPoint.x && colPos.x + colSize.x / 2 >= colPoint.x && colPos.y + colSize.y / 2 <= colPoint.y + 0.8f)
            {
                bJump = true;
            }
            AudioManager.instance.Play("PlayerLanding");
            anim.SetTrigger("Landing");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            Vector3 colPos = collision.gameObject.transform.position;
            Vector3 colSize = collision.gameObject.GetComponent<BoxCollider>().bounds.size;
            Vector3 colPoint = collision.contacts[0].point;
            
            if ((colPos.x - colSize.x / 2) > transform.position.x)
            {
                bRight = true;
            }
            else if ((colPos.x + colSize.x / 2) < transform.position.x)
            {
                bLeft = true;
            }
        }

        if (collision.gameObject.tag == "Box")
        {
            Vector3 colPos = collision.gameObject.transform.position;
            Vector3 colSize = collision.gameObject.GetComponent<BoxCollider>().bounds.size;
            Vector3 colPoint = collision.contacts[0].point;
            
            if (colPos.x - colSize.x / 2 > transform.position.x)
            {
                bRight = true;
            }
            else if (colPos.x + colSize.x / 2 < transform.position.x)
            {
                bLeft = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            bJump = false;
            bLeft = false;
            bRight = false;
            if (bMoveBGM)
            {
                AudioManager.instance.BGMStop("PlayerWalk");
                bMoveBGM = false;
            }
        }

        if(collision.gameObject.tag == "Box")
        {
            bJump = false;
            bLeft = false;
            bRight = false;
            if (bMoveBGM)
            {
                AudioManager.instance.BGMStop("PlayerWalk");
                bMoveBGM = false;
            }
        }
    }
    
    public void JumpAction()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
    }

    private void StartFade()
    {
        // フェード処理フラグ有効化
        bFade = true;
        // フェードインのコンポーネント取得
        goFadeIn = GameObject.Find("FadeIn");
        FI = goFadeIn.GetComponent<FadeIn>();
<<<<<<< HEAD
        // プレイヤー死亡アニメーション(演出)が終了後、フェードアウトしてリスタート座標に移動する
        FI.StartFadeIn();
=======

        // フェードアウトのコンポーネント取得
        //goFadeOut = GameObject.Find("FadeOut");
        //FO = goFadeIn.GetComponent<FadeOut>();

        // プレイヤー死亡アニメーション(演出)が終了後、フェードアウトしてリスタート座標に移動する
        FI.StartFadeIn();

        //if(FO.bEndFade)
        //{
        //    // リスタート座標にプレイヤーを移動させる
        //    transform.position = RestartPos;
        //    bDeath = false;   // 死亡フラグ無効
        //}
        bDeath = false;   // 死亡フラグ無効
>>>>>>> origin/Yuuki
    }

    public void ReStart()
    {
        // プレイヤーの慣性などを無くす
        rb.velocity = Vector3.zero;
        // リスタート座標にプレイヤーを移動させる
        transform.position = RestartPos;
        // 死亡フラグ無効
        bDeath = false;
    }

    private void SparkAnimEnd()
    {
        // 感電アニメーション終了時に呼び出される
        StartFade();
        // アニメーション終了
        bSpark = false;
    }
}
