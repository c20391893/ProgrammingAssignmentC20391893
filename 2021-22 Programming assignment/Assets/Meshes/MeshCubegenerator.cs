using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCubegenerator : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

		

		// Create Vector array
		Vector3[] vertices = new Vector3[]{
		 new Vector3(1,1,1),
		new Vector3(-1,1,1),
		new Vector3(-1,-1,1),
		new Vector3(1,-1,1),
		new Vector3(1,1,-1),
		new Vector3(-1,1,-1),
		new Vector3(1,-1,-1),
		new Vector3(-1,-1,-1)


		};

		// Define triangles for Cube
		int[] triangles = new int[]{
	  0,1,2,3,
	  5,0,3,6,
	  4,5,6,7,
	  1,4,7,2,
	  5,4,1,0,
	  3,2,7,6
		};

		// Craete Mesh
		Mesh mesh = new Mesh();
		// Add Vertices
		mesh.vertices = vertices;
		// Add Triangles
		mesh.triangles = triangles;
		// Recalculate Bounds
		mesh.RecalculateNormals();
		// Update Mesh Component
		GetComponent<MeshFilter>().mesh = mesh;

	}

	// Update is called once per frame
	void Update()
	{
	}
}
