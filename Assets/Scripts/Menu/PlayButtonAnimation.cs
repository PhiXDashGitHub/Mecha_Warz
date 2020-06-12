using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAnimation : MonoBehaviour
{
    Animation anim;

    public void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    public void PlayUP()
    {
        anim.Play("ButtonUP");
    }
    public void PlayDOWN()
    {
        anim.Play("ButtonDOWN");
    }
}
