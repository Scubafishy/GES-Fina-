using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IActivatable
{

    [SerializeField]
    GameObject allLights;

    private Animator animator;

    private bool isOpen = false;

    public string NameText
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    public void DoActivate()
    {
        if(isOpen == false)
        {
            animator.SetBool("isDoorOpen", true);
            isOpen = true;
            allLights.SetActive(true);
        }
        else
        {
            animator.SetBool("isDoorOpen", false);
            isOpen = false;
            allLights.SetActive(false);
        }
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
