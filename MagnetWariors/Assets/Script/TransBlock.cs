using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransBlock : MonoBehaviour
{
    private bool bValid = false;
    private bool bSwitch = false;

    [SerializeField] List<GameObject> magnetObjList;
    [SerializeField] private bool bFirst;
    [SerializeField] float range;

    public void Awake()
    {
        for(int i = 0; i<magnetObjList.Count;i++)
        {
            magnetObjList[i].SetActive(bFirst);
        }
        bSwitch = bFirst;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetKeyTrigger(Controller.ControllerButton.B))
        {
            // プレイヤーのPositionを取得
            Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
            // プレイヤーとの距離を計算
            float dis = Vector3.Distance(transform.position, playerPos);

            if (dis <= range)
            {
                if (bSwitch)
                {
                    bSwitch = false;
                    for(int i = 0;i<magnetObjList.Count;i++)
                    {
                        magnetObjList[i].SetActive(false);
                    }
                }
                else
                {
                    bSwitch = true;
                    for (int i = 0; i < magnetObjList.Count; i++)
                    {
                        magnetObjList[i].SetActive(true);
                    }
                }
            }
        }
    }
}
