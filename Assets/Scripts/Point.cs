using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    static public float Stiffnes = 1f;
    static public float Size = 0;

    
    private Vector3 newPos;
    private Vector3 oldPos;

    private Vector3 gravity = new Vector3(0f, -0.98f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        newPos = this.transform.position;
        oldPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Inertia();
        this.transform.position += gravity * Time.deltaTime;
    }

    private void LateUpdate()
    {
        oldPos = newPos;
        newPos = this.transform.position;
    }


    private void Inertia()
    {
        Vector3 vel = this.transform.position - oldPos;
        newPos = this.transform.position + vel * Time.deltaTime;
        this.transform.position = newPos;
    }

    public void SolveLink(Point pointB, float restD, LineRenderer lineRenderer)
    {
        Vector3 posA = this.transform.position;
        Vector3 posB = pointB.transform.position;

        float dist = Vector3.Distance(posA, posB);

        float difference = (restD + Size - dist) / dist;

        Vector3 translate = (posA - posB) * 0.5f * difference * Stiffnes;

        this.transform.position += translate * Time.deltaTime;
        pointB.transform.position -= translate * Time.deltaTime;

        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, pointB.transform.position);
    }

    public float InitializeLinks(Point pointB)
    {
        Vector3 posA = this.transform.position;
        Vector3 posB = pointB.transform.position;

        float dist = Vector3.Distance(posA, posB);
        return dist;
    }


}
