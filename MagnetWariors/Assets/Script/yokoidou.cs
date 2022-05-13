using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yokoidou : MonoBehaviour
{
 
    [SerializeField] float range = 15f;
    [SerializeField] float speed = 90f;

    float angle;


    float X;

    // Start is called before the first frame update
    void Start()
    {
        X = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * speed;

      this.transform.position = new Vector3(X + Mathf.Cos(Mathf.Deg2Rad * angle) * range,transform.position.y,transform.position.z);






    }
}
