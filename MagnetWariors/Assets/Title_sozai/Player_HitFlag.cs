using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HitFlag : MonoBehaviour
{
    private auto_PlayerMove auto_Player;


    // Start is called before the first frame update
    void Start()
    {
        auto_Player = GameObject.Find("robot_wait").GetComponent<auto_PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //ジャンプするべきブロックとあたったら
        if(other.gameObject.tag == "jumpblock")
        {
            auto_Player.auto_jump();
        }

        //マグネット
        if (other.gameObject.tag == "")
        {

        }

    }

    

}
