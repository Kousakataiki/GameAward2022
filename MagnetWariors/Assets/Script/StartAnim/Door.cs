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
        AudioManager.instance.Play("SE_DoorOpen");
    }

    public void Close()
    {
        anim.SetFloat("Speed", AnimSpeed);
        anim.SetTrigger("Close");
        AudioManager.instance.Play("SE_DoorClose");
    }

    public void EndOpen()
    {
        PlayerStartAnim PSA = GameObject.FindWithTag("Player").GetComponent<PlayerStartAnim>();
        if (PSA != null)
            PSA.Play();
    }

    public void EndClose()
    {
    }
}
