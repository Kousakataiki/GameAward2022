using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anten : MonoBehaviour
{
    //�C���[�W���
    Image image;

    //�^�C���J�E���g
    private float time_count;

    //���g�̓����x���l
    private float alpha_;

    // Start is called before the first frame update
    void Start()
    {
        //������
        image = gameObject.GetComponent<Image>();
        image.color = new Color(1, 1, 1, 1);
        time_count = 0;
        alpha_ = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //���Ԃ�+���Ă���
        time_count += Time.deltaTime;

        //���gf�̃J���[��ݒ�
        image.color = new Color(1, 1, 1, alpha_);

        //���ԂɂȂ�����Ó]������(���l��������)
        if (time_count > 1.0f)
        {
            alpha_ -= 0.01f;
        }

    }
}
