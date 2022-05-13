using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tateidou : MonoBehaviour
{
    [SerializeField] float range = 15f;
    [SerializeField] float speed = 90f;

    float angle;


    float Y;

    // Start is called before the first frame update
    void Start()
    {
        Y = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * speed;

        this.transform.position = new Vector3(transform.position.x,Y + Mathf.Cos(Mathf.Deg2Rad * angle) * range, transform.position.z);






    }
}
