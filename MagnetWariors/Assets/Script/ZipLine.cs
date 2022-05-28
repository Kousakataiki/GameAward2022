using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    private GameObject InitPosObj;
    private GameObject TargetPosObj;

    private Vector3 InitPos;
    private Vector3 TargetPos;

    private Vector3 WrapPos; // 中間地点

    private bool bReverse = false;
    private bool bReverseProcess = false;
    
    private Vector3 moveVec;

    [SerializeField] private bool bHori;
    
    private GameObject MagnetObj;

    private float Speed = 0.01f;
    [SerializeField] private float AcceleSpeed;
    private float MinSpeed;

    private GameObject PlayerObj;

    ZipLineMagnet zipMagnet;

    // Start is called before the first frame update
    void Start()
    {
        MinSpeed = Speed;
        InitPosObj = transform.Find("InitPos").gameObject;
        TargetPosObj = transform.Find("TargetPos").gameObject;

        InitPos = InitPosObj.transform.position;
        TargetPos = TargetPosObj.transform.position;

        WrapPos = TargetPos - (TargetPos - InitPos) / 2;

        moveVec = (TargetPos - InitPos).normalized;

        MagnetObj = transform.Find("MagnetBox").gameObject;
        MagnetObj.transform.position = InitPos;

        zipMagnet = MagnetObj.transform.Find("MagnetField").gameObject.GetComponent<ZipLineMagnet>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (bHori)
        {
            if (moveVec.x > 0)   // 移動方向のXがプラス
            {
                if (MagnetObj.transform.position.x >= WrapPos.x) // 中間地点を超えたかどうか
                {
                    if (!bReverseProcess)
                    {
                        Speed -= AcceleSpeed;
                        if (Speed <= 0.01f)
                            Speed = 0.01f;
                    }
                }
                else
                {
                    if (!bReverseProcess)
                    {
                        Speed += AcceleSpeed;
                    }
                }

                if (MagnetObj.transform.position.x >= TargetPos.x)
                {
                    if (!bReverseProcess)
                    {
                        moveVec *= -1;
                        bReverse = true;
                        bReverseProcess = true;
                        Invoke("WaitReverse", 2);

                    }
                }
            }
            else
            {
                if (MagnetObj.transform.position.x <= WrapPos.x) // 中間地点を超えたかどうか
                {
                    if (!bReverseProcess)
                    {
                        Speed -= AcceleSpeed;
                        if (Speed <= 0.01f)
                            Speed = 0.01f;
                    }
                }
                else
                {
                    if (!bReverseProcess)
                    {
                        Speed += AcceleSpeed;
                    }
                }

                if (MagnetObj.transform.position.x <= InitPos.x)
                {
                    if (!bReverseProcess)
                    {
                        moveVec *= -1;
                        bReverse = true;
                        bReverseProcess = true;
                        Invoke("WaitReverse", 2);
                    }
                }
            }
        }
        else
        {
            if (moveVec.y > 0)   // 移動方向のXがプラス
            {
                if (MagnetObj.transform.position.y >= WrapPos.y) // 中間地点を超えたかどうか
                {
                    if (!bReverseProcess)
                    {
                        Speed -= AcceleSpeed;
                        if (Speed <= 0.01f)
                            Speed = 0.01f;
                    }
                }
                else
                {
                    if (!bReverseProcess)
                    {
                        Speed += AcceleSpeed;
                    }
                }

                if (MagnetObj.transform.position.y >= TargetPos.y)
                {
                    if (!bReverseProcess)
                    {
                        moveVec *= -1;
                        bReverse = true;
                        bReverseProcess = true;
                        Invoke("WaitReverse", 2);
                    }
                }
            }
            else
            {
                if (MagnetObj.transform.position.y <= WrapPos.y) // 中間地点を超えたかどうか
                {
                    if (!bReverseProcess)
                    {
                        Speed -= AcceleSpeed;
                        if (Speed <= 0.01f)
                            Speed = 0.01f;
                    }
                }
                else
                {
                    if (!bReverseProcess)
                    {
                        Speed += AcceleSpeed;
                    }
                }

                if (MagnetObj.transform.position.y <= InitPos.y)
                {
                    if (!bReverseProcess)
                    {
                        moveVec *= -1;
                        bReverse = true;
                        bReverseProcess = true;
                        Invoke("WaitReverse", 2);
                    }
                }
            }
        }

        if(!bReverse)
        {
            PlayerObj = zipMagnet.GetPlayerObj();
            if(PlayerObj)
            {
                PlayerObj.transform.position += moveVec * Speed;
            }
            MagnetObj.transform.position += moveVec * Speed;
        }
    }
    
    private void WaitReverse()
    {
        bReverse = false;
        bReverseProcess = false;
    }
}
