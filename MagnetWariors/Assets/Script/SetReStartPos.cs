using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetReStartPos : MonoBehaviour
{
    //GameObject goPlayer;    // Playerオブジェクト
    //PlayerMove pm;          // PlayerMoveのスクリプト

    // Start is called before the first frame update
    void Start()
    {
        // PlayerMove.csの変数を使用するためにpmに情報を格納しておく
        //goPlayer = GameObject.Find("Player");
        //pm = goPlayer.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        // Playerがオブジェクトに触れたらリスタート座標設定処理を実行
        // 範囲内にタグ「Player」が存在する
        if (coll.gameObject.tag == "Player")
        {
            // ーーーーー リスタート座標設定処理 ーーーーー
            coll.attachedRigidbody.GetComponent<PlayerMove>().RestartPos = this.transform.position;
        }
    }
}
