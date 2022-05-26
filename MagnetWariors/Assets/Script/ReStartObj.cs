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
        
    }

    // ���X�^�[�g�I�u�W�F�N�g�̗L����
    public void ReStartObjOn()
    {
        // �I�u�W�F�N�g�\��������
        mesh.enabled = true;
    }

    // ���X�^�[�g�I�u�W�F�N�g�̖�����
    public void ReStartObjOff()
    {
        // �I�u�W�F�N�g���\���ɂ���
        mesh.enabled = false;
    }
}
