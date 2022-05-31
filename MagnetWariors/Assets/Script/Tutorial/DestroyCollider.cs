using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollider : MonoBehaviour
{
    // 消すオブジェクト指定
    public GameObject DestroyObj;

    // PopUI呼び出し
    PopUI DownUI;

    // Start is called before the first frame update
    void Start()
    {
        DownUI = transform.parent.gameObject.GetComponent<PopUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (collision.gameObject.tag == "Player")
        {
            Destroy(DestroyObj);

            DownUI.canJudge = true;
        }
    }
}
