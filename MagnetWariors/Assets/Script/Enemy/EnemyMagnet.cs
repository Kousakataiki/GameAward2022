using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagnet : MagnetType
{
    private float MagnetForceSample = 250;
    private float MagnetForceSampleAttract = 250;

    // Start is called before the first frame update
    void Start()
    {
        pole = GetComponent<EnemyMoveAround>().GetMagnetType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "PlayerMagnet")
        {
            POLE PlayerPole = other.gameObject.GetComponent<PlayerMagnetForce>().GetMagnetType();
            Rigidbody PlayerRB = other.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
            if (pole != PlayerPole)
            {
                Vector3 Dir = transform.position - other.transform.position;
                Dir = Dir.normalized;
                PlayerRB.AddForce(Dir * MagnetForceSample);
            }
            else
            {
                Vector3 Dir = other.transform.position - transform.position;
                Dir = Dir.normalized;
                PlayerRB.AddForce(Dir * MagnetForceSampleAttract);
            }
        }
    }
}
