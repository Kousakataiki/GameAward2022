using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 
    private void OnTriggerEnter(Collider coll)
    {
        // �͈͓��Ƀ^�O�uPlayer�v�����݂���
        if (coll.gameObject.tag == "Player")
        {
            // �[�[�[�[�[ �v���C���[�̎��S�t���O��L�������� �[�[�[�[�[
            coll.attachedRigidbody.GetComponent<PlayerMove>().bDeath = true;
        }
    }
}
