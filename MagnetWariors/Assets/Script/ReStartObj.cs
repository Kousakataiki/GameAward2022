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
        
    }

    // リスタートオブジェクトの有効化
    public void ReStartObjOn()
    {
        // オブジェクト表示させる
        mesh.enabled = true;
    }

    // リスタートオブジェクトの無効化
    public void ReStartObjOff()
    {
        // オブジェクトを非表示にする
        mesh.enabled = false;
    }
}
