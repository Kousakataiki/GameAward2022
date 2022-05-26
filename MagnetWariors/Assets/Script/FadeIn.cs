using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private Animator anim;
    private Animator PlayerAnim;
    private GameObject goImage;
    private GameObject goPlayer;
    private FadeOut FO;
    private PlayerMove PM;
 
    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�V�����̃R���|�[�l���g�擾
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̃R���|�[�l���g�擾
        goPlayer = GameObject.FindWithTag("Player");
        PM = goPlayer.GetComponent<PlayerMove>();
        PlayerAnim = goPlayer.GetComponent<Animator>();
    }

    // �t�F�[�h�C���I��
    public void EndFadeInAnim()
    {   
        // �v���C���[�����X�^�[�g�ʒu�ֈړ�
        PM.ReStart();

        // �t�F�[�h�A�j���[�V�����I��
        anim.SetBool("bStart", false);
        // �[�[�[�[�[ �t�F�[�h�A�E�g�J�n �[�[�[�[�[
        // �t�F�[�h�A�E�g�̃R���|�[�l���g�擾
        goImage = GameObject.Find("FadeOut");
        FO = goImage.GetComponent<FadeOut>();
        FO.StartFadeOut();

        // �t�F�[�h�pImage������
        GetComponent<Image>().enabled = false;
    }

    // �t�F�[�h�C���J�n
    public void StartFadeIn()
    {
        // �t�F�[�h�pImage��L����
        GetComponent<Image>().enabled = true;
        // �t�F�[�h�A�j���[�V�����J�n
        anim.SetBool("bStart", true);
    }

    private void SparkAnimEnd()
    {
        // ���d�A�j���[�V�����I��
        PlayerAnim.SetBool("bElcShock", false);
    }
}
