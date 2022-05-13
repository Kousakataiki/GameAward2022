using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleZipLine : MonoBehaviour
{
    private Vector3 CenterPos;
    [SerializeField] float Speed;
    [SerializeField] float Radius;
    private float x, y;

    private GameObject PlayerObj;

    private bool bContact = false;

    private Vector3 befPos;

    // Start is called before the first frame update
    void Start()
    {
        CenterPos = transform.parent.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Radius * Mathf.Sin(Time.time * Speed);
        y = Radius * Mathf.Cos(Time.time * Speed);

        transform.position = new Vector3(x + CenterPos.x, y + CenterPos.y, CenterPos.z);
    }

    void Update()
    {
        if(bContact)
        {
            bool bPlayerMagnet = PlayerObj.GetComponent<PlayerMagnet>().MagnetUse();
            if(!bPlayerMagnet)
            {
                bContact = false;
                PlayerObj.transform.parent = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerObj = collision.gameObject;
            bool bPlayerMagnet = PlayerObj.GetComponent<PlayerMagnet>().MagnetUse();
            if(bPlayerMagnet)
            {
                bContact = true;
                collision.gameObject.transform.parent = this.gameObject.transform;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
}