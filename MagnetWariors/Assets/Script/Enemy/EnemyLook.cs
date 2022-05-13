using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    [SerializeField] private Transform Self;
    [SerializeField] private Transform Target;

    // 範囲内にターゲットが入っているか
    public bool bJoin;

    // Start is called before the first frame update
    void Start()
    {
        bJoin = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ターゲットが範囲内なら
        if(bJoin)
        {
            // ターゲットの方向に自身を回転させる
            Self.LookAt(Target);
            //Self.transform.localScale = this.transform.localScale;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 範囲内にタグ「Player」が存在する
        if (other.gameObject.tag == "Player")
        {
            bJoin = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 範囲内にタグ「Player」が存在しなくなった
        if (other.gameObject.tag == "Player")
        {
            bJoin = false;
        }
    }
}
