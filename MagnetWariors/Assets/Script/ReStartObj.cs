using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartObj : MonoBehaviour
{
    MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 確認
        //if (Controller.GetKeyTrigger(Controller.ControllerButton.L))
        //{
        //    mesh.enabled = false;
        //}
        //if(Controller.GetKeyTrigger(Controller.ControllerButton.R))
        //{
        //    mesh.enabled = true;
        //}
    }

    // リスタートオブジェクトの有効化
    public void ReStartObjOn()
    {
        // フェードアウトがはじまったら
        mesh.enabled = true;
    }

    // リスタートオブジェクトの無効化
    public void ReStartObjOff()
    {
        // フェードアウトが終わったら
        mesh.enabled = false;
    }
}
