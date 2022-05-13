using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float AnimSpeed;

    Animator anim;

    bool isOpen;


    void Start()
    {
        anim = GetComponent<Animator>();
        Open();
    }

    void Update()
    {        
    }

    public void Open()
    {
        anim.SetFloat("Speed", AnimSpeed);
        anim.SetTrigger("Open");
    }

    public void Close()
    {
        anim.SetFloat("Speed", AnimSpeed);
        anim.SetTrigger("Close");
    }

    public void EndOpen()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerStartAnim>().Play();
    }

    public void EndClose()
    {
    }
}
