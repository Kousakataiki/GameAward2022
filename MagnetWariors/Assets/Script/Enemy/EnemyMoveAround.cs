using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAround : MagnetType
{
    // �����Ă������
    public enum Dir
    {
        Left = 0,
        Right,
        Up,
        Down,
        MAX_DIR
    }

    // ���W�b�h�{�f�B
    Rigidbody rb;
    // �G�p�����[�^
    [SerializeField] public float fSpd;
    [SerializeField] public float fSmooth;
    private Vector3 vDir = Vector3.zero;
    private Quaternion Rot;
    public Dir dir;


    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g�擾
        rb = GetComponent<Rigidbody>();

        // �����Ă��������������
        //if (this.gameObject.tag == "FloatEnemyVertical")
        //    dir = Dir.Down;
        //else
        //    dir = Dir.Left;

    }

    // Update is called once per frame
    void Update()
    {
        // ���]�f�o�b�O����
        if(Controller.GetKeyTrigger(Controller.ControllerButton.Y))
        {
            dir++;
            if(dir > Dir.Right)
            {
                dir = Dir.Left;
            }
        }

        // �A�^�b�`����Ă���I�u�W�F�N�g�̃^�O�ŏ�����ύX����
        // �G�̈ړ�
        if(this.gameObject.tag == "Enemy")
        {
            EnemyMove();
        }

        // �����Ă���u�c�v�ړ��̓G
        else if(this.gameObject.tag == "FloatEnemyVertical")
        {
            VerticalMove();
        }

        // �����Ă���u���v�ړ��̓G
        else if (this.gameObject.tag == "FloatEnemyHorizontal")
        {
            HorizontalMove();
        }
    }

    private void EnemyMove()
    {
        // �����Ă�������ɂ���ď�����ύX����
        switch (dir)
        {
            // ���������Ă���
            case Dir.Left:
                vDir.z = -1.0f;
                Rot = Quaternion.LookRotation(vDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            // �E�������Ă���
            case Dir.Right:
                vDir.z = 1.0f;
                Rot = Quaternion.LookRotation(vDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            default:
                break;
        }
        // ���E�ړ�
        rb.velocity = new Vector3((rb.velocity.x + vDir.z) * fSpd, rb.velocity.y, rb.velocity.z);
    }

    private void HorizontalMove()
    {
        // �����Ă�������ɂ���ď�����ύX����
        switch (dir)
        {
            // ���������Ă���
            case Dir.Left:
                vDir.x = -1.0f;
                Rot = Quaternion.LookRotation(vDir);
                // ��]
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            // �E�������Ă���
            case Dir.Right:
                vDir.x = 1.0f;
                Rot = Quaternion.LookRotation(vDir);
                // ��]
                transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * fSmooth);
                break;

            default:
                break;
        }
        // ���E�ړ�
        rb.velocity = new Vector3((rb.velocity.x + vDir.x) * fSpd, rb.velocity.y, rb.velocity.z);
    }

    private void VerticalMove()
    {
        // ���ʂɌŒ�
        gameObject.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);

        // Dir�̏�Ԃɂ���ď�����؂�ւ�
        switch (dir)
        {
            // ��
            case Dir.Up:
                vDir.y = 1.0f;
                break;

            // ��
            case Dir.Down:
                vDir.y = -1.0f;
                break;

            default:
                break;
        }

        // �㉺�ړ�
        rb.velocity = new Vector3(rb.velocity.x, (rb.velocity.y + vDir.y) * fSpd, rb.velocity.z);
    }

    // ���]����
    private void OnTriggerEnter(Collider other)
    {
        // �^�O�u���]�ǁv�ɐG�ꂽ
        if(other.gameObject.tag == "ReverseWall")
        {
            // �G���]
            if(this.gameObject.tag == "FloatEnemyVertical")
            {
                dir++;
                if (dir > Dir.Down)
                    dir = Dir.Up;
            }
            else
            {
                dir++;
                if (dir > Dir.Right)
                    dir = Dir.Left;
            }

        }
    }
}
