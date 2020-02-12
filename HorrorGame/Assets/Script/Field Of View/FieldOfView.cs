using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

enum FlashLightDir
{
    Right,
    Left,
    Up,
    Down
}
public class FieldOfView : MonoBehaviour
{

    float myFov = 80f;
    Vector3 myOrigin;
    int myRayCount = 50;
    float myAngle = 0f;
    float myAngleIncrease;
    //float myViewDistance = 8f;
    public float viewdistance;
    Vector3 myDirection;

    Vector3[] myVertices;
    Vector2[] myUv;
    int[] myTriangles;
    Transform PlayerT;
    Player ThePlayer;
    [SerializeField] SpriteRenderer SR;

    [SerializeField] private LayerMask myLayerMask;

    private Mesh myMesh;
    float angle;
    bool IsChangingY = false;
    bool IsChangingX = false;
    bool DontChangeAngleForY = false;
    public float myEnergy;
    float fov;

    public RaycastHit2D raycasthit;
    public Vector3 origin;

    FlashLightDir myFlashDir = FlashLightDir.Right;
    MeshRenderer myMeshRenderer;
    bool Isflashing = false;
    [SerializeField]Tilemap myTileMap;
    [SerializeField]Grid myGrid;
    [SerializeField]GameObject mySpriteMaskOBJ;
    List<GameObject> mySpriteMasks = new List<GameObject>();

    public Vector3 getVectorFromAngle(float anAngle)
    {
        float tempAngleRad = anAngle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(tempAngleRad), Mathf.Sin(tempAngleRad));
    }
   



    private void Start()
    {       
        SetAimDirection(Vector2.right);
        myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;
        myMeshRenderer = GetComponent<MeshRenderer>();
        myMeshRenderer.sortingLayerID = SR.sortingLayerID;
        PlayerT = GameObject.FindGameObjectWithTag("Player").transform;
        ThePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private void Update()
    {
        if (myFlashDir == FlashLightDir.Right)
        {
            SetAimDirection(Vector2.right);
        }
        if (myFlashDir == FlashLightDir.Left)
        {
            SetAimDirection(Vector2.left);
        }
        if (myFlashDir == FlashLightDir.Up)
        {
            SetAimDirection(Vector2.up);
        }
        if (myFlashDir == FlashLightDir.Down)
        {
            SetAimDirection(Vector2.down);
        }
        if (ThePlayer.change.x < 0)
        {
            if (IsChangingY && !IsChangingX)
            {
                DontChangeAngleForY = true;
            }
            SetAimDirection(Vector2.left);
            myFlashDir = FlashLightDir.Left;
            IsChangingX = true;
        }
        if (ThePlayer.change.x > 0)
        {
            if (IsChangingY && !IsChangingX)
            {
                DontChangeAngleForY = true;
            }
            SetAimDirection(Vector2.right);
            myFlashDir = FlashLightDir.Right;
            IsChangingX = true;
        }
        if (ThePlayer.change.y > 0 && !DontChangeAngleForY)
        {
            IsChangingY = true;
            SetAimDirection(Vector2.up);
            myFlashDir = FlashLightDir.Up;
        }
        if (ThePlayer.change.y < 0 && !DontChangeAngleForY)
        {
            IsChangingY = true;
            SetAimDirection(Vector2.down);
            myFlashDir = FlashLightDir.Down;
        }
        if (ThePlayer.change.x == 0)
        {
            IsChangingX = false;
            DontChangeAngleForY = false;
        }
        if (ThePlayer.change.y == 0)
        {
            IsChangingY = false;
            DontChangeAngleForY = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Isflashing = !Isflashing;
        }
        if (Isflashing)
        {
            FlashThelight();
            myEnergy -= Time.deltaTime;
        }
        else
        {
            myMesh.Clear();
        }
    }

    public void FlashThelight()
    {
        transform.position = PlayerT.position;
        fov = 90;
        fov = Mathf.Clamp(myEnergy, 0, 90);
        origin = transform.position;
        int rayCount = 50;

        float angleincrease = fov / rayCount;
        viewdistance = 20f;
        viewdistance = Mathf.Clamp(myEnergy, 0, 20);
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];
        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            raycasthit = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewdistance, myLayerMask);
            if (raycasthit.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewdistance;
            }
            else
            {
                vertex = raycasthit.point;
                if (raycasthit.collider.gameObject.GetComponent<LightReflect>())
                {
                    raycasthit.collider.gameObject.GetComponent<LightReflect>().HasLightOnIt = true;
                    raycasthit.collider.gameObject.GetComponent<Renderer>().sortingLayerID = myMeshRenderer.sortingLayerID;
                }
                if (raycasthit.collider.gameObject.GetComponent<TilemapCollider2D>())
                {
                    Vector3Int cordinate = myGrid.WorldToCell(raycasthit.point - raycasthit.normal);
                    Vector3 WorldCordinate = myGrid.GetCellCenterWorld(cordinate);
                    if (!SpriteMaskExsistsOnPoint(raycasthit.point - raycasthit.normal))
                    {
                        GameObject obj = Instantiate(mySpriteMaskOBJ, WorldCordinate, mySpriteMaskOBJ.transform.rotation);
                        obj.GetComponent<LightReflect>().DestroyAfterLightIsGone = true;
                        mySpriteMasks.Add(obj);
                        Vector2 SpriteSizehWorld = obj.GetComponent<SpriteMask>().sprite.bounds.size;
                        Vector2 CellSizeWorld = myGrid.cellSize;
                        Vector2 newScale = CellSizeWorld / SpriteSizehWorld;
                        obj.transform.localScale = newScale;
                    }
                }
            }
            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleincrease;
        }

        myMesh.vertices = vertices;
        myMesh.uv = uv;
        myMesh.triangles = triangles;
        transform.position = Vector3.zero;
    }

    float GetAngleFromDirection(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    void SetAimDirection(Vector3 dir)
    {
        angle = GetAngleFromDirection(dir) + fov / 2; 
    }

    bool SpriteMaskExsistsOnPoint(Vector2 Point)
    {
        for (int i = mySpriteMasks.Count -1; i >= 0 ; i--)
        {
            if(mySpriteMasks[i] == null)
            {
                mySpriteMasks.RemoveAt(i);
            }
        }
        for (int i = 0; i < mySpriteMasks.Count; i++)
        {
            if((Vector2)mySpriteMasks[i].transform.position == Point)
            {
                return true;
            }
        }
        return false;
    }

}