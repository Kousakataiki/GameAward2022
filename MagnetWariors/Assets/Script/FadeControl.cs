using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �����ɂȂ��Ă���Image��L����
        GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�����񂾂�t�F�[�h�p�l����L����
    }

    public void EndFadeInAnimation()
    {
        // �t�F�[�h��ɍ폜
        Destroy(this.gameObject);
    }

    public void EndFadeOutAnim()
    {
        // �t�F�[�h��ɍ폜
        Destroy(this.gameObject);
    }
}
