using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private Animator anim;
    private Animator PlayerAnim;
    private GameObject goImage;
    private GameObject goPlayer;
    private FadeOut FO;
    private PlayerMove PM;
 
    // Start is called before the first frame update
    void Start()
    {
        // アニメーションのコンポーネント取得
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのコンポーネント取得
        goPlayer = GameObject.FindWithTag("Player");
        PM = goPlayer.GetComponent<PlayerMove>();
        PlayerAnim = goPlayer.GetComponent<Animator>();
    }

    // フェードイン終了
    public void EndFadeInAnim()
    {   
        // プレイヤーをリスタート位置へ移動
        PM.ReStart();

        // フェードアニメーション終了
        anim.SetBool("bStart", false);
        // ーーーーー フェードアウト開始 ーーーーー
        // フェードアウトのコンポーネント取得
        goImage = GameObject.Find("FadeOut");
        FO = goImage.GetComponent<FadeOut>();
        FO.StartFadeOut();

        // フェード用Image無効化
        GetComponent<Image>().enabled = false;
    }

    // フェードイン開始
    public void StartFadeIn()
    {
        // フェード用Imageを有効化
        GetComponent<Image>().enabled = true;
        // フェードアニメーション開始
        anim.SetBool("bStart", true);
    }

    private void SparkAnimEnd()
    {
        // 感電アニメーション終了
        PlayerAnim.SetBool("bElcShock", false);
    }
}
