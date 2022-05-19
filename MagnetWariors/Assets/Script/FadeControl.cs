using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 無効になっているImageを有効化
        GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが死んだらフェードパネルを有効化
    }

    public void EndFadeInAnimation()
    {
        // フェード後に削除
        Destroy(this.gameObject);
    }

    public void EndFadeOutAnim()
    {
        // フェード後に削除
        Destroy(this.gameObject);
    }
}
