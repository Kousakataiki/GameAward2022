using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMagnet : MagnetType
{
    [SerializeField] private float PullForce;
    [SerializeField] private float PushForce;

    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        pole = transform.parent.gameObject.GetComponent<Bullet>().GetMagnetType();
        mat = GetComponent<Renderer>().material;
        if (pole == POLE.N)
        {
            mat.SetColor("BaseColor", new Color(1f, 0, 0, 0.5f));
        }
        else
        {
            mat.SetColor("BaseColor", new Color(0, 0, 1f, 0.5f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerMagnet")
        {
            Rigidbody rb = other.gameObject.transform.parent.GetComponent<Rigidbody>();
            Vector3 vec = other.gameObject.transform.position - transform.position;
            POLE playerPole = other.gameObject.GetComponent<PlayerMagnetForce>().GetMagnetType();
            if (pole != playerPole)
            {
                rb.AddForce(vec * PullForce);
            }
            else
            {
                rb.AddForce(-vec * PushForce);
            }
        }
    }
}
