using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingCannon : MagnetType
{
    [SerializeField] private bool bMagnet;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject SBullet;
    [SerializeField] private GameObject NBullet;

    [SerializeField] private float fIntTime;
    private float fDeltaTime = 10.0f;

    private Vector3 InstPos;

    [SerializeField] private GameObject playerObj;

    [SerializeField] private GameObject BarrelObj;

    private Vector3 playerPos;
    private Vector3 calcVec;
    private Quaternion angle;
    private Vector3 eulerAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        InstPos = BarrelObj.transform.Find("LaunchPosition").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fDeltaTime += Time.deltaTime;
        playerPos = playerObj.transform.position;
        calcVec = playerPos - BarrelObj.transform.position;

        angle = Quaternion.LookRotation(calcVec);
        eulerAngle = angle.eulerAngles;
        
        if(playerObj.transform.position.x <= BarrelObj.transform.position.x)
        {
            BarrelObj.transform.localEulerAngles = new Vector3(-eulerAngle.x - 30, 0, 0);
        }
        else
        {
            BarrelObj.transform.localEulerAngles = new Vector3(150 - (-eulerAngle.x), 0, 0);
        }
        
        if (fDeltaTime >= fIntTime)
        {
            fDeltaTime = 0.0f;
            GameObject bulletObj;
            if (!bMagnet)
            {
                bulletObj = Instantiate(Bullet);
            }
            else
            {
                if (pole == POLE.N)
                {
                    bulletObj = Instantiate(NBullet);
                }
                else
                {
                    bulletObj = Instantiate(SBullet);
                }
            }
            InstPos = BarrelObj.transform.Find("LaunchPosition").transform.position;
            bulletObj.transform.position = InstPos;
            bulletObj.GetComponent<AimingBullet>().SetFireVec(playerObj.transform.position - InstPos);
        }
    }
}
