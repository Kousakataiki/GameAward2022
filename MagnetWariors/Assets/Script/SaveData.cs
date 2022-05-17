using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    private static int ClearState;

    public static void StartUpSaveData()
    {
        if(PlayerPrefs.HasKey("Init"))
        {
            ClearState = PlayerPrefs.GetInt("ClearState");
        }
        else
        {
            PlayerPrefs.SetString("Init", "Init");
            ClearState = 0;
            PlayerPrefs.SetInt("ClearState", ClearState);
            PlayerPrefs.Save();
        }
    }

    public static void UpdateClearState(int StageNum)
    {
        if(ClearState <= StageNum)
            ClearState = StageNum;

        PlayerPrefs.SetInt("ClearState", ClearState);
        PlayerPrefs.Save();
    }

    public static int GetClearState()
    {
        return ClearState;
    }

    public static void DeleteClearState()
    {
        PlayerPrefs.DeleteAll();
        StartUpSaveData();
    }
}
