using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Meshgenerator : MonoBehaviour
{
    public float scale;
    public float waveSpeed;
    private bool recalculateNormals=false;
    private Vector3[] baseVertices;
   
    Mesh mesh;
    MeshFilter mf;

    private Vector3[] originalVertices;
    Vector3[] vertices;

    int[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        
        mesh = new Mesh();
        mf = GetComponent<MeshFilter>();

       Vector3[] vertices = new Vector3[]
       {
          new Vector3(0,0,0),
          new Vector3(0,0,80),
          new Vector3(40,0,0),
          new Vector3(40,0,80),

       };

      int[]  triangles = new int[]
         {
            0,1,2,
            1,3,2

         };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        mf.mesh = mesh;
        GetComponent<MeshFilter>().mesh = mesh;

        originalVertices = mesh.vertices;
        BoxCollider BC = gameObject.AddComponent<BoxCollider>();
        BC.isTrigger = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }

    // Update is called once per frame

     void Update()
    {
        CalcNoise();
    }
    
    void CalcNoise()
    {
       
        if (baseVertices == null)
        {
            baseVertices = mesh.vertices;
        }
        

        vertices = new Vector3[baseVertices.Length];

        float timex = Time.time * waveSpeed + 0.1365143f;
        float timey=  Time.time*  waveSpeed+ 1.21688f;
        float timez = Time.time * waveSpeed + 2.5564f;
        for (int i=0;i<vertices.Length;i++)
        {
            Vector3 vertex = baseVertices[i];

            vertex.x += Mathf.PerlinNoise(timex + vertex.x, timex + vertex.y) * scale;
            vertex.y += Mathf.PerlinNoise(timey + vertex.x, timey + vertex.y) * scale;
            vertex.z += Mathf.PerlinNoise(timez + vertex.x, timez + vertex.y) * scale;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;

        if(recalculateNormals)
        {
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            GetComponent<MeshFilter>().mesh = mesh;
        }
        
    }
}
