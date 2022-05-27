using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    private int ClearStageState;

    // Start is called before the first frame update
    void Awake()
    {
        SaveData.StartUpSaveData();
    }

    void Start()
    {
        ClearStageState = SaveData.GetClearState();
        Debug.Log("StageState" + ClearStageState);    
    }

    // Update is called once per frame
    void Update()
    {
        if(Controller.GetKeyPress(Controller.ControllerButton.Select)&&Controller.GetKeyTrigger(Controller.ControllerButton.RStick))
        {
            SaveData.DeleteClearState();
            ClearStageState = SaveData.GetClearState();
            Debug.Log("StageState" + ClearStageState);
        }

        if(Controller.GetKeyRelease(Controller.ControllerButton.X))
        {
            SaveData.UpdateClearState(ClearStageState + 1);
            ClearStageState = SaveData.GetClearState();
            Debug.Log("StageState" + ClearStageState);
        }
    }
}
