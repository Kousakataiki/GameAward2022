using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MagnetType
{
    // Start is called before the first frame update
    void Start()
    {
        pole = GetComponent<EnemyMoveAround>().GetMagnetType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            bool bPlayerMagnet = collision.gameObject.GetComponent<PlayerMagnet>().MagnetUse();
            POLE PlayerPole = collision.gameObject.GetComponent<PlayerMagnet>().GetMagnetType();
            Debug.Log("Use :" + bPlayerMagnet);
            if(bPlayerMagnet && pole != PlayerPole)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

        if(collision.gameObject.tag == "UsedGimmick")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if(rb.velocity.magnitude >= 10.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
