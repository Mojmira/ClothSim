using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState
{
    public ClothSpawner spawner;

    

    public  void ChangeDamping(float newDamp)
    {
        spawner.lastSpawned.GetComponent<Cloth>().damping = newDamp;
    }
    public abstract void ChangeSize(float newSize);

}
