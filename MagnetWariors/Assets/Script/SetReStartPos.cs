using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetReStartPos : MonoBehaviour
{
    //GameObject goPlayer;    // Player�I�u�W�F�N�g
    //PlayerMove pm;          // PlayerMove�̃X�N���v�g

    // Start is called before the first frame update
    void Start()
    {
        // PlayerMove.cs�̕ϐ����g�p���邽�߂�pm�ɏ����i�[���Ă���
        //goPlayer = GameObject.Find("Player");
        //pm = goPlayer.GetComponent<PlayerMove>();
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
}
