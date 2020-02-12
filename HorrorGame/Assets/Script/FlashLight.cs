using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Vector3 getVectorFromAngle(float anAngle)
    {
        float tempAngleRad = anAngle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(tempAngleRad), Mathf.Sin(tempAngleRad));
    }

    private void Start()
    {
        Mesh myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;

        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int raycount = 2;
        float angle = 0f;
        float angleIncrease = fov / raycount;
        float viewDistance = 12f;

        Vector3[] vertices = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[raycount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangelIndex = 0;

        for (int i = 0; i < raycount; i++)
        {
            Vector3 vertex = origin + getVectorFromAngle(angle) * viewDistance;
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangelIndex + 0] = 0;
                triangles[triangelIndex + 1] = vertexIndex - 1;
                triangles[triangelIndex + 1] = vertexIndex;

                triangelIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        myMesh.vertices = vertices;
        myMesh.uv = uv;
        myMesh.triangles = triangles;
    }
}
