using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    [SerializeField] private Transform Self;
    [SerializeField] private Transform Target;

    // �͈͓��Ƀ^�[�Q�b�g�������Ă��邩
    public bool bJoin;

    // Start is called before the first frame update
    void Start()
    {
        bJoin = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �^�[�Q�b�g���͈͓��Ȃ�
        if(bJoin)
        {
            // �^�[�Q�b�g�̕����Ɏ��g����]������
            Self.LookAt(Target);
            //Self.transform.localScale = this.transform.localScale;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �͈͓��Ƀ^�O�uPlayer�v�����݂���
        if (other.gameObject.tag == "Player")
        {
            bJoin = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �͈͓��Ƀ^�O�uPlayer�v�����݂��Ȃ��Ȃ���
        if (other.gameObject.tag == "Player")
        {
            bJoin = false;
        }
    }
}
