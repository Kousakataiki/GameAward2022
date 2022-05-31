using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private Animator anim;
    private GameObject goPlayer;
    private PlayerMove PM;
    private GameObject goRSO;
    private ReStartObj RSO;

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�V�����̃R���|�[�l���g�擾
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        PM = goPlayer.GetComponent<PlayerMove>();
    }

    public void EndFadeOutAnim()
    {
        // �t�F�[�h�A�E�g�A�j���[�V�����I��
        anim.SetBool("bStart", false);
        // �t�F�[�h�pImage������
        GetComponent<Image>().enabled = false;
        // �t�F�[�h�����t���O������
        PM.bFade = false;
    }

    public void StartFadeOut()
    {
        // ReStartObj�̃R���|�[�l���g�擾
        goRSO = GameObject.FindWithTag("ReStartObj");
        RSO = goRSO.GetComponent<ReStartObj>();

        // ���X�^�[�g�I�u�W�F�N�g�L����
        RSO.ReStartObjOn();

        // �t�F�[�h�pImage��L����
        GetComponent<Image>().enabled = true;
        // �t�F�[�h�A�j���[�V�����J�n
        anim.SetBool("bStart", true);
        // �v���C���[�X�g�b�v�t���O������
        PM.bStopPlayer = false;
    }
}
