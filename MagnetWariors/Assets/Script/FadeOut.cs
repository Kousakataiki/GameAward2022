using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが死んだら、無効になっているImageを有効化
        //if()
        //{
        //      GetComponent<Image>().enabled = true;
        //}
    }

    public void EndFadeOutAnim()
    {
        // フェード後に削除
        //Destroy(this.gameObject);

        // フェードアウトアニメーション終了
        anim.SetBool("bStart", false);
        GetComponent<Image>().enabled = false;
    }

    public void StartFadeOut()
    {
        GetComponent<Image>().enabled = true;
        anim.SetBool("bStart", true);
    }
}
