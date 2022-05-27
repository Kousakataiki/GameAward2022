using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MagnetType
{
    [SerializeField] private bool bMagnet;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject SBullet;
    [SerializeField] private GameObject NBullet;

    [SerializeField] private float fIntTime;
    private float fDeltaTime = 10.0f;

    private Vector3 InstPos;

    [SerializeField] private Bullet.Vec vec;

    [SerializeField] private GameObject BarrelObj;

    // Start is called before the first frame update
    void Start()
    {
        if(vec == global::Bullet.Vec.Left)
        {
            BarrelObj.transform.localEulerAngles = new Vector3(-30, 0, 0);
        }
        else if(vec == global::Bullet.Vec.Right)
        {
            BarrelObj.transform.localEulerAngles = new Vector3(150, 0, 0);
        }
        else if (vec == global::Bullet.Vec.Up)
        {
            BarrelObj.transform.localEulerAngles = new Vector3(60, 0, 0);
        }
        else if (vec == global::Bullet.Vec.Down)
        {
            BarrelObj.transform.localEulerAngles = new Vector3(60, 0, 0);
        }
        InstPos = BarrelObj.transform.Find("LaunchPosition").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fDeltaTime += Time.deltaTime;
        if(fDeltaTime >= fIntTime)
        {
            fDeltaTime = 0.0f;
            if(!bMagnet)
            {
                Debug.Log("Fire");
                GameObject bulletObj = Instantiate(Bullet);
                bulletObj.transform.position = InstPos;
                bulletObj.GetComponent<Bullet>().SetFireVec(vec);
            }
            else
            {
                if(pole == POLE.N)
                {
                    GameObject bulletObj = Instantiate(NBullet);
                    bulletObj.transform.position = InstPos;
                    bulletObj.GetComponent<Bullet>().SetFireVec(vec);
                }
                else
                {
                    GameObject bulletObj = Instantiate(SBullet);
                    bulletObj.transform.position = InstPos;
                    bulletObj.GetComponent<Bullet>().SetFireVec(vec);
                }
            }
        }
    }
}
