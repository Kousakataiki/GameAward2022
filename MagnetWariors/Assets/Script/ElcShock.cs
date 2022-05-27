using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElcShock : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        // �v���C���[���G�ꂽ
        if (coll.gameObject.tag == "Player")
        {
            // �A�j���[�V�����Đ����͔�����s��Ȃ�
            if(!coll.GetComponent<PlayerMove>().bSpark)
            {
                // �A�j���[�V�������s���t���O�L����
                coll.GetComponent<PlayerMove>().bSpark = true;
                // �v���C���[�̃R���|�[�l���g�擾
                anim = coll.gameObject.GetComponent<Animator>();
                //anim.SetTrigger("ElcShock");
                // ���d�A�j���[�V�����t���O�L�������A�j���[�V�����J�n
                anim.SetBool("bElcShock", true);
                // �v���C���[��~�t���O�L����
                anim.GetComponent<PlayerMove>().bStopPlayer = true;
            }
        }
    }
}
