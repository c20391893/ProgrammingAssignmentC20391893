using UnityEngine;
using System.Collections;

public class Scene1_script1 : MonoBehaviour
{

	// Use this for initialization
	public float scale;
	public float speed;
	bool recalculateNormals = false;
	public bool isOn = true;

	Mesh mesh;
	MeshFilter mf;

	// Array of original vertices
	private Vector3[] originalVertices;
	private Vector3[] baseVertices;
	Vector3[] vertices;

	// Function to toggle Perlin Filter on/off


	// Function to Update scale value from slider


	// Use this for initialization
	void Start()
	{


		mesh = new Mesh();
		mf = GetComponent<MeshFilter>();

		var size = 1;

		Vector3[] vertices = new Vector3[]{
			new Vector3(-10, -size, -10),
			new Vector3(-10,  size, -10),
			new Vector3( 10,  size, -10),
			new Vector3( 10, -size, -10),
			new Vector3( 10, -size,  10),
			new Vector3( 10,  size,  10),
			new Vector3(-10,  size,  10),
			new Vector3(-10, -size,  10)
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

		// Copy version of vertices for restoring mesh
		originalVertices = mesh.vertices;

	}

	// Update is called once per frame
	void Update()
	{

		//mesh = GetComponent<MeshFilter>().mesh;

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
			vertex.y += Mathf.PerlinNoise(timey + vertex.x, timey + vertex.y) * scale;
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