using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    Dictionary<Vector2, float> links;


    Vector3[] positions;
    Vector3[] oldPositions;
    Vector3 gravity;


    const float EPSILON = 0.01f;
    float DAMPING = 0.99f;
    float TOLERANCE = 0.1f;// the lower, the stiffer the cloth

    public GameObject[] enviro;
    float[] radiusEnv;

    bool move = false;
    void Start()
    {
        mesh = GetComponentInChildren<MeshFilter>().mesh;
        vertices = mesh.vertices;
        triangles = mesh.triangles;
        links = new Dictionary<Vector2, float>();

        Vector2 tmp;

        //przypisujemy krawędzie
        for (var i = 0; i < triangles.Length; i+=3) {

            tmp = new Vector2(Mathf.Max(triangles[i], triangles[i + 1]), Mathf.Min(triangles[i], triangles[i + 1]));
            if (links.ContainsKey(tmp))            
                links.Add(tmp, (vertices[triangles[i]] - vertices[triangles[i + 1]]).magnitude);

            tmp = new Vector2(Mathf.Max(triangles[i], triangles[i + 2]), Mathf.Min(triangles[i], triangles[i + 2]));
            if (links.ContainsKey(tmp))
                links.Add(tmp, (vertices[triangles[i]] - vertices[triangles[i + 2]]).magnitude);

            tmp = new Vector2(Mathf.Max(triangles[i+1], triangles[i + 2]), Mathf.Min(triangles[i], triangles[i + 1]));
            if (links.ContainsKey(tmp))
                links.Add(tmp, (vertices[triangles[i+1]] - vertices[triangles[i + 2]]).magnitude);
        }


        gravity = new Vector3(0.0f, -9.81f, 0.0f);
        oldPositions = new Vector3[vertices.Length];
        positions = new Vector3[vertices.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.TransformPoint(vertices[i]);
            oldPositions[i] = positions[i];
        }

        radiusEnv = new float[enviro.Length];
        for(int i = 0; i < radiusEnv.Length; i++)
        {
            radiusEnv[i] = enviro[i].GetComponent<SphereCollider>().radius * enviro[i].transform.localScale.x;
            Debug.Log(radiusEnv[i]);
        }
    }


    void Update()
    {
        if (move)
        {
            for (var i = 0; i < vertices.Length; i++)
            {
                vertices[i] += Vector3.down * Time.deltaTime;
                
            }

            // assign the local vertices array into the vertices array of the Mesh.
            mesh.vertices = vertices;
            mesh.RecalculateBounds();
        }

        if (Input.GetButton("Jump"))
        {
            move = !move;
        }

        //==============================================

        Vector3 temp, velocity;
        for (int i = 0; i < positions.Length; i++)
        {
            
            //Verlet integration
            temp = positions[i];

            velocity = positions[i] - oldPositions[i];

            positions[i] += velocity * DAMPING + gravity * Time.deltaTime * Time.deltaTime/10;

            oldPositions[i] = temp;
        }

        //Link contraints
        foreach(KeyValuePair<Vector2, float> link in links)
        {
            SatisfyLink((int)link.Key[0], (int)link.Key[1], link.Value);
        }


        for (int i = 0; i < positions.Length; i++)
        {
            SatisfyEnviro(i);
        }



        //================================

        for (int i = 0; i < positions.Length; i++)
        {
            vertices[i] = positions[i];
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();

    }

    void SatisfyEnviro(int v)
    {
        for(int i = 0; i < enviro.Length; i++)
        {

            Vector3 diff = positions[v] - enviro[i].transform.position;
            float dist = diff.magnitude;

            diff /= dist;

            if(dist < radiusEnv[i])
            {
                positions[v] += diff * (radiusEnv[i] - dist * EPSILON);
            }
        }
    }

    void SatisfyLink(int v1, int v2, float value)
    {

        Vector3 diffVec = positions[v1] - positions[v2];
        float dist = diffVec.magnitude;
        float difference = value - dist;

        // normalize
        diffVec /= dist;

        // Change positions of v1 and v2 to satisfy distance constraint
        if (Mathf.Abs(difference) > TOLERANCE)// tolerance is set close to zero
        {
            Vector3 correction = diffVec * (difference * 0.5f);
            positions[v1] += correction;
            positions[v2] -= correction;
        }


    }
}
