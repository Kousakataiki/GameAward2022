using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private Animator anim;
    private GameObject goPlayer;
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
        
    }

    public void EndFadeOutAnim()
    {
        // フェードアウトアニメーション終了
        anim.SetBool("bStart", false);
        // フェード用Image無効化
        GetComponent<Image>().enabled = false;
    }

    public void StartFadeOut()
    {
        // PlayerMoveのコンポーネント取得
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        PM = goPlayer.GetComponent<PlayerMove>();
        // フェード用Imageを有効化
        GetComponent<Image>().enabled = true;
        // フェードアニメーション開始
        anim.SetBool("bStart", true);
        // プレイヤーリスタート処理
        PM.ReStart();
    }
}
