using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScratch : MonoBehaviour
{

     Vector3[] newVertices;
     Vector2[] newUV;
     int[] newTriangles;

    void MeshSetup()
    {
         newVertices = new Vector3[] {
            new Vector3(-1, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 0, -1),
            new Vector3(-1, 0, -1)
        };

         newUV = new Vector2[] {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
          };

         newTriangles = new int[] {
             0, 1, 2, 0, 2, 3
        };

    }

    // Start is called before the first frame update
    void Start()
    {
        MeshSetup();
        Mesh mesh = new Mesh();
        //gameObject.AddComponent<MeshCollider>().sharedMesh = mesh;
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
        
    }

    
}
