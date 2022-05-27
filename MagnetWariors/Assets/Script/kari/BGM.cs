using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] string bgmname = "BGM_Stage1";

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.BGMStart(bgmname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
