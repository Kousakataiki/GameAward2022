using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HagurumaRote : MonoBehaviour
{

    [SerializeField]private float Speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Speed);
    }
}
