using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MagnetType
{
    private float fDeltaTime;
    [SerializeField] private float fEraseTime;

    private Rigidbody rb;

    private Vector3 reflectionVec;

    public enum Vec
    {
        Up,
        Down,
        Left,
        Right
    }

    private Vec FireVec;
    [SerializeField] private float fSpeed;

    private bool bContactFlg = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(FireVec == Vec.Up)
        {
            rb.velocity = new Vector3(0, fSpeed, 0);
        }
        else if(FireVec == Vec.Down)
        {
            rb.velocity = new Vector3(0, -fSpeed, 0);
        }
        else if (FireVec == Vec.Left)
        {
            rb.velocity = new Vector3(-fSpeed, 0, 0);
        }
        else if (FireVec == Vec.Right)
        {
            rb.velocity = new Vector3(fSpeed, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        fDeltaTime += Time.deltaTime;

        if (fDeltaTime >= fEraseTime)
        {
            Destroy(this.gameObject);
        }

        if (!bContactFlg)
        {
            if (FireVec == Vec.Up)
            {
                rb.velocity = new Vector3(0, fSpeed, 0);
            }
            else if (FireVec == Vec.Down)
            {
                rb.velocity = new Vector3(0, -fSpeed, 0);
            }
            else if (FireVec == Vec.Left)
            {
                rb.velocity = new Vector3(-fSpeed, 0, 0);
            }
            else if (FireVec == Vec.Right)
            {
                rb.velocity = new Vector3(fSpeed, 0, 0);
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    public void SetFireVec(Vec vec)
    {
        FireVec = vec;
    }
}
