using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollider : MonoBehaviour
{
    // �����I�u�W�F�N�g�w��
    public GameObject DestroyObj;

    // PopUI�Ăяo��
    PopUI DownUI;

    // Start is called before the first frame update
    void Start()
    {
        DownUI = transform.parent.gameObject.GetComponent<PopUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (collision.gameObject.tag == "Player")
        {
            Destroy(DestroyObj);

            DownUI.canJudge = true;
        }
    }
}
