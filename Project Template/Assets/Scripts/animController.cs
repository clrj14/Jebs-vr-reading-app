using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{

    public GameObject chestTop;
    public bool isOpen = false;
    private Animator animator;

    private void Awake()
    {
        animator = chestTop.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            animator.Play("Open");
            isOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            if (isOpen)
            {
                animator.Play("Close");
                isOpen = false;
            }
        }
    }
}
