using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothSpawner : MonoBehaviour
{
    [SerializeField]
    private ClothPool clothPool;

    private PoolableCloth lastSpawned;

    [SerializeField]
    private GUIMediator mediator; // type should be Mediator but then Unity wouldn't diplay it in inspector

    public void Spawn(int number)
    {
        if (!lastSpawned || lastSpawned.number != number)
        {
            RemoveLastSpawned();
            mediator.notify("StopAnimation");

            PoolableCloth instance = clothPool.GetPrefabInstance(number);
            //instance.transform.position = transform.position; // set instance transform position to model position
            lastSpawned = instance;
        }

    }

    public void RemoveLastSpawned()
    {
        if (lastSpawned)
        {
            clothPool.ReturnToPool(lastSpawned);
            lastSpawned = null;
        }

    }
}
