using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelectButton : MonoBehaviour
{
    [SerializeField]
    private GameObject FirstSelect;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(FirstSelect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
