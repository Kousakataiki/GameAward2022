using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Effect : MonoBehaviour
{
    //ÉJÉÅÉâ
    private GameObject CamPos;
    private GameObject Player;
    SpriteRenderer sr;
    private float alpha_;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        CamPos = GameObject.Find("Main Camera");
        sr = this.GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        alpha_ = 0;
        flag = false;
        sr.color = new Color(0, 0, 0, alpha_);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(CamPos.transform.position.x,CamPos.transform.position.y,-20.0f);

        sr.color = new Color(0, 0, 0, alpha_);

        if(flag == false)
        {
            alpha_ += 0.05f;
            if(alpha_ >= 1.1f)
            {
                flag = true;
                Player.transform.position = new Vector3(-90.2f,0.68f,2f);
            }
        }

        if(flag == true)
        {
            alpha_ -= 0.05f;
            if (alpha_ <= 0.0f)
            {
                Destroy(this.gameObject);
            }
        }


    }
}
