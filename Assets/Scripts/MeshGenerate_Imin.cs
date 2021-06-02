using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerate_Imin : MonoBehaviour
{
     Mesh mesh;

    Vector3[] vertices;

    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    [SerializeField]
    float height = 6f;
    

    Vector2[] uvs;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        //MeshFilter mf = GetComponent<MeshFilter>();
        //Mesh mesh = mf.mesh;

        StartCoroutine(CreateGrid());

        //CreateMesh();

        //UpdateMesh();

    }

    private void Update()
    {
        UpdateMesh();
    }

    IEnumerator CreateGrid()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        //int i = 0;

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * height; //good fourmula,especially height=6f
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

                yield return new WaitForSeconds(.01f);
            }
            vert++;
        }

        uvs = new Vector2[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <=xSize; x++)
            {
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }



        


    }

    void CreateMesh()
    {
        //define where are vertices.
         vertices = new Vector3[]
        {
            //front face
            new Vector3(0,0,0),//0
            new Vector3(0,1,0),//1
            new Vector3(1,1,0),//2

        };

         triangles = new int[]
        {
            0,1,2
        };

        uvs = new Vector2[]
       {
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(1,1),
       };

        //MeshFilter mf = GetComponent<MeshFilter>();
        //Mesh mesh = mf.mesh;


    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();

    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }


    }

    //still dont konw how to use it
    //Mesh mesh = GetComponent<MeshFilter>().mesh;

    //Vector3[] vertices = mesh.vertices;

    //Vector3[] normals = mesh.normals;

    //for (var i = 0; i< vertices.Length; i++)
    //{
    //    vertices[i] += normals[i] * Mathf.Sin(Time.deltaTime);
    //}

    //mesh.vertices = vertices;
}
