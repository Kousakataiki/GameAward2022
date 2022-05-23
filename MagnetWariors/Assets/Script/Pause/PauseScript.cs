using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    //�@�|�[�Y�������ɕ\������UI
    [SerializeField]
    private GameObject pauseUI;

    //�@�Q�[���ĊJ�{�^��
    [SerializeField]
    private GameObject ContinueButton;

    public void StopGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ReStartGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetKeyTrigger(Controller.ControllerButton.Start))
        {
            // �|�[�YUI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�
            StopGame();
        }
    }
}
