using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PushBotton_Blinking : MonoBehaviour
{

    //�C���[�W���
    Image image;

    //�^�C���J�E���g
    private float time_count;

    //���g�̓����x���l
    private float alpha_;

    //�_�Ŕ��]�t���O
    private bool Blinking_flag;

    //�����x�̗�
    private float alpha_value;


    // Start is called before the first frame update
    void Start()
    {
        //������
        image = gameObject.GetComponent<Image>();
        image.color = new Color(1, 1, 1, 0);
        time_count = 0;
        alpha_ = 0;
        Blinking_flag = false;
        alpha_value = 0.03f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //���Ԃ�+���Ă���
        time_count += Time.deltaTime;
        

        //���gf�̃J���[��ݒ�
        image.color = new Color(1, 1, 1, alpha_);

        //�_�Ŕ��]�t���O��false�̎��A�����x�𑫂��Ă���
        if (Blinking_flag == false)
        {
            alpha_ += alpha_value;
        }

        //�_�Ŕ��]�t���O��true�̎��A�����x�����炷
        if (Blinking_flag == true)
        {
            alpha_ -= alpha_value;
        }

        //�����x��1 �܂��� 0��������t���O���]
        if (alpha_ <= 0 || alpha_ >= 1)
        {
            Blinking_flag = !Blinking_flag;
        }
    }
    private void Update()
    {
        if (Controller.GetKeyPress(Controller.ControllerButton.B))
        {
            //�V�[���ǂݍ���
            SceneManager.LoadScene("WorldSerect");
        }

    }
}
