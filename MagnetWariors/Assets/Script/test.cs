using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Aボタンを押したら振動開始、１秒後に自動で停止
        if (Controller.GetKeyTrigger(Controller.ControllerButton.A))
        {
            Debug.Log("A");
            StartCoroutine(Controller.VibrationCor(1.0f, 0.0f, 1.0f));
            //Controller.Vibration(myclass, 1.0f, 0.0f, 1.0f);
        }

        // Bボタンを押したら振動開始
        if(Controller.GetKeyTrigger(Controller.ControllerButton.B))
        {
            Controller.Vibration(0.0f, 1.0f);
        }
        
        // Bボタンを離したら振動終了
        if(Controller.GetKeyRelease(Controller.ControllerButton.B))
        {
            Controller.Vibration(0.0f, 0.0f);
        }
    }
}
