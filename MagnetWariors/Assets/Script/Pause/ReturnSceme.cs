using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnSceme : MonoBehaviour
{
    public void ButtonClicked()
    {
        SceneManager.LoadScene("World_1"); // (" ここの中にステージシーン名を入力 ")
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
