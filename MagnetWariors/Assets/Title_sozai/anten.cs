using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anten : MonoBehaviour
{
    //イメージ情報
    Image image;

    //タイムカウント
    private float time_count;

    //自身の透明度数値
    private float alpha_;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        image = gameObject.GetComponent<Image>();
        image.color = new Color(1, 1, 1, 1);
        time_count = 0;
        alpha_ = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //時間を+していく
        time_count += Time.deltaTime;

        //自身fのカラーを設定
        image.color = new Color(1, 1, 1, alpha_);

        //時間になったら暗転を解除(α値を下げる)
        if (time_count > 1.0f)
        {
            alpha_ -= 0.01f;
        }

    }
}
