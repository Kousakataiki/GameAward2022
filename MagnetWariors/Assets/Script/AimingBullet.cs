using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingBullet : MagnetType
{
    private float fDeltaTime;
    [SerializeField] private float fEraseTime;

    private Rigidbody rb;

    private Vector3 reflectionVec;
    
    [SerializeField] private float fSpeed;

    private bool bContactFlg = false;

    private Vector3 FireVec = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fDeltaTime += Time.deltaTime;

        if (fDeltaTime >= fEraseTime)
        {
            Destroy(this.gameObject);
        }

        rb.velocity = FireVec * fSpeed;
    }

    void FixedUpdate()
    {

    }

    public void SetFireVec(Vector3 vec)
    {
        FireVec = vec;
    }
}
