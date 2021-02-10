using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GUIMediator : MonoBehaviour, Mediator
{
    [SerializeField]
    private AnimatorController anim;
    [SerializeField]
    private ClothSpawner spawner;

    [SerializeField]
    private Slider sliderD;
    [SerializeField]
    private Slider sliderS;

    private IState state;

    public void notify(string eventMsg)
    {
        switch (eventMsg)
        {
            case "RestartAnimation":
                anim.StopAnimation();
                spawner.RemoveLastSpawned();
                ResetSliders();
                DisableSliders();
                break;
            case "StopAnimation":
                anim.StopAnimation();
                ResetSliders();
                DisableSliders();
                break;
            case "PlayAnimation":
                anim.PlayAnimation();
                ActivateSliders();
                break;
            case "PauseAnimation":
                anim.PauseAnimation();
                break;
            case "Spawn0":
                anim.StopAnimation();
                spawner.Spawn(0);
                state = new CapeState(spawner);
                ResetSliders();
                ActivateSliders();
                break;
            case "Spawn1":
                anim.StopAnimation();
                spawner.Spawn(1);
                state = new ChitonState(spawner);
                ResetSliders();
                ActivateSliders();
                break;
            case "Spawn2":
                anim.StopAnimation();
                spawner.Spawn(2);
                state = new HatState(spawner);
                ResetSliders();
                ActivateSliders();
                break;
            case "Damping":
                state.ChangeDamping(sliderD.value);
                break;
            case "Size":
                state.ChangeSize(sliderS.value);
                break;

        }
    }

    void ResetSliders()
    {
        sliderD.value = 0f;
        sliderS.value = 0f;
    }

    void DisableSliders()
    {
        sliderD.interactable = false;
        sliderS.interactable = false;
    }

    void ActivateSliders()
    {
        sliderD.interactable = true;
        sliderS.interactable = true;
    }
}
