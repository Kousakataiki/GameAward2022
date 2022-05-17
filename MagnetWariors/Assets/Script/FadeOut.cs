using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�����񂾂�A�����ɂȂ��Ă���Image��L����
        //if()
        //{
        //      GetComponent<Image>().enabled = true;
        //}
    }

    public void EndFadeOutAnim()
    {
        // �t�F�[�h��ɍ폜
        //Destroy(this.gameObject);

        // �t�F�[�h�A�E�g�A�j���[�V�����I��
        anim.SetBool("bStart", false);
        GetComponent<Image>().enabled = false;
    }

    public void StartFadeOut()
    {
        GetComponent<Image>().enabled = true;
        anim.SetBool("bStart", true);
    }
}
