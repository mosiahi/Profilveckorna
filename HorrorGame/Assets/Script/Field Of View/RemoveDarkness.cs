using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDarkness : MonoBehaviour
{
    [SerializeField] public FieldOfView flashLight;
    
    void deletThis(int index)
    {
        Destroy(this.gameObject.GetComponent<MeshCollider>());
        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
        int[] oldTriangles = mesh.triangles;
        int[] newTriangles = new int[mesh.triangles.Length - 3];

        int i = 0;
        int j = 0;

        while (j < mesh.triangles.Length)
        {
            if (j != index*3)
            {
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
            }
            else
            {
                j += 3;
            }
            transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
            this.gameObject.AddComponent<MeshCollider>();
        }
    }

    void Update()
    {
        RaycastHit2D hit2D = flashLight.raycasthit;
        if (hit2D && hit2D.transform.gameObject.tag == "Darkness")
        {
            Debug.Log("Ray Hit Darkness");
            //deletThis(hit2D.collider.gameObject.GetComponent<MeshRenderer>().);
        }
    }
}
