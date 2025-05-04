using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class RingMesh : MonoBehaviour
{
    [Range(3, 360)]
    public int segments = 100;
    public float innerRadius = 0.5f;
    public float outerRadius = 1f;

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;

        int vertCount = segments * 2;
        Vector3[] vertices = new Vector3[vertCount];
        int[] triangles = new int[segments * 6];
        Vector2[] uvs = new Vector2[vertCount];

        float angleStep = 360f / segments;

        for (int i = 0; i < segments; i++)
        {
            float angleRad = Mathf.Deg2Rad * i * angleStep;
            float cos = Mathf.Cos(angleRad);
            float sin = Mathf.Sin(angleRad);

            vertices[i * 2] = new Vector3(cos * innerRadius, sin * innerRadius, 0);
            vertices[i * 2 + 1] = new Vector3(cos * outerRadius, sin * outerRadius, 0);

            uvs[i * 2] = new Vector2(0, 0);
            uvs[i * 2 + 1] = new Vector2(1, 1);

            int triIndex = i * 6;
            int vertIndex = i * 2;
            int nextVertIndex = (i == segments - 1) ? 0 : vertIndex + 2;

            // Triangle 1
            triangles[triIndex] = vertIndex;
            triangles[triIndex + 1] = nextVertIndex + 1;
            triangles[triIndex + 2] = vertIndex + 1;

            // Triangle 2
            triangles[triIndex + 3] = vertIndex;
            triangles[triIndex + 4] = nextVertIndex;
            triangles[triIndex + 5] = nextVertIndex + 1;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        MeshRenderer render = GetComponent<MeshRenderer>();
        Material mat = new Material(Shader.Find("Sprites/Default"));
        mat.color = Color.white;
        render.material = mat; 
    }
}
