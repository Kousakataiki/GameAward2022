using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetReStartPos : MonoBehaviour
{
    private GameObject goRSO;
    private ReStartObj RSO;

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
        // Playerがオブジェクトに触れたらリスタート座標設定処理を実行
        // 範囲内にタグ「Player」が存在する
        if (coll.gameObject.tag == "Player")
        {
            // ーーーーー リスタート座標設定処理 ーーーーー
            coll.attachedRigidbody.GetComponent<PlayerMove>().RestartPos = this.transform.position;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        goRSO = GameObject.Find("ReStartObj");
        RSO = goRSO.GetComponent<ReStartObj>();

        if (coll.gameObject.tag == "Player")
        {
            // リスタートオブジェクトを無効化
            RSO.ReStartObjOff();
        }

    }
}
