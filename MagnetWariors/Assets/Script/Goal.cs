using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] Text text;
    [SerializeField] GameObject Cam;
    [SerializeField] GameObject Player;

    private Animator anim;
    Rigidbody rb;

    private bool Hit;
    private float TimeCount;
    private int rotate;
    private bool finish;

    public float Cam_x;
    public float Cam_y;
    public float Cam_z;


    // Start is called before the first frame update
    void Start()
    {
        Hit = false;
        TimeCount = 0;
        rotate = 90;
        finish = false;

        anim = Player.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Hit == true)
        {
            Destroy(Player.GetComponent<PlayerMove>());
            Destroy(GameObject.Find("CameraArea"));



            if (Cam.transform.position.z <= -10)
            {
                Cam.transform.Translate(Cam_x, Cam_y, Cam_z);
            }
            if (rotate >= 0)
            {
                Player.transform.Rotate(0, 1, 0);
                rotate--;
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
                anim.SetTrigger("Jump");
                Hit = false;
                finish = true;


            }

        }

        if (finish == true)
        {
            TimeCount += Time.deltaTime;

            if (TimeCount > 2.0f)
            {
                SceneManager.LoadScene("World_1");
            }

        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Hit = true;
        }
    }

}
