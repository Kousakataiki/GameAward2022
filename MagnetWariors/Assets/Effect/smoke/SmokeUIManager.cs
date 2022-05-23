using UnityEngine;
using UnityEngine.VFX;

public class SmokeUIManager : MonoBehaviour
{
    //グローバル
    static private bool isSmokeNow = false;


    //変数
    [SerializeField] GameObject[] SumokeEffects;        //煙オブジェクト群
    [SerializeField] GameObject   SumokeTimeEffect;     //煙オブジェクト群
    [SerializeField] VisualEffect SumokeVFX;            //VFX

    [SerializeField] bool   isSmoke = false;            //煙演出確認
    [SerializeField] int    LiberationWorldState;       //ステージの開放状況
    [SerializeField] int    LiberationWorldMapState;    //ステージの開放状況
    [SerializeField] float  SmokeTimer;                 //ステージの開放状況

    [SerializeField] int    rateCounter;
    [SerializeField] int    liberationMapState;


    // Start is called before the first frame update
    void Start()
    {
    isSmokeNow = false;
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
        //クリア数取得
        int LiberationMapState  = SaveData.GetClearState();
        LiberationWorldState    = liberationMapState / 8;
        LiberationWorldMapState = liberationMapState % 8;

        //表示しないすべて無効
        for (int i = 0; i < LiberationWorldState; ++i)
        {
            SumokeEffects[i].SetActive(false);
        }

        //演出しなくていいとき判定
        if (!(LiberationWorldMapState == 0) || LiberationWorldState == 0)
        {
            return;
        }
        


        //消すスモークを選択
        SumokeTimeEffect = SumokeEffects[LiberationWorldState - 1];

        //消すスモークを有効化
        SumokeTimeEffect.SetActive(true);

        //煙消去モード有効化
        isSmokeNow = true;
        isSmoke = isSmokeNow;   //インスペクター確認用

        //VFX取得
        SumokeVFX = SumokeTimeEffect.GetComponent<VisualEffect>();
        

        //多分ここに音を追加


    }

    //スモーク演出更新
    void updateSumokeTime()
    {
        //演出中でなければスキップ
        if (!isSmokeNow)
            return;

        //レートタイマーが0になったらレートを0にする
        if (rateCounter<0)
            SumokeVFX.SetInt("rate", 0);
        else
            rateCounter--;


        //時間を過ぎたら
        if (SmokeTimer < 0)
        {
            //演出の終わったスモークを消す
            SumokeTimeEffect.SetActive(false);

            //フラグを変更
            isSmokeNow = false;
            isSmoke = isSmokeNow;

        }
        else
        {
            //スモークタイマー更新
            SmokeTimer -= Time.deltaTime;
        }
    }


    static public  bool getSmokeEffectNow()
    {
        return isSmokeNow;
    }
}
