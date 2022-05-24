using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Litnig : MonoBehaviour
{
    //----�ϐ��錾
    //���J�ϐ�
    [SerializeField] float ChangeSpeed = 1.0f;
    [SerializeField] int   seedValue = 0;
    //�����ϐ�
    [SerializeField] private float ChengeTime = 0.0f;

    [SerializeField] float setPos;
    [SerializeField] float setSize;

    //�}�e���A��
    private Material mat;

    private void Start()
    {
        //�}�e���A���̎擾
        mat = GetComponent<Renderer>().material;
    }


    // Update is called once per frame
    void Update()
    {
        //���Ԃ̍X�V
        ChengeTime += Time.deltaTime;

        if (ChangeSpeed < ChengeTime)
        {
            //�ʒu�̌���
            setPos = Random.value;
            mat.SetFloat("_UVPos", setPos);

            //�T�C�Y�̌���
            setSize = 0.01f + Random.value / 2; 
            mat.SetFloat("_UVSize", setSize);

            //���Ԃ�Reset
            ChengeTime = 0.0f;
        }
    }
}
