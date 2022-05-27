using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField] string LoadSceneName = "World_1";

    [SerializeField] float LeverAnimSpeed;
    [SerializeField] float CameraDistance;
    [SerializeField] float WaitTime;

    [SerializeField] Quaternion TargetRot;  // ‰ñ“]Šp“x
    [SerializeField] float RotateSpeed;     // ‰ñ“]‘¬“x
    Quaternion StartRot;    // ŠJŽnŠp“x

    [SerializeField] GameObject ClearEffect;

    GameObject Player;
    MainCamera mainCamera;
    Animator anim;
    Animator PlayerAnim;
    Rigidbody PlayerRB;

    
    [SerializeField] bool isLeverAnimEnd;
    [SerializeField] bool isRotating;
    [SerializeField] bool Finish;
    float RotateCnt;
    float Timer;
    

    [SerializeField] float jumpPower = 5.0f;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<MainCamera>();
        anim = GetComponent<Animator>();
        PlayerAnim = Player.GetComponent<Animator>();
        PlayerRB = Player.GetComponent<Rigidbody>();

        isLeverAnimEnd = false;
        Finish = false;
        RotateCnt = 0f;
        Timer = 0f;

        jumpPower = VariableManager.playerJumpPower_s;
    }


    void FixedUpdate()
    {
        if (!Finish)
        {
            if (isLeverAnimEnd)
            {
                if (isRotating)
                {
                    RotateCnt = Mathf.Min(1f, RotateCnt + RotateSpeed * Time.deltaTime);
                    Player.transform.rotation = Quaternion.Lerp(StartRot, TargetRot, RotateCnt);

                    if (RotateCnt >= 1.0f)
                    {
                        isRotating = false;
                    }
                }
                else
                {
                    PlayerRB.velocity = new Vector3(PlayerRB.velocity.x, jumpPower, PlayerRB.velocity.z);
                    PlayerAnim.SetTrigger("Jump");
                    Finish = true;
                }
            }
        }
        else
        {
            Timer += Time.deltaTime;

            if (Timer >= WaitTime)
            {
                SceneManager.LoadScene(LoadSceneName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(Player.GetComponent<PlayerMove>());
            StartRot = Player.transform.rotation;
            mainCamera.SetCameraMode(MainCamera.CAMERA_MODE.GoalAnim);
            anim.SetTrigger("Pull");
        }
    }

    public void LeverAnimEnd()
    {
        isLeverAnimEnd = true;
        isRotating = true;

        Vector3 CameraTargetPos = Player.transform.position + new Vector3(0, Player.GetComponent<CapsuleCollider>().height / 2, -CameraDistance);
        mainCamera.SetTargetPos(CameraTargetPos);
        mainCamera.PlayGoalAnim();

        Instantiate(ClearEffect, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
