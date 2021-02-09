using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator anim;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
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
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        anim.Play("Idle", -1, 0f);
        this.PauseAnimation();
    }
}
