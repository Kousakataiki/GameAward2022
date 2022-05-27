using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private GameObject MagnetObj;

    private Vector2 Lstick;
    Rigidbody rb;

    private float moveSpeed = 5.0f;
    private float jumpPower = 5.0f;

    private bool bJump = true;

    public  Vector3 DebugRestartPos;
    public  Vector3 RestartPos;
    public bool bDeath = false;         // �v���C���[���S���͗L��
    public bool bSpark = false;         // �v���C���[���d���͗L��
    public bool bFade = false;          // �t�F�[�h�������͗L��
    public bool bStopPlayer = false;    // �v���C���[���S���⊴�d���ɑ����s�\�ɂ��邽�߂̃t���O

    private bool bMoveBGM = false;
    private bool bMove = true;

    private bool bMagnet = false;

    private bool bRight = false;
    private bool bLeft = false;

    private Animator anim;
    private GameObject goFadeIn;
    private FadeIn FI;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = VariableManager.playerMoveSpeed_s;
        jumpPower = VariableManager.playerJumpPower_s;

        rb = GetComponent<Rigidbody>();
        DebugRestartPos = new Vector3(transform.position.x, 0.6f, transform.position.z);
        RestartPos = DebugRestartPos;

        anim = GetComponent<Animator>();

        MagnetObj = transform.Find("Magnet").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[��~�t���O�������Ȃ珈��
        if(!bStopPlayer)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

            if (transform.Find("Magnet").gameObject.activeSelf)
            {
                bool bValidMagnet = transform.Find("Magnet").gameObject.GetComponent<PlayerMagnetForce>().MagnetFlg();
                if (bValidMagnet)
                {
                    bMagnet = true;
                }
                else
                {
                    bMagnet = false;
                }
            }
            else
            {
                transform.Find("Magnet").gameObject.GetComponent<PlayerMagnetForce>().UnValidMagnet();
                bMagnet = false;
            }

            if (!bMagnet)
            {
                Lstick = Controller.StickValue(Controller.ControllerStick.LStick);
                if (Lstick.x >= 0.1f)
                {
                    if (!bRight)
                    {
                        rb.velocity = new Vector3(Lstick.x * moveSpeed, rb.velocity.y, rb.velocity.z);
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        MagnetObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                }
                else if (Lstick.x <= -0.1f)
                {
                    if (!bLeft)
                    {
                        rb.velocity = new Vector3(Lstick.x * moveSpeed, rb.velocity.y, rb.velocity.z);
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        MagnetObj.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                }
                else
                {
                    if (bJump)
                    {
                        rb.velocity = new Vector3(rb.velocity.x * 0.1f, rb.velocity.y, rb.velocity.z);
                        if (rb.velocity.x >= 0.01f)
                        {
                            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                        }
                    }
                }
            }

            if (Controller.GetKeyTrigger(Controller.ControllerButton.A))
            {
                if (bJump)
                {
                    bJump = false;
                    AudioManager.instance.Play("PlayerJump");
                    anim.SetTrigger("Jump");
                    rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
                }
            }

            if (Controller.GetKeyTrigger(Controller.ControllerButton.Select))
            {
                transform.position = DebugRestartPos;
            }
        }
        

        if (rb.velocity.magnitude >= 2)
        {
            if (bJump && !bMoveBGM)
            {
                AudioManager.instance.BGMStart("PlayerWalk");
                bMoveBGM = true;
            }
        }
        else
        {
            if(bMoveBGM)
            {
                AudioManager.instance.BGMStop("PlayerWalk");
                bMoveBGM = false;
            }
        }

        // �v���C���[��~�t���O���L�����͏d�͂���������
        if(bStopPlayer)
        {
            // �d�͉���
            rb.isKinematic = true;
            // ��~
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.isKinematic = false;
        }


        // �v���C���[���S�t���O���L���Ńt�F�[�h�������s���Ŗ�����Ώ������s��
        if (bDeath && !bFade)
        {
            // �t�F�[�h�C��(���X�^�[�g����)�J�n
            StartFade();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            Vector3 colPos = collision.gameObject.transform.position;
            Vector3 colSize = collision.gameObject.GetComponent<BoxCollider>().bounds.size;
            Vector3 colPoint = collision.contacts[0].point;
            if (colPos.x - colSize.x / 2 <= colPoint.x + 0.2f && colPos.x + colSize.x / 2 >= colPoint.x - 0.2f && colPos.y + colSize.y / 2 <= colPoint.y + 0.8f)
            {
                bJump = true;
            }
            // �t�F�[�h���łȂ���Ό��ʉ����Đ�
            if(!bFade)
            {
                AudioManager.instance.Play("PlayerLanding");
            }
            anim.SetTrigger("Landing");
        }

        if (collision.gameObject.tag == "Box")
        {
            Vector3 colPos = collision.gameObject.transform.position;
            Vector3 colSize = collision.gameObject.GetComponent<BoxCollider>().bounds.size;
            Vector3 colPoint = collision.contacts[0].point;
            if (colPos.x - colSize.x / 2 <= colPoint.x + 0.2f && colPos.x + colSize.x / 2 >= colPoint.x - 0.2f && colPos.y + colSize.y / 2 <= colPoint.y + 0.8f)
            {
                bJump = true;
            }
            AudioManager.instance.Play("PlayerLanding");
            anim.SetTrigger("Landing");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            Vector3 colPos = collision.gameObject.transform.position;
            Vector3 colSize = collision.gameObject.GetComponent<BoxCollider>().bounds.size;
            Vector3 colPoint = collision.contacts[0].point;
            
            if ((colPos.x - colSize.x / 2) > transform.position.x)
            {
                bRight = true;
            }
            else if ((colPos.x + colSize.x / 2) < transform.position.x)
            {
                bLeft = true;
            }
        }

        if (collision.gameObject.tag == "Box")
        {
            Vector3 colPos = collision.gameObject.transform.position;
            Vector3 colSize = collision.gameObject.GetComponent<BoxCollider>().bounds.size;
            Vector3 colPoint = collision.contacts[0].point;
            
            if (colPos.x - colSize.x / 2 > transform.position.x)
            {
                bRight = true;
            }
            else if (colPos.x + colSize.x / 2 < transform.position.x)
            {
                bLeft = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            bJump = false;
            bLeft = false;
            bRight = false;
            if (bMoveBGM)
            {
                AudioManager.instance.BGMStop("PlayerWalk");
                bMoveBGM = false;
            }
        }

        if(collision.gameObject.tag == "Box")
        {
            bJump = false;
            bLeft = false;
            bRight = false;
            if (bMoveBGM)
            {
                AudioManager.instance.BGMStop("PlayerWalk");
                bMoveBGM = false;
            }
        }
    }
    
    public void JumpAction()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
    }

    private void StartFade()
    {
        // �t�F�[�h�����t���O�L����
        bFade = true;
        // �t�F�[�h�C���̃R���|�[�l���g�擾
        goFadeIn = GameObject.Find("FadeIn");
        FI = goFadeIn.GetComponent<FadeIn>();
        // �v���C���[���S�A�j���[�V����(���o)���I����A�t�F�[�h�A�E�g���ă��X�^�[�g���W�Ɉړ�����
        FI.StartFadeIn();
    }

    public void ReStart()
    {
        // �v���C���[�̊����Ȃǂ𖳂���
        rb.velocity = Vector3.zero;
        // ���X�^�[�g���W�Ƀv���C���[���ړ�������
        transform.position = RestartPos;
        // ���S�t���O����
        bDeath = false;
    }

    private void SparkAnimEnd()
    {
        // ���d�A�j���[�V�����I�����ɌĂяo�����
        StartFade();
        // �A�j���[�V�����I��
        bSpark = false;
    }
}
