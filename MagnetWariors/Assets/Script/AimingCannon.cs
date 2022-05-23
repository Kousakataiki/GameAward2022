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

    // Start is called before the first frame update
    void Start()
    {
        InstPos = transform.Find("LaunchPosition").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fDeltaTime += Time.deltaTime;
        if (fDeltaTime >= fIntTime)
        {
            fDeltaTime = 0.0f;
            GameObject bulletObj;
            if (!bMagnet)
            {
                Debug.Log("Fire");
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
            bulletObj.transform.position = InstPos;
            bulletObj.GetComponent<AimingBullet>().SetFireVec(playerObj.transform.position - InstPos);
        }
    }
}
