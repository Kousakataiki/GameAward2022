using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpPiint : MonoBehaviour
{

    //ワープ先の発電所
    private enum WarpName
    {
        Wind,
        Fire,
        Water,
        Nuclear,
    }

    //ヒエラルキーでワープ先選択
    [SerializeField]
    private WarpName warpName;


    public Material Fire_material;


    public Material sky;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ワープブロックのコライダーとプレイヤーがあたったとき
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch (warpName)
            {
                //風力発電所にキャラを飛ばす
                case WarpName.Wind:
                    other.transform.position = new Vector3(04.7f,-1.28f,-2.85f);
                    break;
                //火力発電所にキャラを飛ばす
                case WarpName.Fire:
                    other.transform.position = new Vector3(-4.7f, -1.28f, 317.78f);
                    RenderSettings.skybox = Fire_material;
                    break;
                //水力発電所にキャラを飛ばす
                case WarpName.Water:
                    other.transform.position = new Vector3(-4.7f, -1.28f, 942.78f);
                    RenderSettings.skybox = Fire_material;
                    break;
                //原子力発電所にキャラを飛ばす
                case WarpName.Nuclear:
                    other.transform.position = new Vector3(-4.7f, -1.28f, 1493.84f);
                    RenderSettings.skybox = Fire_material;
                    break;
            }
        }
    }
}
