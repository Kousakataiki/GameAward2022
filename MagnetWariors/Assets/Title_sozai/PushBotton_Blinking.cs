using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PushBotton_Blinking : MonoBehaviour
{

    //イメージ情報
    Image image;

    //タイムカウント
    private float time_count;

    //自身の透明度数値
    private float alpha_;

    //点滅反転フラグ
    private bool Blinking_flag;

    //透明度の量
    private float alpha_value;


    // Start is called before the first frame update
    void Start()
    {
        //初期化
        image = gameObject.GetComponent<Image>();
        image.color = new Color(1, 1, 1, 0);
        time_count = 0;
        alpha_ = 0;
        Blinking_flag = false;
        alpha_value = 0.03f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //時間を+していく
        time_count += Time.deltaTime;
        

        //自身fのカラーを設定
        image.color = new Color(1, 1, 1, alpha_);

        //点滅反転フラグがfalseの時、透明度を足していく
        if (Blinking_flag == false)
        {
            alpha_ += alpha_value;
        }

        //点滅反転フラグがtrueの時、透明度を減らす
        if (Blinking_flag == true)
        {
            alpha_ -= alpha_value;
        }

        //透明度が1 または 0だったらフラグ反転
        if (alpha_ <= 0 || alpha_ >= 1)
        {
            Blinking_flag = !Blinking_flag;
        }
    }
    private void Update()
    {
        if (Controller.GetKeyPress(Controller.ControllerButton.B))
        {
            //シーン読み込み
            SceneManager.LoadScene("WorldSerect");
        }

    }
}
