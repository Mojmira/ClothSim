using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatState : IState
{

    public HatState(ClothSpawner s)
    {
        spawner = s;
    }

    public override void ChangeSize(float newSize)
    {
        Vector3 offset = new Vector3(0.12f + newSize * 0.03f, 0.1f, 0.12f + newSize * 0.03f);
        spawner.lastSpawned.transform.localScale = offset;
    }
}