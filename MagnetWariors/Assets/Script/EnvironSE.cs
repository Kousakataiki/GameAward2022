using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironSE : MonoBehaviour
{
    enum enviroSound
    {
        SE_Gear,
        SE_Vapor,
        SE_WaterFall
    };

    [SerializeField] private enviroSound SelectSE;

    // Start is called before the first frame update
    void Start()
    {
        if(SelectSE == enviroSound.SE_Gear)
        {
            AudioManager.instance.BGMStart("SE_Gear");
        }
        else if(SelectSE == enviroSound.SE_Vapor)
        {
            AudioManager.instance.BGMStart("SE_VaporLong");
        }
        else if(SelectSE == enviroSound.SE_WaterFall)
        {
            AudioManager.instance.BGMStart("SE_WaterFall");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (SelectSE == enviroSound.SE_Gear)
        {
            AudioManager.instance.BGMStop("SE_Gear");
        }
        else if (SelectSE == enviroSound.SE_Vapor)
        {
            AudioManager.instance.BGMStop("SE_VaporLong");
        }
        else if (SelectSE == enviroSound.SE_WaterFall)
        {
            AudioManager.instance.BGMStop("SE_WaterFall");
        }
    }
}
