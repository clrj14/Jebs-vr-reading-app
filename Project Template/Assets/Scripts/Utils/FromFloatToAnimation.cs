using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class FromFloatToAnimation : MonoBehaviour
{
    public Animator receiver;

    public void UpdateAnimation(float f)
    {
        receiver.SetFloat("progress",f);
    }
}
