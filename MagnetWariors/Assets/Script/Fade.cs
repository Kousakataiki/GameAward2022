using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    private static bool isFadeOut = false;
    private static bool isFadeIn = true;
    private bool bFade = false;
    public float fadeSpeed = 1f;
    public GameObject ImageObj;
    public Image fadeImage;
    static float red, green, blue, alfa;
    string afterScene;

    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += fadeInStart;
    }

    void fadeInStart(Scene scene, LoadSceneMode mode)
    {
        isFadeIn = true;
    }
    
    public void fadeOutStart(int red, int green, int blue, int alfa, string nextScene)
    {
        if (!bFade)
        {
            ImageObj.SetActive(true);
            SetRGBA(red, green, blue, alfa);
            SetColor();
            isFadeOut = true;
            bFade = true;
            afterScene = nextScene;
        }
    }
    
    void Update()
    {
        if (isFadeIn == true)
        {
            alfa -= fadeSpeed * Time.deltaTime;

            SetColor();
            if (alfa <= 0)
            {
                isFadeIn = false;
                ImageObj.SetActive(false);   
            }
        }
        if (isFadeOut == true)
        {

            alfa += fadeSpeed * Time.deltaTime;
 
            SetColor();
            if (alfa >= 1)
            {
                isFadeOut = false;
                bFade = false;
                Debug.Log("After" + afterScene);
                SceneManager.LoadScene(afterScene);
            }
        }
    }
    void SetColor()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
    public void SetRGBA(int r, int g, int b, int a)
    {
        red = r;
        green = g;
        blue = b;
        alfa = a;
    }
    public static bool GetFadeInState()
    {
        return isFadeIn;
    }
}

