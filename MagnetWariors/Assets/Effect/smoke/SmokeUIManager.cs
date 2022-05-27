using UnityEngine;
using UnityEngine.VFX;

public class SmokeUIManager : MonoBehaviour
{
    //�O���[�o��
    static private bool isSmokeNow = false;


    //�ϐ�
    [SerializeField] GameObject[] SumokeEffects;        //���I�u�W�F�N�g�Q
    [SerializeField] GameObject   SumokeTimeEffect;     //���I�u�W�F�N�g�Q
    [SerializeField] VisualEffect SumokeVFX;            //VFX

    [SerializeField] bool   isSmoke = false;            //�����o�m�F
    [SerializeField] int    LiberationWorldState;       //�X�e�[�W�̊J����
    [SerializeField] int    LiberationWorldMapState;    //�X�e�[�W�̊J����
    [SerializeField] float  SmokeTimer;                 //�X�e�[�W�̊J����

    [SerializeField] int    rateCounter;
    [SerializeField] int    liberationMapState;


    // Start is called before the first frame update
    void Start()
    {
    isSmokeNow = false;
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
        //�N���A���擾
        int LiberationMapState  = SaveData.GetClearState();
        LiberationWorldState    = liberationMapState / 8;
        LiberationWorldMapState = liberationMapState % 8;

        //�\�����Ȃ����ׂĖ���
        for (int i = 0; i < LiberationWorldState; ++i)
        {
            SumokeEffects[i].SetActive(false);
        }

        //���o���Ȃ��Ă����Ƃ�����
        if (!(LiberationWorldMapState == 0) || LiberationWorldState == 0)
        {
            return;
        }
        


        //�����X���[�N��I��
        SumokeTimeEffect = SumokeEffects[LiberationWorldState - 1];

        //�����X���[�N��L����
        SumokeTimeEffect.SetActive(true);

        //���������[�h�L����
        isSmokeNow = true;
        isSmoke = isSmokeNow;   //�C���X�y�N�^�[�m�F�p

        //VFX�擾
        SumokeVFX = SumokeTimeEffect.GetComponent<VisualEffect>();
        

        //���������ɉ���ǉ�


    }

    //�X���[�N���o�X�V
    void updateSumokeTime()
    {
        //���o���łȂ���΃X�L�b�v
        if (!isSmokeNow)
            return;

        //���[�g�^�C�}�[��0�ɂȂ����烌�[�g��0�ɂ���
        if (rateCounter<0)
            SumokeVFX.SetInt("rate", 0);
        else
            rateCounter--;


        //���Ԃ��߂�����
        if (SmokeTimer < 0)
        {
            //���o�̏I������X���[�N������
            SumokeTimeEffect.SetActive(false);

            //�t���O��ύX
            isSmokeNow = false;
            isSmoke = isSmokeNow;

        }
        else
        {
            //�X���[�N�^�C�}�[�X�V
            SmokeTimer -= Time.deltaTime;
        }
    }


    static public  bool getSmokeEffectNow()
    {
        return isSmokeNow;
    }
}
