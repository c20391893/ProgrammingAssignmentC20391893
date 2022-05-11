using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPerlin : MonoBehaviour
{
	// Start is called before the first frame update
	public float scale;
	public float waveSpeed;
    private float waveHeight;


	void Start()
	{

		var size = 1;

		// Create Vector array
		Vector3[] vertices = new Vector3[]{
			new Vector3(size, size, -size),
			new Vector3(-size,  size, -size),
			new Vector3( size,  size, -size),
			new Vector3( size, -size, -size),
			new Vector3( size, -size,  size),
			new Vector3( -size,  -size,  -size),
			new Vector3(-size,  size,  size),
			new Vector3(-size, -size,  size)
		};

		// Define triangles for Cube
		int[] triangles = new int[]{
			0, 1, 3, // Face 1
			0, 2, 3,

			3, 2, 5, // Face 2
			3, 5, 4,

			5, 2, 1, // Face 3
			5, 1, 6,

			3, 4, 7, // Face 4
			3, 7, 0,

			0, 7, 6, // Face 5
			0, 6, 1,

			4, 5, 6, // Face 6
			4, 6, 7
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


	
}
