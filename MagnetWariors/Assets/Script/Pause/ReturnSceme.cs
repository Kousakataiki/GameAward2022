using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnSceme : MonoBehaviour
{
    [SerializeField] private string SceneName;

    public void ButtonClicked()
    {
        SceneManager.LoadScene(SceneName);
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
