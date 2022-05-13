using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMagnet : MagnetType
{
    private MagnetWall magnet;
    [SerializeField] private float ChangeTime;
    private float countTimer = 0.0f;
    private Renderer rend;

    [SerializeField] private Material Nmat;
    [SerializeField] private Material Smat;

    // Start is called before the first frame update
    void Start()
    {
        magnet = GetComponent<MagnetWall>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countTimer += Time.deltaTime;
        if(countTimer >= ChangeTime)
        {
            if(magnet.pole == POLE.N)
            {
                magnet.pole = POLE.S;
                rend.material = Smat;
            }
            else
            {
                magnet.pole = POLE.N;
                rend.material = Nmat;
            }
            countTimer = 0.0f;
        }
    }
}
