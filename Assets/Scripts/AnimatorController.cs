using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseAnimation()
    {
        anim.speed = 0;
    }

    public void PlayAnimation()
    {
        anim.speed = 1;
    }

    public void StopAnimation()
    {
        // call mediator to reset model transform to initial
        anim.Play("Idle", -1, 0f);
        this.PauseAnimation();
    }
}
