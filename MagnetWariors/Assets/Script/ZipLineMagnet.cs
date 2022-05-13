using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLineMagnet : MagnetType
{
    private Vector3 Pos;
    private float MagnetForceSampleAttract = 250;
    private BoxCollider ParentCol;
    private GameObject Player;
    private float Top, Bottom, Right, Left;
    private float MagnetForceSample = 250;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("���O�F" + transform.parent.gameObject.name);
        ParentCol = transform.parent.gameObject.GetComponent<BoxCollider>();
        Pos = transform.position;
        Top = Pos.y + (ParentCol.bounds.size.y / 2);
        Bottom = Pos.y - (ParentCol.bounds.size.y / 2);
        Right = Pos.x + (ParentCol.bounds.size.x / 2);
        Left = Pos.x - (ParentCol.bounds.size.x / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            if (pole == POLE.N && Controller.GetKeyRelease(Controller.ControllerButton.R))
            {
                Player = null;
            }
            if(pole == POLE.S && Controller.GetKeyRelease(Controller.ControllerButton.L))
            {
                Player = null;
            }
        }

        Pos = transform.position;
        Top = Pos.y + (ParentCol.bounds.size.y / 2);
        Bottom = Pos.y - (ParentCol.bounds.size.y / 2);
        Right = Pos.x + (ParentCol.bounds.size.x / 2);
        Left = Pos.x - (ParentCol.bounds.size.x / 2);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerMagnet")
        {
            GameObject PlayerObj = other.gameObject.transform.parent.gameObject;
            POLE PlayerPole = PlayerObj.GetComponent<PlayerMagnet>().GetMagnetType();
            Vector3 MagnetTargetPos = transform.parent.gameObject.transform.position;
            float MagnetSize = transform.parent.gameObject.GetComponent<BoxCollider>().bounds.size.y;
            MagnetTargetPos = new Vector3(MagnetTargetPos.x, MagnetTargetPos.y - MagnetSize / 2, MagnetTargetPos.z);
            Rigidbody rb = PlayerObj.GetComponent<Rigidbody>();
            Vector3 playerPos = other.gameObject.transform.position;
            Vector3 ForceVec;
            Debug.Log("�Ղꂢ��[�F" + PlayerPole);
            if (pole != PlayerPole)
            {
                ForceVec = MagnetTargetPos - other.gameObject.transform.position;
                ForceVec = ForceVec.normalized;
                rb.AddForce(ForceVec * MagnetForceSampleAttract);
                Player = other.gameObject.transform.parent.gameObject;
            }
            else
            {
                Debug.Log("��������[�I�I");
                PlayerObj.GetComponent<PlayerMagnet>().RemoveMagnetWall();
                if (playerPos.y <= Top && playerPos.y >= Bottom)
                {
                    if (playerPos.x > Right)
                    {
                        // �v���C���[���������ɂ͂���
                        rb.AddForce(MagnetForceSample, 0, 0);
                        Debug.Log("��");
                    }
                    else if (playerPos.x < Left)
                    {
                        // �v���C���[���E�����ɂ͂���
                        rb.AddForce(-MagnetForceSample, 0, 0);
                        Debug.Log("�E");
                    }
                }
                else if (playerPos.y > Top)
                {
                    if (playerPos.x >= Left && playerPos.x <= Right)
                    {
                        // �v���C���[��������ɂ͂���
                        rb.AddForce(0, MagnetForceSample, 0);
                        Debug.Log("��");
                    }
                    else if (playerPos.x < Left)
                    {
                        // �v���C���[��ǂ̍���Ɍ������Ă͂���
                        ForceVec = new Vector3(Left, Top, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * -MagnetForceSample);
                        Debug.Log("����");
                    }
                    else if (playerPos.x > Right)
                    {
                        // �v���C���[��ǂ̉E��Ɍ������Ă͂���
                        ForceVec = new Vector3(Right, Top, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * -MagnetForceSample);
                        Debug.Log("�E��");
                    }
                }
                else if (playerPos.y < Bottom)
                {
                    if (playerPos.x >= Left && playerPos.x <= Right)
                    {
                        // �v���C���[��������ɂ͂���
                        rb.AddForce(0, -MagnetForceSample, 0);
                        Debug.Log("��");
                    }
                    else if (playerPos.x < Left)
                    {
                        // �v���C���[��ǂ̍����Ɍ������Ă͂���
                        ForceVec = new Vector3(Left, Bottom, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * -MagnetForceSample);
                        Debug.Log("����");
                    }
                    else if (playerPos.x > Right)
                    {
                        // �v���C���[��ǂ̉E���Ɍ������Ă͂���
                        ForceVec = new Vector3(Right, Bottom, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * -MagnetForceSample);
                        Debug.Log("�E��");
                    }
                }
            }
        }
    }

    public GameObject GetPlayerObj()
    {
        return Player;
    }
}