using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartAnim : MonoBehaviour
{
    [SerializeField] Vector3 TargetPos;     // �ڕW�ʒu
    [SerializeField] float MoveSpeed;       // �ړ����x
    Vector3 StartPos;   // �J�n�ʒu

    [SerializeField] Quaternion TargetRot;  // ��]�p�x
    [SerializeField] float RotateSpeed;     // ��]���x
    Quaternion StartRot;    // �J�n�p�x


    [SerializeField] bool isPlaying;  // �Đ�����
    [SerializeField] bool isMoving;   // �ړ�����
    [SerializeField] bool isRotating; // ���񔻒�

    float AnimCnt;  // �J�n�A�j���[�V�����p�J�E���^

    Rigidbody rb;
    Collider col;


    private void OnDrawGizmos()
    {
        if (!isPlaying)
        {
            //----- �ړ���̕\�� -----
            CapsuleCollider capsule = GetComponent<CapsuleCollider>();
            Vector3 center = transform.position + TargetPos;
            center.y += capsule.height / 2f;
            Gizmos.color = new Color(1, 0, 0, 1);
            Gizmos.DrawWireCube(center, new Vector3(capsule.radius * 2, capsule.height, capsule.radius * 2));

            //----- ��]�p�x�̕\�� -----
            Gizmos.color = new Color(0, 0, 1, 1);
            Gizmos.DrawLine(center, center + TargetRot * Vector3.forward);
        }
    }

    void Start()
    {
        //===== �ϐ��̏����� =====
        StartPos = transform.position;
        isPlaying = false;
        isMoving = false;
        isRotating = false;
        AnimCnt = 0f;

        // �ړ�����������
        transform.LookAt(StartPos + TargetPos);
        StartRot = transform.rotation;

        // �������Z�I�t
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    void Update()
    {
        if (!isPlaying) return;

        //----- �ړ� -----
        if(isMoving)
        {
            AnimCnt = Mathf.Min(1f, AnimCnt + MoveSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(StartPos, StartPos + TargetPos, AnimCnt);
            if (AnimCnt >= 1.0f)
            {
                AnimCnt = 0f;
                isMoving = false;
                isRotating = true;

                // ����߂�
                GameObject.FindWithTag("StartPos").GetComponentInChildren<Door>().Close();
                // �J�����𓮂���
                GameObject.FindWithTag("MainCamera").GetComponent<MainCamera>().PlayStartAnim();
            }
        }

        //----- ��] -----
        else if(isRotating)
        {
            AnimCnt = Mathf.Min(1f, AnimCnt + RotateSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(StartRot, TargetRot, AnimCnt);
            if(AnimCnt >= 1.0f)
            {
                AnimCnt = 0f;
                isRotating = false;
                isPlaying = false;

                //----- �X�e�[�W�J�n���� -----
                rb.useGravity = true;
                col.enabled = true;
                GetComponent<Player>().enabled = true;
                Destroy(this);
            }
        }
    }

    
    public void Play()
    {
        isPlaying = true;
        isMoving = true;
        AnimCnt = 0f;
    }
}
