using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSerect : MonoBehaviour
{

    //ステージ一覧
    private enum StageNum
    {
        Wind_1,
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
    }

    //ヒエラルキーでステージ番号を選択
    [SerializeField]
    private StageNum stagenum;

    //プレイヤーとのヒットフラグ
    private bool Hitflag;

    // Start is called before the first frame update
    void Start()
    {
        Hitflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーとヒットしていて　なおかつ　Aボタンを押しているとき
        if (Hitflag == true && Controller.GetKeyTrigger(Controller.ControllerButton.B))
        {
            //それぞれのマップへ飛ぶ
            switch (stagenum)
            {
                case StageNum.Wind_1:
                    SceneManager.LoadScene("W1S7");
                    break;
                case StageNum.Wind_2:
                    SceneManager.LoadScene("W2S1");
                    break;
                case StageNum.Wind_3:
                    SceneManager.LoadScene("W4S2");
                    break;
                case StageNum.Wind_4:
                    SceneManager.LoadScene("W3_base");
                    break;
                case StageNum.Wind_5:
                    SceneManager.LoadScene("W1S5");
                    break;
                case StageNum.Wind_6:
                    SceneManager.LoadScene("W1S6");
                    break;
                case StageNum.Wind_7:
                    SceneManager.LoadScene("W1S7");
                    break;
                case StageNum.Wind_8:
                    SceneManager.LoadScene("W1S8");
                    break;
                case StageNum.Fire_1:
                    SceneManager.LoadScene("W2S1");
                    break;
                case StageNum.Fire_2:
                    SceneManager.LoadScene("W2S2");
                    break;
                case StageNum.Fire_3:
                    SceneManager.LoadScene("W2S3");
                    break;
                case StageNum.Fire_4:
                    SceneManager.LoadScene("W2S4");
                    break;
                case StageNum.Fire_5:
                    SceneManager.LoadScene("W2S5");
                    break;
                case StageNum.Fire_6:
                    SceneManager.LoadScene("W2S6");
                    break;
                case StageNum.Fire_7:
                    SceneManager.LoadScene("W2S7");
                    break;
                case StageNum.Fire_8:
                    SceneManager.LoadScene("W2S8");
                    break;
                case StageNum.Water_1:
                    SceneManager.LoadScene("W3S1");
                    break;
                case StageNum.Water_2:
                    SceneManager.LoadScene("W3S2");
                    break;
                case StageNum.Water_3:
                    SceneManager.LoadScene("W3S3");
                    break;
                case StageNum.Water_4:
                    SceneManager.LoadScene("W3S4");
                    break;
                case StageNum.Water_5:
                    SceneManager.LoadScene("W3S5");
                    break;
                case StageNum.Water_6:
                    SceneManager.LoadScene("W3S6");
                    break;
                case StageNum.Water_7:
                    SceneManager.LoadScene("W3S7");
                    break;
                case StageNum.Water_8:
                    SceneManager.LoadScene("W3S8");
                    break;
                case StageNum.Nuclear_1:
                    SceneManager.LoadScene("W4S1");
                    break;
                case StageNum.Nuclear_2:
                    SceneManager.LoadScene("W4S2");
                    break;
                case StageNum.Nuclear_3:
                    SceneManager.LoadScene("W4S3");
                    break;
                case StageNum.Nuclear_4:
                    SceneManager.LoadScene("W4S4");
                    break;
                case StageNum.Nuclear_5:
                    SceneManager.LoadScene("W4S5");
                    break;
                case StageNum.Nuclear_6:
                    SceneManager.LoadScene("W4S6");
                    break;
                case StageNum.Nuclear_7:
                    SceneManager.LoadScene("W4S7");
                    break;
                case StageNum.Nuclear_8:
                    SceneManager.LoadScene("W4S8");
                    break;

            }
        }

        Hitflag = false;

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Hitflag = true;
        }
    }

}
