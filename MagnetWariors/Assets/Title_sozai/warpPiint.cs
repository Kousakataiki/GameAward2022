using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpPiint : MonoBehaviour
{

    //���[�v��̔��d��
    private enum WarpName
    {
        Wind,
        Fire,
        Water,
        Nuclear,
    }

    //�q�G�����L�[�Ń��[�v��I��
    [SerializeField]
    private WarpName warpName;


    public Material Fire_material;


    public Material sky;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���[�v�u���b�N�̃R���C�_�[�ƃv���C���[�����������Ƃ�
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch (warpName)
            {
                //���͔��d���ɃL�������΂�
                case WarpName.Wind:
                    other.transform.position = new Vector3(04.7f,-1.28f,-2.85f);
                    break;
                //�Η͔��d���ɃL�������΂�
                case WarpName.Fire:
                    other.transform.position = new Vector3(-4.7f, -1.28f, 317.78f);
                    RenderSettings.skybox = Fire_material;
                    break;
                //���͔��d���ɃL�������΂�
                case WarpName.Water:
                    other.transform.position = new Vector3(-4.7f, -1.28f, 942.78f);
                    RenderSettings.skybox = Fire_material;
                    break;
                //���q�͔��d���ɃL�������΂�
                case WarpName.Nuclear:
                    other.transform.position = new Vector3(-4.7f, -1.28f, 1493.84f);
                    RenderSettings.skybox = Fire_material;
                    break;
            }
        }
    }
}
