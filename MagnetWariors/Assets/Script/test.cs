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
        // A�{�^������������U���J�n�A�P�b��Ɏ����Œ�~
        if (Controller.GetKeyTrigger(Controller.ControllerButton.A))
        {
            Debug.Log("A");
            StartCoroutine(Controller.VibrationCor(1.0f, 0.0f, 1.0f));
            //Controller.Vibration(myclass, 1.0f, 0.0f, 1.0f);
        }

        // B�{�^������������U���J�n
        if(Controller.GetKeyTrigger(Controller.ControllerButton.B))
        {
            Controller.Vibration(0.0f, 1.0f);
        }
        
        // B�{�^���𗣂�����U���I��
        if(Controller.GetKeyRelease(Controller.ControllerButton.B))
        {
            Controller.Vibration(0.0f, 0.0f);
        }
    }
}
