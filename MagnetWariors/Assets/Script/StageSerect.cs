using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSerect : MonoBehaviour
{
    GameObject FadeObj;
    Fade fade;

    //ステージ一覧
    private enum StageNum
    {
        Wind_1 = 0,
        Wind_2,
        Wind_3,
        Wind_4,
        Wind_5,
        Wind_6,
        Wind_7,
        Wind_8,
        Fire_1,
        Fire_2,
        Fire_3,
        Fire_4,
        Fire_5,
        Fire_6,
        Fire_7,
        Fire_8,
        Water_1,
        Water_2,
        Water_3,
        Water_4,
        Water_5,
        Water_6,
        Water_7,
        Water_8,
        Nuclear_1,
        Nuclear_2,
        Nuclear_3,
        Nuclear_4,
        Nuclear_5,
        Nuclear_6,
        Nuclear_7,
        Nuclear_8,

        MAX_Stage
    }

    private string[] StageFileName;

    //ヒエラルキーでステージ番号を選択
    [SerializeField]
    private StageNum stagenum;

    //プレイヤーとのヒットフラグ
    private bool Hitflag;


    private enum MovePhase
    {
        None,
        Move,
        Rotate,
        Enter,
        End,
    }
    [SerializeField] MovePhase Phase;

    GameObject Player;
    Animator anim;

    Vector3 StartPos;
    Vector3 TargetPos;
    Quaternion StartRot;
    Quaternion TargetRot;

    [SerializeField] float MoveSpeed;
    [SerializeField] float RotateSpeed;
    [SerializeField] float EnterSpeed;
    [SerializeField] float DoorAnimSpeed;

    float AnimCnt;

    // Start is called before the first frame update
    void Start()
    {
        Hitflag = false;

        FadeObj = GameObject.Find("Fade");
        fade = FadeObj.GetComponent<Fade>();

        Player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();

        AnimCnt = 0f;

        StageFileName = new string[(int)StageNum.MAX_Stage];
        StageFileName[0] = "W1S1";
        StageFileName[1] = "W1S2";
        StageFileName[2] = "W1S3";
        StageFileName[3] = "W1S4";
        StageFileName[4] = "W1S5";
        StageFileName[5] = "W1S6";
        StageFileName[6] = "W1S7";
        StageFileName[7] = "W1S8";
        StageFileName[8] = "W2S1";
        StageFileName[9] = "W2S2";
        StageFileName[10] = "W2S3";
        StageFileName[11] = "W2S4";
        StageFileName[12] = "W2S5";
        StageFileName[13] = "W2S6";
        StageFileName[14] = "W2S7";
        StageFileName[15] = "W2S8";
        StageFileName[16] = "W3S1";
        StageFileName[17] = "W3S2";
        StageFileName[18] = "W3S3";
        StageFileName[19] = "W3S4";
        StageFileName[20] = "W3S5";
        StageFileName[21] = "W3S6";
        StageFileName[22] = "W3S7";
        StageFileName[23] = "W3S8";
        StageFileName[24] = "W4S1";
        StageFileName[25] = "W4S2";
        StageFileName[26] = "W4S3";
        StageFileName[27] = "W4S4";
        StageFileName[28] = "W4S5";
        StageFileName[29] = "W4S6";
        StageFileName[30] = "W4S7";
        StageFileName[31] = "W4S8";
    }

    // Update is called once per frame
    void Update()
    {
        switch (Phase)
        {
            case MovePhase.None:
                //プレイヤーとヒットしていて　なおかつ　Aボタンを押しているとき
                // /////接地しているときも条件に加えたい/////
                if (Hitflag == true && Controller.GetKeyTrigger(Controller.ControllerButton.B))
                {
                    int ClearStageNum = SaveData.GetClearState();
                    //それぞれのマップへ飛ぶ
                    if (ClearStageNum >= (int)stagenum)
                    {
                        StartPos = Player.transform.position;
                        TargetPos = new Vector3(gameObject.transform.position.x, StartPos.y, StartPos.z);
                        Player.transform.LookAt(TargetPos);
                        Destroy(Player.GetComponent<PlayerMove>());
                        Player.GetComponent<Rigidbody>().useGravity = false;
                        Player.GetComponent<Collider>().enabled = false;
                        AudioManager.instance.BGMStart("PlayerWalk");
                        Phase = MovePhase.Move;
                    }
                }
                Hitflag = false;
                break;

            case MovePhase.Move:
                // ドアの前まで移動
                Player.transform.position += Player.transform.forward * MoveSpeed * Time.deltaTime;
                // 十分ドアの前に来たら次へ
                if (Vector3.Distance(Player.transform.position, TargetPos) < 0.1f)
                {
                    Player.transform.position = TargetPos;
                    StartRot = Player.transform.rotation;
                    TargetRot = Quaternion.identity;
                    AnimCnt = 0f;
                    anim.SetFloat("Speed", DoorAnimSpeed);
                    anim.SetTrigger("Open");
                    Phase = MovePhase.Rotate;
                }
                break;

            case MovePhase.Rotate:
                // ドアを向く
                AnimCnt = Mathf.Min(1f, AnimCnt + RotateSpeed * Time.deltaTime);
                Player.transform.rotation = Quaternion.Lerp(StartRot, TargetRot, AnimCnt);
                // ドアを向いたら次へ
                if (AnimCnt >= 1.0f)
                {
                    StartPos = Player.transform.position;
                    TargetPos = StartPos + new Vector3(0, 0, 1.5f);
                    AnimCnt = 0f;
                    Phase = MovePhase.Enter;
                }
                break;

            case MovePhase.Enter:
                // ドアに入る
                AnimCnt = Mathf.Min(1f, AnimCnt + MoveSpeed * Time.deltaTime);
                Player.transform.position = Vector3.Lerp(StartPos, TargetPos, AnimCnt);
                // ドアに入ったらシーン遷移
                if (AnimCnt >= 1.0f)
                {

                    AudioManager.instance.BGMStop("BGM_StageSerect");
                    AudioManager.instance.BGMStop("PlayerWalk");
                    fade.fadeOutStart(0, 0, 0, 0, StageFileName[(int)stagenum]);
                    anim.SetFloat("Speed", DoorAnimSpeed);
                    anim.SetTrigger("Close");
                    Phase = MovePhase.End;
                }
                break;

            case MovePhase.End:
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Hitflag = true;
        }
    }   
}
