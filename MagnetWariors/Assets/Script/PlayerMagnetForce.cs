using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetForce : MagnetType
{
    private float MagnetForce;
    private Material mat;

    private bool bMagnet;

    private bool bVisible = false;

    private Vector3 MagnetScale;

    // Start is called before the first frame update
    void Start()
    {
        MagnetForce = VariableManager.playerMagnetStrength_s;
        transform.localScale = 
            new Vector3(VariableManager.playerMagnetRange_s, VariableManager.playerMagnetRange_s, VariableManager.playerMagnetRange_s);
        MagnetScale = transform.localScale;
        pole = transform.parent.gameObject.GetComponent<PlayerMagnet>().GetMagnetType();
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        pole = transform.parent.gameObject.GetComponent<PlayerMagnet>().GetMagnetType();

        if(pole == POLE.N)
        {
            mat.SetColor("BaseColor", new Color(1f, 0, 0, 0.5f));
            if(Controller.GetKeyRelease(Controller.ControllerButton.L))
            {
                bMagnet = false;
            }
        }
        else
        {
            mat.SetColor("BaseColor", new Color(0, 0, 1f, 0.5f));
            if (Controller.GetKeyRelease(Controller.ControllerButton.R))
            {
                bMagnet = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (bVisible)
        {
            transform.localScale *= 1.2f;
            if (transform.localScale.x >= MagnetScale.x)
            {
                bVisible = false;
                transform.localScale = MagnetScale;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "UsedGimmick")
        {
            if (other.gameObject.transform.parent != transform.parent)
            {
                Debug.Log("îÒê⁄êG");
                Vector3 GimmickPos = other.gameObject.transform.position;
                float dis = transform.position.x - GimmickPos.x;
                float Dir = Mathf.Sign(dis);
                POLE GimmickPOLE = other.gameObject.GetComponent<UsedGimmick>().GetMagnetType();
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

                if (pole != GimmickPOLE)
                {
                    rb.AddForce(Dir * MagnetForce, 0, 0);
                }
                else
                {
                    rb.AddForce(-Dir * MagnetForce, 0, 0);
                }
            }
        }

        if(other.gameObject.tag == "MagnetWall")
        {
            transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
            bMagnet = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "MagnetWall")
        {
            bMagnet = false;
        }
    }
    
    public bool MagnetFlg()
    {
        return bMagnet;
    }

    public void UnValidMagnet()
    {
        bMagnet = false;
    }

    public void MagnetSpawn()
    {
        bVisible = true;
        transform.localScale = new Vector3(1, 1, 1);
    }
}
