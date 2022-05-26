using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElcShock : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        // プレイヤーが触れた
        if (coll.gameObject.tag == "Player")
        {
            // アニメーション再生中は判定を行わない
            if(!coll.GetComponent<PlayerMove>().bSpark)
            {
                // アニメーション実行中フラグ有効化
                coll.GetComponent<PlayerMove>().bSpark = true;
                // プレイヤーのコンポーネント取得
                anim = coll.gameObject.GetComponent<Animator>();
                //anim.SetTrigger("ElcShock");
                // 感電アニメーションフラグ有効化→アニメーション開始
                anim.SetBool("bElcShock", true);
                // プレイヤー停止フラグ有効化
                anim.GetComponent<PlayerMove>().bStopPlayer = true;
            }
        }
    }
}
