using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    PlayerMove move;
    PlayerMagnet magnet;

    AudioSource audio;

    public GameObject res;

    [SerializeField] GameObject panel;
    [SerializeField] Text text;

    void OnEnable()
    {
        if(move == null)     move = this.gameObject.AddComponent<PlayerMove>();
        if(magnet == null)   magnet = this.gameObject.AddComponent<PlayerMagnet>();
        if(audio == null)    audio = this.gameObject.AddComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y <= -5.0f &&
            GameObject.Find("black(Clone))") == null)
            {
            Instantiate(res, transform.position,
                Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        Destroy(GameObject.FindWithTag("MainCamera").GetComponent<MainCamera>());
        panel.SetActive(true);
        text.text = "Game Over";
    }
}
