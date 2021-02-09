using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableCloth : MonoBehaviour
{
    public int number;
    
    public static Transform GetParentTransform(int number)
    {
        switch(number)
        {
            case 2: // attach hat to head
                return GameObject.Find("m_avg_Head").transform;
                break;
            default: // attach cape and chiton to neck
                return GameObject.Find("m_avg_Neck").transform;
                break;
        }
    }

    public void AttachColliders()
    {
        string[] collidersNames;

        switch (number)
        {
            case 2: // hat colliders
                collidersNames = new string[] { "m_avg_Neck", "m_avg_Head", "m_avg_L_Shoulder", "m_avg_R_Shoulder", "m_avg_Spine2"};
                break;
            case 1: // chiton colliders
                collidersNames = new string[] { "m_avg_L_Collar", "m_avg_R_Collar", "m_avg_Spine1", "m_avg_Spine2", "m_avg_L_Hip", "m_avg_R_Hip", "m_avg_Pelvis" };
                break;
            case 0: // cape colliders
                collidersNames = new string[] { "m_avg_L_Collar", "m_avg_R_Collar", "m_avg_Spine1", "m_avg_Spine2", "m_avg_Pelvis" };
                break;
            default:
                collidersNames = null;
                break;
        }

        CapsuleCollider[] capsuleColliders = new CapsuleCollider[collidersNames.Length];

        for(int i = 0; i < collidersNames.Length; i++)
        {
            capsuleColliders[i] = GameObject.Find(collidersNames[i]).GetComponent<CapsuleCollider>();
        }

        GetComponent<Cloth>().capsuleColliders = capsuleColliders;
    }
}
