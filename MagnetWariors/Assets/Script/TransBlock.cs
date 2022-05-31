using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransBlock : MonoBehaviour
{
    private bool bValid = false;
    private bool bSwitch = false;

    [SerializeField] private GameObject LeverObj;
    [SerializeField] private GameObject CenterObj;

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
        if(bSwitch)
        {
            LeverObj.transform.RotateAround(CenterObj.transform.position, Vector3.forward, -50);
        }
        else
        {
            LeverObj.transform.RotateAround(CenterObj.transform.position, Vector3.forward, 50);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetKeyTrigger(Controller.ControllerButton.B))
        {
            if (!bValid)
            {
                // プレイヤーのPositionを取得
                Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
                // プレイヤーとの距離を計算
                float dis = Vector3.Distance(transform.position, playerPos);

                if (dis <= range)
                {
                    bValid = true;
                    if (bSwitch)
                    {
                        bSwitch = false;
                        Debug.Log("OFF");
                        for (int i = 0; i < magnetObjList.Count; i++)
                        {
                            magnetObjList[i].SetActive(false);
                        }
                    }
                    else
                    {
                        bSwitch = true;
                        Debug.Log("ON");
                        for (int i = 0; i < magnetObjList.Count; i++)
                        {
                            magnetObjList[i].SetActive(true);
                        }
                    }
                    AudioManager.instance.Play("SE_Lever");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (bValid)
        {
            if (bSwitch)
            {
                Debug.Log("Angle" + LeverObj.transform.localEulerAngles.z);
                LeverObj.transform.RotateAround(CenterObj.transform.position, Vector3.forward, -100 * Time.deltaTime);
                if (LeverObj.transform.localEulerAngles.z <= 310 && LeverObj.transform.localEulerAngles.z >= 300)
                {
                    bValid = false;
                }
            }
            else
            {
                Debug.Log("Angle" + LeverObj.transform.localEulerAngles.z);
                LeverObj.transform.RotateAround(CenterObj.transform.position, Vector3.forward, +100 * Time.deltaTime);
                if (LeverObj.transform.localEulerAngles.z >= 50 && LeverObj.transform.localEulerAngles.z <= 60)
                {
                    bValid = false;
                }
            }
        }
    }
}
