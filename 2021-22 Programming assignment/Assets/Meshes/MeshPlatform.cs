using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPlatform : MonoBehaviour
{
	// Start is called before the first frame update
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

		// Copy version of vertices for restoring mesh
		originalVertices = mesh.vertices;
		BoxCollider BC = gameObject.AddComponent<BoxCollider>();
		GetComponent<Renderer>().material.color = Color.grey;

	}
}
