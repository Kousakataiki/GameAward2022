using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUI : MonoBehaviour
{
    public bool canJudge = false; // ƒtƒ‰ƒO

    [SerializeField] float MoveY;
    [SerializeField] float SpeedY;
    float StartY;

    void Start()
    {
        StartY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(canJudge)
        {
            transform.Translate(0, -Time.deltaTime * SpeedY, 0);

            if(StartY - transform.position.y >= MoveY)
            {
                canJudge = false;
            }
        }
    }
}
