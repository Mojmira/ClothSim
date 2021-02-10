using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChitonState : IState
{
    public ChitonState(ClothSpawner s)
    {
        spawner = s;
    }

    public override void ChangeSize(float newSize)
    {
        Vector3 offset = new Vector3(0.11f + newSize * 0.04f, 0.1f, 0.13f + newSize * 0.02f);
        spawner.lastSpawned.transform.localScale = offset;
    }
}