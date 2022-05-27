using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagnet : MagnetType
{
    private GameObject MagnetObj;
    private Rigidbody rb;

    private bool bN = false, bS = false;

    private float Namount = 100.0f, Samount = 100.0f;

    private Slider Nbar;
    private Slider Sbar;

    private float NuseTime = 0.0f;
    private float SuseTime = 0.0f;
    private float NTimer = 0.0f;
    private float STimer = 0.0f;

    private float RimitHeight = 1.005f;

    private float SpendAmount;
    private float HealAmount;

    private bool bRemove = false;
    private bool bRemoveProcess = false; 

    private void Awake()
    {
        //Nbar = GameObject.Find("Nbar").GetComponent<Slider>();
        //Sbar = GameObject.Find("Sbar").GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Namount = VariableManager.MaxMagnetAmount_s;
        Samount = VariableManager.MaxMagnetAmount_s;
        RimitHeight = VariableManager.RimitHeight_s;
        SpendAmount = VariableManager.SpendMagnetAmount_s;
        HealAmount = VariableManager.HealMagnetAmount_s;
        MagnetObj = transform.Find("Magnet").gameObject; 
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bRemove)
        {
            bRemove = false;
        }
        else
        {
            if(bRemoveProcess)
            {
                if(rb.velocity.y >= 0)
                {
                    rb.velocity /= RimitHeight;
                    if (rb.velocity.magnitude <= 1)
                        bRemoveProcess = false;
                    rb.useGravity = true;
                }
            }
        }

        if(Controller.GetKeyTrigger(Controller.ControllerButton.L))
        {
            if (!bS && Namount > 0)
            {
                MagnetObj.SetActive(true);
                bN = true;
                pole = POLE.N;
                AudioManager.instance.Play("PlayerMagnet");
            }
        }

        if(Controller.GetKeyPress(Controller.ControllerButton.L))
        {
            if(bN)
            {
                if(Namount <= 0)
                {
                    bN = false;
                    MagnetObj.SetActive(false);
                    rb.useGravity = true;
                }
            }
        }
        
        if (Controller.GetKeyRelease(Controller.ControllerButton.L))
        {
            if (bN)
            {
                MagnetObj.SetActive(false);
                bN = false;
                rb.useGravity = true;
            }
        }

        if (Controller.GetKeyTrigger(Controller.ControllerButton.R))
        {
            if (!bN && Samount >0)
            {
                MagnetObj.SetActive(true);
                bS = true;
                pole = POLE.S;
                AudioManager.instance.Play("PlayerMagnet");
            }
        }

        if (Controller.GetKeyPress(Controller.ControllerButton.R))
        {
            if (bS)
            {
                if (Samount <= 0)
                {
                    bS = false;
                    MagnetObj.SetActive(false);
                    rb.useGravity = true;
                }
            }
        }

        if (Controller.GetKeyRelease(Controller.ControllerButton.R))
        {
            if (bS)
            {
                MagnetObj.SetActive(false);
                bS = false;
                rb.useGravity = true;
            }
        }

        if(!bS)
        {
            if (Samount < 100)
            {
                STimer += Time.deltaTime;
                if (STimer >= 0.5f)
                {
                    Samount += HealAmount;
                    STimer = 0.0f;
                }
            }
            SuseTime = 0.0f;
        }
        else
        {
            SuseTime += Time.deltaTime;
            if (SuseTime >= 0.5f)
            {
                Samount -= SpendAmount;
                if (Samount < 0)
                    Samount = 0;
                SuseTime = 0.0f;
            }
            STimer = 0.0f;
        }

        if(!bN)
        {
            if (Namount < 100.0f)
            {
                NTimer += Time.deltaTime;
                if (NTimer >= 0.5f)
                {
                    Namount += HealAmount;
                    NTimer = 0.0f;
                }
            }
            NuseTime = 0.0f;
        }
        else
        {
            NuseTime += Time.deltaTime;
            if (NuseTime >= 0.5f)
            {
                Namount -= SpendAmount;
                if (Namount < 0)
                    Namount = 0;
                NuseTime = 0.0f;
            }
            NTimer = 0.0f;
        }

        //Nbar.value = Namount;
        //Sbar.value = Samount;
    }

    public void RemoveMagnetWall()
    {
        bRemove = true;
        bRemoveProcess = true;
    }

    public bool MagnetUse()
    {
        if(bS || bN)
        {
            return true;
        }

        return false;
    }
}
