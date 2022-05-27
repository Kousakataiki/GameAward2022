using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MagnetType
{
    // Start is called before the first frame update
    void Start()
    {
        pole = transform.parent.gameObject.GetComponent<EnemyMoveAround>().GetMagnetType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Rigidbody rb = coll.gameObject.GetComponent<Rigidbody>();
            bool bPlayerMagnet = coll.gameObject.GetComponent<PlayerMagnet>().MagnetUse();
            POLE PlayerPole = coll.gameObject.GetComponent<PlayerMagnet>().GetMagnetType();
            Debug.Log("Use :" + bPlayerMagnet);
            if(bPlayerMagnet && pole != PlayerPole)
            {
                //Destroy(this.gameObject);
            }
            else
            {
                Destroy(coll.gameObject);
            }
        }

        if(coll.gameObject.tag == "UsedGimmick")
        {
            Rigidbody rb = coll.gameObject.GetComponent<Rigidbody>();
            if(rb.velocity.magnitude >= 10.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
