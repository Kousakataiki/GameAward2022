using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetWall : MagnetType
{
    private Vector3 Pos;
    private BoxCollider ParentCol, col;
    private float Top, Bottom, Right, Left;
    
    private float MagnetForceSample = 250;
    private float MagnetForceSampleAttract = 250;

    private Vector3 InitPos;
    private bool bRemove = false;

    private Vector4 FourEdge;
    
    // Start is called before the first frame update
    void Start()
    {
        ParentCol = transform.parent.gameObject.GetComponent<BoxCollider>();
        Pos = transform.parent.gameObject.transform.position;
        Top = Pos.y + (ParentCol.bounds.size.y / 2);
        Bottom = Pos.y - (ParentCol.bounds.size.y / 2);
        Right = Pos.x + (ParentCol.bounds.size.x / 2);
        Left = Pos.x - (ParentCol.bounds.size.x / 2);
        FourEdge = new Vector4(Top, Bottom, Left,Right);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerMagnet")
        {
            InitPos = other.gameObject.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerMagnet")
        {
            GameObject PlayerObj = other.gameObject.transform.parent.gameObject;
            POLE PlayerPole = PlayerObj.GetComponent<PlayerMagnet>().GetMagnetType();
            Rigidbody rb = PlayerObj.GetComponent<Rigidbody>();
            Vector3 playerPos = other.gameObject.transform.position;
            Vector3 ForceVec;
            if (PlayerPole != pole)
            {
                if (playerPos.y <= Top && playerPos.y >= Bottom)
                {
                    if (playerPos.x > Right)
                    {
                        // プレイヤーを左方向に吸い寄せ
                        rb.AddForce(-MagnetForceSampleAttract, 0, 0);
                        if (Controller.StickValue(Controller.ControllerStick.LStick).x >= 0.1f)
                        {
                            if (playerPos.y >= Bottom && playerPos.y <= Top)
                            {
                                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                            }
                        }
                    }
                    else if (playerPos.x < Left)
                    {
                        // プレイヤーを右方向に吸い寄せ
                        rb.AddForce(MagnetForceSampleAttract, 0, 0);
                        if (Controller.StickValue(Controller.ControllerStick.LStick).x <= -0.1f)
                        {
                            if (playerPos.y >= Bottom && playerPos.y <= Top)
                            {
                                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                            }
                        }
                    }
                }
                else if (playerPos.y > Top)
                {
                    if (playerPos.x >= Left && playerPos.x <= Right)
                    {
                        // プレイヤーを下方向に吸い寄せ
                        rb.AddForce(0, -MagnetForceSampleAttract, 0);
                    }
                    else if (playerPos.x < Left)
                    {
                        // プレイヤーを壁の左上に向かって吸い寄せ
                        ForceVec = new Vector3(Left, Top, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * MagnetForceSampleAttract);
                        if (Controller.StickValue(Controller.ControllerStick.LStick).x <= -0.1f)
                        {
                            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / 5, rb.velocity.z);
                        }
                    }
                    else if (playerPos.x > Right)
                    {
                        // プレイヤーを壁の右上に向かって吸い寄せ
                        ForceVec = new Vector3(Right, Top, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * MagnetForceSampleAttract);
                        if (Controller.StickValue(Controller.ControllerStick.LStick).x >= 0.1f)
                        {
                            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / 5, rb.velocity.z);
                        }
                    }
                }
                else if (playerPos.y < Bottom)
                {
                    if (playerPos.x >= Left && playerPos.x <= Right)
                    {
                        // プレイヤーを上方向に吸い寄せ
                        rb.AddForce(0, MagnetForceSampleAttract, 0);
                    }
                    else if (playerPos.x < Left)
                    {
                        // プレイヤーを壁の左下に向かって吸い寄せ
                        ForceVec = new Vector3(Left, Bottom, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * MagnetForceSampleAttract);
                        if (Controller.StickValue(Controller.ControllerStick.LStick).x <= -0.1f)
                        {
                            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / 5, rb.velocity.z);
                        }
                    }
                    else if (playerPos.x > Right)
                    {
                        // プレイヤーを壁の右下に向かって吸い寄せ
                        ForceVec = new Vector3(Right, Bottom, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * MagnetForceSampleAttract);
                        if (Controller.StickValue(Controller.ControllerStick.LStick).x >= 0.1f)
                        {
                            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / 5, rb.velocity.z);
                        }
                    }
                }
            }
            else if(PlayerPole == pole)
            {
                PlayerObj.GetComponent<PlayerMagnet>().RemoveMagnetWall();
                if (playerPos.y <= Top && playerPos.y >= Bottom)
                {
                    if (playerPos.x > Right)
                    {
                        // プレイヤーを左方向にはじく
                        rb.AddForce(MagnetForceSample, 0, 0);
                    }
                    else if (playerPos.x < Left)
                    {
                        // プレイヤーを右方向にはじく
                        rb.AddForce(-MagnetForceSample, 0, 0);
                    }
                }
                else if (playerPos.y > Top)
                {
                    if (playerPos.x >= Left && playerPos.x <= Right)
                    {
                        // プレイヤーを上方向にはじく
                        rb.AddForce(0, MagnetForceSample, 0);
                    }
                    else if (playerPos.x < Left)
                    {
                        // プレイヤーを壁の左上に向かってはじく
                        ForceVec = new Vector3(Left, Top, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * -MagnetForceSample);
                    }
                    else if (playerPos.x > Right)
                    {
                        // プレイヤーを壁の右上に向かってはじく
                        ForceVec = new Vector3(Right, Top, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * -MagnetForceSample);
                    }
                }
                else if (playerPos.y < Bottom)
                {
                    if (playerPos.x >= Left && playerPos.x <= Right)
                    {
                        // プレイヤーを下方向にはじく
                        rb.AddForce(0, -MagnetForceSample, 0);
                    }
                    else if (playerPos.x < Left)
                    {
                        // プレイヤーを壁の左下に向かってはじく
                        ForceVec = new Vector3(Left, Bottom, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * -MagnetForceSample);
                    }
                    else if (playerPos.x > Right)
                    {
                        // プレイヤーを壁の右下に向かってはじく
                        ForceVec = new Vector3(Right, Bottom, Pos.z) - playerPos;
                        ForceVec = ForceVec.normalized;
                        rb.AddForce(ForceVec.normalized * -MagnetForceSample);
                    }
                }
            }
        }
    }

    public Vector4 GetEdge()
    {
        return FourEdge;
    }
}

