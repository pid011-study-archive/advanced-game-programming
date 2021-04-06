using UnityEngine;

public class Triangle : MonoBehaviour
{
    private void Start()
    {
        var mesh = new Mesh();
        float size = 6.0f;
        float hsize = size * 0.5f;

        var vertices = new Vector3[]
        {
            new Vector3(hsize, hsize, 0f),
            new Vector3(-hsize, hsize, 0f),
            new Vector3(-hsize, -hsize, 0f),
            new Vector3(hsize, -hsize, 0f)
        };

        var uv = new Vector2[]
        {
            new Vector2(1f, 1f),
            new Vector2(0f, 1f),
            new Vector2(0f, 0f),
            new Vector2(1f, 0f)
        };

        var normals = new Vector3[]
        {
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f)
        };

        var triangles = new int[]
        {
            0, 3, 1
        };

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.normals = normals;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
