using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Litnig : MonoBehaviour
{
    //----変数宣言
    //公開変数
    [SerializeField] float ChangeSpeed = 1.0f;
    [SerializeField] int   seedValue = 0;
    //内部変数
    [SerializeField] private float ChengeTime = 0.0f;

    [SerializeField] float setPos;
    [SerializeField] float setSize;

    //マテリアル
    private Material mat;

    private void Start()
    {
        //マテリアルの取得
        mat = GetComponent<Renderer>().material;
    }


    // Update is called once per frame
    void Update()
    {
        //時間の更新
        ChengeTime += Time.deltaTime;

        if (ChangeSpeed < ChengeTime)
        {
            //位置の決定
            setPos = Random.value;
            mat.SetFloat("_UVPos", setPos);

            //サイズの決定
            setSize = 0.01f + Random.value / 2; 
            mat.SetFloat("_UVSize", setSize);

            //時間のReset
            ChengeTime = 0.0f;
        }
    }
}
