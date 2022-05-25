using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetReStartPos : MonoBehaviour
{
    private GameObject goRSO;
    private ReStartObj RSO;

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
        // Player���I�u�W�F�N�g�ɐG�ꂽ�烊�X�^�[�g���W�ݒ菈�������s
        // �͈͓��Ƀ^�O�uPlayer�v�����݂���
        if (coll.gameObject.tag == "Player")
        {
            // �[�[�[�[�[ ���X�^�[�g���W�ݒ菈�� �[�[�[�[�[
            coll.attachedRigidbody.GetComponent<PlayerMove>().RestartPos = this.transform.position;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        goRSO = GameObject.Find("ReStartObj");
        RSO = goRSO.GetComponent<ReStartObj>();

        if (coll.gameObject.tag == "Player")
        {
            // ���X�^�[�g�I�u�W�F�N�g�𖳌���
            RSO.ReStartObjOff();
        }

    }
}
