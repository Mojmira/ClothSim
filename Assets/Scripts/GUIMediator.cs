using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMediator : MonoBehaviour, Mediator
{
    [SerializeField]
    private AnimatorController anim;
    [SerializeField]
    private ClothSpawner spawner;

    public void notify(string eventMsg)
    {
        switch (eventMsg)
        {
            case "RestartAnimation":
                anim.StopAnimation();
                spawner.RemoveLastSpawned();
                break;
            case "StopAnimation":
                anim.StopAnimation();
                break;
            case "PlayAnimation":
                anim.PlayAnimation();
                break;
            case "PauseAnimation":
                anim.PauseAnimation();
                break;
            case "Spawn0":
                spawner.Spawn(0);
                break;
            case "Spawn1":
                spawner.Spawn(1);
                break;
            case "Spawn2":
                spawner.Spawn(2);
                break;
        }
    }
}
