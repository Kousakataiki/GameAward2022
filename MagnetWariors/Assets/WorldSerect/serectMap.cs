using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class serectMap : MonoBehaviour
{
    //ƒ[ƒvæ‚Ì”­“dŠ
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


    private bool FireClearFlag;
    private bool WaterClearFlag;
    private bool NuclearCllearFlag;

    private Vector2 Lstick;

    private SerectMap serect;

    // Start is called before the first frame update
    void Start()
    {
        serect = SerectMap.Wind;

        FireClearFlag = true;
        WaterClearFlag = true;
        NuclearCllearFlag = true;

    }

    // Update is called once per frame
    void Update()
    {
        Lstick = Controller.StickValue(Controller.ControllerStick.LStick);

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
}
