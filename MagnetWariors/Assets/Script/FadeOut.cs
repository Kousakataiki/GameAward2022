using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private Animator anim;
    private GameObject goPlayer;
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
        
    }

    public void EndFadeOutAnim()
    {
        // �t�F�[�h�A�E�g�A�j���[�V�����I��
        anim.SetBool("bStart", false);
        // �t�F�[�h�pImage������
        GetComponent<Image>().enabled = false;
    }

    public void StartFadeOut()
    {
        // PlayerMove�̃R���|�[�l���g�擾
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        PM = goPlayer.GetComponent<PlayerMove>();
        // �t�F�[�h�pImage��L����
        GetComponent<Image>().enabled = true;
        // �t�F�[�h�A�j���[�V�����J�n
        anim.SetBool("bStart", true);
        // �v���C���[���X�^�[�g����
        PM.ReStart();
    }
}
