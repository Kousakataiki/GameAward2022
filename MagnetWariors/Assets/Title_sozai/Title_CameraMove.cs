using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_CameraMove : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("robot_wait");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + 5.0f, 0, player.transform.position.z + -7.2f);
    }
}
