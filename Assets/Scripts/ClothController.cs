using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothController : MonoBehaviour
{

    public Point[] linkA;
    public Point[] linkB;
    public float[] restDist;

    public LineRenderer lineRenderer;
     

    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;

        for(int i = 0; i < linkA.Length; i++)
        {
            restDist[i] = linkA[i].InitializeLinks(linkB[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<linkA.Length;i++)
        {
            linkA[i].SolveLink(linkB[i], restDist[i], lineRenderer);
        }
    }
}
