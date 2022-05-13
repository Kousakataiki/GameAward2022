using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedGimmick : MagnetType
{
    private Rigidbody rb;

    private bool bUseMagnet = false;
    private bool bContact = false;
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bContact)
        {
            bUseMagnet = transform.parent.GetComponent<PlayerMagnet>().MagnetUse();
            if(!bUseMagnet)
            {
                bContact = false;
                transform.parent = null;
                rb = this.gameObject.AddComponent<Rigidbody>();
                rb.useGravity = true;
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bUseMagnet = collision.gameObject.GetComponent<PlayerMagnet>().MagnetUse();
            Debug.Log("Magnet :" + bUseMagnet);
            if(bUseMagnet)
            {
                bContact = true;
                transform.parent = collision.gameObject.transform;
                rb.velocity = new Vector3(0, 0, 0);
                Destroy(rb);
            }
        }

        if(collision.gameObject.tag == "UsedGimmick")
        {
            if (collision.gameObject.transform.parent != null)
            {
                if (collision.gameObject.transform.parent.tag == "Player")
                {
                    bUseMagnet = collision.gameObject.transform.parent.GetComponent<PlayerMagnet>().MagnetUse();
                    if (bUseMagnet)
                    {
                        bContact = true;
                        transform.parent = collision.gameObject.transform.parent;
                        rb.velocity = new Vector3(0, 0, 0);
                        Destroy(rb);
                    }
                }
            }
            
        }
    }
}
