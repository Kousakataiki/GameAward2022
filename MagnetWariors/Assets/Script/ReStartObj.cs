using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartObj : MonoBehaviour
{
    MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // �m�F
        //if (Controller.GetKeyTrigger(Controller.ControllerButton.L))
        //{
        //    mesh.enabled = false;
        //}
        //if(Controller.GetKeyTrigger(Controller.ControllerButton.R))
        //{
        //    mesh.enabled = true;
        //}
    }

    // ���X�^�[�g�I�u�W�F�N�g�̗L����
    public void ReStartObjOn()
    {
        // �t�F�[�h�A�E�g���͂��܂�����
        mesh.enabled = true;
    }

    // ���X�^�[�g�I�u�W�F�N�g�̖�����
    public void ReStartObjOff()
    {
        // �t�F�[�h�A�E�g���I�������
        mesh.enabled = false;
    }
}
