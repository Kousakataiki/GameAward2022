using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class serectMap : MonoBehaviour
{
    //���[�v��̔��d��
    private enum SerectMap
    {
        Wind,
        Fire,
        Water,
        Nuclear,
    }

    public GameObject WindSprite;
    public GameObject FireSprite;
    public GameObject WaterSprite;
    public GameObject NuclerSprite;

    [SerializeField] SerectMap serect;
    
    //�Z���N�g�I�𒆕\��
    [SerializeField] GameObject[] mapTex;
    private const int mapNum = 4;
    private Material[] mapTexMat;


    private bool FireClearFlag;
    private bool WaterClearFlag;
    private bool NuclearCllearFlag;

    private Vector2 Lstick;


    // Start is called before the first frame update
    void Start()
    {
        serect = SerectMap.Wind;

        FireClearFlag = true;
        WaterClearFlag = true;
        NuclearCllearFlag = true;

        //Material�̎擾
        mapTexMat = new Material[mapTex.Length];
        for (int i = 0; i < mapTex.Length; ++i)
        {
            mapTexMat[i] = mapTex[i].GetComponent<Image>().material;
        }

        //�}�b�v�̋����\��
        selectMap((int)serect);
    }

    // Update is called once per frame
    void Update()
    {
        //smoke���o����Ă����
        if (SmokeUIManager.getSmokeEffectNow())
            return;

        Lstick = Controller.StickValue(Controller.ControllerStick.LStick);
       
        //�}�b�v�̋����\��
        selectMap((int)serect);
        //setcolor();

        switch (serect)
        {
            case SerectMap.Wind:


                if (Controller.GetKeyTrigger(Controller.ControllerButton.A))
                {
                    SceneManager.LoadScene("World_1");
                }

                WindSprite.SetActive(true);
                FireSprite.SetActive(false);
                WaterSprite.SetActive(false);
                NuclerSprite.SetActive(false);

                if (Lstick.y >= 0.1f && FireClearFlag == true)
                {
                    serect = SerectMap.Fire;
                }

                if (Lstick.x >= 0.1f && NuclearCllearFlag == true)
                {
                    serect = SerectMap.Nuclear;
                }

                break;

            case SerectMap.Fire:

                if (Controller.GetKeyTrigger(Controller.ControllerButton.A))
                {
                    SceneManager.LoadScene("");
                }

                WindSprite.SetActive(false);
                FireSprite.SetActive(true);
                WaterSprite.SetActive(false);
                NuclerSprite.SetActive(false);

                if (Lstick.y <= -0.1f)
                {
                    serect = SerectMap.Wind;
                }

                if (Lstick.x >= 0.1f && WaterClearFlag == true)
                {
                    serect = SerectMap.Water;
                }

                break;

            case SerectMap.Water:

                if (Controller.GetKeyTrigger(Controller.ControllerButton.A))
                {
                    SceneManager.LoadScene("World_3");
                }

                WindSprite.SetActive(false);
                FireSprite.SetActive(false);
                WaterSprite.SetActive(true);
                NuclerSprite.SetActive(false);

                if (Lstick.y <= -0.1f && NuclearCllearFlag == true)
                {
                    serect = SerectMap.Nuclear;
                }

                if (Lstick.x <= -0.1f && FireClearFlag == true)
                {
                    serect = SerectMap.Fire;
                }

                break;

            case SerectMap.Nuclear:

                if (Controller.GetKeyTrigger(Controller.ControllerButton.A))
                {
                    SceneManager.LoadScene("");
                }

                WindSprite.SetActive(false);
                FireSprite.SetActive(false);
                WaterSprite.SetActive(false);
                NuclerSprite.SetActive(true);

                if (Lstick.y >= 0.1f)
                {
                    serect = SerectMap.Water;
                }

                if (Lstick.x <= -0.1f)
                {
                    serect = SerectMap.Wind;
                }

                break;

        }

    }

    //�}�b�v�̑I���󋵕ύX�֐�
    void selectMap(int MapNum)
    {
        //��x�S�Ă𖳌���
        for (int i = 0; i < mapTexMat.Length; ++i)
        {
            mapTexMat[i].SetInt("_mode", 0);
        }
        //�I�������}�b�v��L����
        mapTexMat[MapNum].SetInt("_mode", 1);
    }

    static float colorTime;
    [SerializeField] float intensity = 2.0f;
    [SerializeField] float intensityPow = 2.0f;
    [SerializeField] Color selectColor;
    void setcolor()
    {

        //���Ԃ̍X�V
        colorTime += Time.deltaTime;

        //�ύX���e�錾
        mapTexMat[mapNum].EnableKeyword("_EMISSION");

        //�ύX���鋭�����v�Z
        float colorPower = intensity + (Mathf.Sin(colorTime * intensityPow) + 1.0f) / 2.0f;

        //���x���v�Z
        float factor = Mathf.Pow(2, colorPower);

        //�F���w��
        mapTexMat[mapNum].SetColor("_Color",
            new Color(
                selectColor.r * factor, 
                selectColor.g * factor, 
                selectColor.b * factor
                ));

    }

}
