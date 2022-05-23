using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SmokeUIManager : MonoBehaviour
{
    //�O���[�o��
    static public bool isSmokeNow = false;

    //�ϐ�
    [SerializeField] GameObject[] SumokeEffects;        //���I�u�W�F�N�g�Q
    [SerializeField] GameObject   SumokeTimeEffect;     //���I�u�W�F�N�g�Q

    [SerializeField] bool   isSmoke = false;         //�����o�m�F
    [SerializeField] int    LiberationMapNum;             //�X�e�[�W�̊J����
    [SerializeField] float  SmokeTimer;                  //�X�e�[�W�̊J����

    // Start is called before the first frame update
    void Start()
    {
        initSumokeTime();
    }

    // Update is called once per frame
    void Update()
    {
        updateSumokeTime();
    }

    //�X���[�N���o������
    void initSumokeTime()
    {
        ////�\�����Ȃ����ׂĖ���
        //for(int i = 0; i < SumokeEffects.Length; ++i)
        //{
        //    SumokeEffects[i].SetActive(false);
        //}

        //�����X���[�N��I��
        SumokeTimeEffect = SumokeEffects[0];
 
        //���������[�h�L����
        isSmokeNow = true;
        isSmoke = isSmokeNow;   //�C���X�y�N�^�[�m�F�p

        //VFX�擾
        VisualEffect SumokeVFX = SumokeTimeEffect.GetComponent<VisualEffect>();
        //���[�g��0�ɂ���
        SumokeVFX.SetInt("rate", 0);
    }

    //�X���[�N���o�X�V
    void updateSumokeTime()
    {
        //���o���łȂ���΃X�L�b�v
        if (!isSmokeNow)
            return;

        //�X���[�N�^�C�}�[�X�V
        SmokeTimer -= Time.deltaTime;

        //���Ԃ��߂�����
        if (SmokeTimer < 0)
        {
            //���o�̏I������X���[�N������
            SumokeTimeEffect.SetActive(false);

            //�t���O��ύX
            isSmokeNow = false;
            isSmoke = isSmokeNow;

        }
    }

}
