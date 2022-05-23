using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SmokeUIManager : MonoBehaviour
{
    //グローバル
    static public bool isSmokeNow = false;

    //変数
    [SerializeField] GameObject[] SumokeEffects;        //煙オブジェクト群
    [SerializeField] GameObject   SumokeTimeEffect;     //煙オブジェクト群

    [SerializeField] bool   isSmoke = false;         //煙演出確認
    [SerializeField] int    LiberationMapNum;             //ステージの開放状況
    [SerializeField] float  SmokeTimer;                  //ステージの開放状況

    // Start is called before the first frame update
    void Start()
    {
        initSumokeTime();
    }

    // Update is called once per frame
    void Update()
    {
        updateSumokeTime();
    }

    //スモーク演出初期化
    void initSumokeTime()
    {
        ////表示しないすべて無効
        //for(int i = 0; i < SumokeEffects.Length; ++i)
        //{
        //    SumokeEffects[i].SetActive(false);
        //}

        //消すスモークを選択
        SumokeTimeEffect = SumokeEffects[0];
 
        //煙消去モード有効化
        isSmokeNow = true;
        isSmoke = isSmokeNow;   //インスペクター確認用

        //VFX取得
        VisualEffect SumokeVFX = SumokeTimeEffect.GetComponent<VisualEffect>();
        //レートを0にする
        SumokeVFX.SetInt("rate", 0);
    }

    //スモーク演出更新
    void updateSumokeTime()
    {
        //演出中でなければスキップ
        if (!isSmokeNow)
            return;

        //スモークタイマー更新
        SmokeTimer -= Time.deltaTime;

        //時間を過ぎたら
        if (SmokeTimer < 0)
        {
            //演出の終わったスモークを消す
            SumokeTimeEffect.SetActive(false);

            //フラグを変更
            isSmokeNow = false;
            isSmoke = isSmokeNow;

        }
    }

}
