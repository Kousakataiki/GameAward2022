using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private Animator anim;
    private GameObject goPlayer;
    private PlayerMove PM;
    private GameObject goRSO;
    private ReStartObj RSO;

    // Start is called before the first frame update
    void Start()
    {
        // アニメーションのコンポーネント取得
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        PM = goPlayer.GetComponent<PlayerMove>();
    }

    public void EndFadeOutAnim()
    {
        // フェードアウトアニメーション終了
        anim.SetBool("bStart", false);
        // フェード用Image無効化
        GetComponent<Image>().enabled = false;
        // フェード処理フラグ無効化
        PM.bFade = false;
    }

    public void StartFadeOut()
    {
        // ReStartObjのコンポーネント取得
        goRSO = GameObject.FindWithTag("ReStartObj");
        RSO = goRSO.GetComponent<ReStartObj>();

        // リスタートオブジェクト有効化
        RSO.ReStartObjOn();

        // フェード用Imageを有効化
        GetComponent<Image>().enabled = true;
        // フェードアニメーション開始
        anim.SetBool("bStart", true);
        // プレイヤーストップフラグ無効化
        PM.bStopPlayer = false;
    }
}
