using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapeState : IState
{

    public CapeState(ClothSpawner s)
    {
        spawner = s;
    }

    public override void ChangeSize(float newSize)
    {
        Vector3 offset =new Vector3(0.1f + newSize * 0.05f, 0.1f, 0.1f + newSize * 0.05f);
        spawner.lastSpawned.transform.localScale = offset;
    }
}
