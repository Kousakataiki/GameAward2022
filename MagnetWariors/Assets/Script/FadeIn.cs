using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private Animator anim;
    private GameObject goImage;
    private FadeOut FO;
    public  bool bStartFadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void EndFadeInAnim()
    {
        // �t�F�[�h��ɍ폜
        //Destroy(this.gameObject);


        // �t�F�[�h�A�j���[�V�����I��
        anim.SetBool("bStart", false);
        // �t�F�[�h�A�E�g�J�n
        goImage = GameObject.Find("FadeOut");
        FO = goImage.GetComponent<FadeOut>();
        FO.StartFadeOut();

        // �t�F�[�h�pImage������
        GetComponent<Image>().enabled = false;
        //bStartFadeOut = true
    }

    // �t�F�[�h�C���J�n
    public void StartFadeIn()
    {
        // �t�F�[�h�pImage��L����
        GetComponent<Image>().enabled = true;
        // �t�F�[�h�A�j���[�V�����J�n
        anim.SetBool("bStart", true);
    }
}
