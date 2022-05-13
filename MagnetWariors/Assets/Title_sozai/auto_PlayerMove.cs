using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_PlayerMove : MonoBehaviour
{
    //animation情報取得
    private Animator anim;
    //リジッドボディの情報取得
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //アニメーション 歩くを設定
        anim.SetFloat("Speed",1);

        //右に進み続ける
        transform.position += transform.forward * 3.0f * Time.deltaTime;

    }

    //自動ジャンプ
   public void auto_jump()
    {
        anim.SetTrigger("Jump");
        rb.velocity = new Vector3(rb.velocity.x, 5.0f, rb.velocity.z);
    }

    //地面についたとき、着地のアニメーションを入れる
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            anim.SetTrigger("Landing");
        }

        if (collision.gameObject.tag == "Box")
        {
            anim.SetTrigger("Landing");
        }
    }
}
