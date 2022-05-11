using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshWaterGenerator : MonoBehaviour
{
	
	public float scale;
	public float speed;
	bool recalculateNormals = true;
	public bool isOn = true;
	public float waveHeight;

	Mesh mesh;
	MeshFilter mf;

	
	private Vector3[] originalVertices;
	private Vector3[] baseVertices;
	Vector3[] vertices;


	void Start()
	{


		mesh = new Mesh();
		mf = GetComponent<MeshFilter>();

		var size = 1;

		Vector3[] vertices = new Vector3[]{
			new Vector3(-20, -10, -40),
			new Vector3(-20,  size, -40),
			new Vector3( 20,  size, -40),
			new Vector3( 20, -10, -40),
			new Vector3( 20, -10,  35),
			new Vector3( 20,  size,  35),
			new Vector3(-20,  size,  35),
			new Vector3(-20, -10,  35)
		};

		int[] triangles = new int[]{
			0, 1, 2,
			2, 3, 0,
			3, 2, 5,
			3, 5, 4,
			5, 2, 1,
			5, 1, 6,
			3, 4, 7,
			3, 7, 0,
			0, 7, 6,
			0, 6, 1,
			4, 5, 6,
			4, 6, 7
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

		mesh = GetComponent<MeshFilter>().mesh;

		if (baseVertices == null)
			baseVertices = mesh.vertices;

		vertices = new Vector3[baseVertices.Length];


		float timex = Time.time * speed + 0.1365143f;
		float timey = Time.time * speed + 1.21688f;
		float timez = Time.time * speed + 2.5564f;

		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 vertex = baseVertices[i];

			//	Debug.Log (baseVertices [i]);

			//if (true) {

			vertex.x += Mathf.PerlinNoise(timex + vertex.x, timex + vertex.y) * scale;
			vertex.y += Mathf.PerlinNoise(timey + vertex.x, timey + vertex.y) * waveHeight;
			vertex.z += Mathf.PerlinNoise(timez + vertex.x, timez + vertex.y) * scale;
			vertices[i] = vertex;
			//			} else {
			//
			//				vertex.x = originalVertices[i].x;
			//				vertex.y = originalVertices[i].y;
			//				vertex.z = originalVertices[i].z;
			//				vertices [i] = vertex;
			//
			//			}


		}

		mesh.vertices = vertices;

		if (recalculateNormals)
			mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		GetComponent<MeshFilter>().mesh = mesh;


	}
}
