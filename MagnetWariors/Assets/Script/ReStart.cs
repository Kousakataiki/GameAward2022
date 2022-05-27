using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 
    private void OnTriggerEnter(Collider coll)
    {
        // 範囲内にタグ「Player」が存在する
        if (coll.gameObject.tag == "Player")
        {
            // ーーーーー プレイヤーの死亡フラグを有効化する ーーーーー
            coll.attachedRigidbody.GetComponent<PlayerMove>().bDeath = true;
        }
    }
}
