using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothPool : MonoBehaviour
{
    // References to cloth prefabs.
    [SerializeField]
    private PoolableCloth [] prefabs;

    // References to reusable instances
    [SerializeField]
    private PoolableCloth [] reusableInstances = new PoolableCloth[3];

    // returns instance of prefab
    public PoolableCloth GetPrefabInstance(int number)
    {
        PoolableCloth instance;

        if (reusableInstances[number])
        {
            instance = reusableInstances[number];
            instance.gameObject.SetActive(true);
        }
        else
        {
            instance = Instantiate(prefabs[number]);
        }
        return instance;
    }

    //returns prefab to pool
    public void ReturnToPool(PoolableCloth instance)
    {
        instance.gameObject.SetActive(false);
        // reset size and stretchiness
        reusableInstances[instance.number]=instance;
    }
}
