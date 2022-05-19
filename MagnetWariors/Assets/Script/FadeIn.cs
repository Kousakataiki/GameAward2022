using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private Animator anim;
    private GameObject goImage;
    private FadeOut FO;
    public  bool bStartFadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void EndFadeInAnim()
    {
        // フェード後に削除
        //Destroy(this.gameObject);


        // フェードアニメーション終了
        anim.SetBool("bStart", false);
        // フェードアウト開始
        goImage = GameObject.Find("FadeOut");
        FO = goImage.GetComponent<FadeOut>();
        FO.StartFadeOut();

        // フェード用Image無効化
        GetComponent<Image>().enabled = false;
        //bStartFadeOut = true
    }

    // フェードイン開始
    public void StartFadeIn()
    {
        // フェード用Imageを有効化
        GetComponent<Image>().enabled = true;
        // フェードアニメーション開始
        anim.SetBool("bStart", true);
    }
}
