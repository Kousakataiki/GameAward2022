using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_PlayerMove : MonoBehaviour
{
    //animation���擾
    private Animator anim;
    //���W�b�h�{�f�B�̏��擾
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�A�j���[�V���� ������ݒ�
        anim.SetFloat("Speed",1);

        //�E�ɐi�ݑ�����
        transform.position += transform.forward * 3.0f * Time.deltaTime;

    }

    //�����W�����v
   public void auto_jump()
    {
        anim.SetTrigger("Jump");
        rb.velocity = new Vector3(rb.velocity.x, 5.0f, rb.velocity.z);
    }

    //�n�ʂɂ����Ƃ��A���n�̃A�j���[�V����������
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            anim.SetTrigger("Landing");
        }

        if (collision.gameObject.tag == "Box")
        {
            anim.SetTrigger("Landing");
        }
    }
}
