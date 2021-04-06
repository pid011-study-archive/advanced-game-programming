using System.Collections.Generic;

using UnityEngine;

public class CylinderMesh : MonoBehaviour
{
    private const float TwoPI = Mathf.PI * 2f;

    [SerializeField, Range(0.1f, 10f)]
    private float height = 3f, radius = 1f;

    [SerializeField, Range(3, 128)]
    private int segments = 16;

    private void Start()
    {
        var mesh = new Mesh();

        var vertices = new List<Vector3>();
        var uvs = new List<Vector2>();
        var normals = new List<Vector3>();
        var triangles = new List<int>();

        // float height = 3f, radius = 1f;
        // int segments = 7;

        float top = height * 0.5f, bottom = -height * 0.5f;

        GenerateCap(segments + 1, top, bottom, radius, vertices, uvs, normals, true);

        var len = (segments + 1) * 2;
        for (int i = 0; i < segments + 1; i++)
        {
            int idx = i * 2;
            int a = idx, b = idx + 1, c = idx + 2, d = idx + 3;
            triangles.Add(a);
            triangles.Add(c);
            triangles.Add(b);
            triangles.Add(d);
            triangles.Add(b);
            triangles.Add(c);
        }

        GenerateCap(segments + 1, top, bottom, radius, vertices, uvs, normals, false);

        vertices.Add(new Vector3(0f, top, 0f));
        uvs.Add(new Vector2(0.5f, 1f));
        normals.Add(new Vector3(0f, 1f, 0f));

        vertices.Add(new Vector3(0f, bottom, 0f));
        uvs.Add(new Vector2(0.5f, 0f));
        normals.Add(new Vector3(0f, -1f, 0f));

        var it = vertices.Count - 2;
        var ib = vertices.Count - 1;

        var offset = len;

        for (int i = 0; i < len; i += 2)
        {
            triangles.Add(it);
            triangles.Add((i + 2) + offset);
            triangles.Add(i + offset);
        }

        for (int i = 1; i < len; i += 2)
        {
            triangles.Add(ib);
            triangles.Add(i + offset);
            triangles.Add((i + 2) + offset);
        }

        mesh.vertices = vertices.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.normals = normals.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateBounds();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void GenerateCap(int segments, float top, float bottom, float radius,
        List<Vector3> vertices, List<Vector2> uvs, List<Vector3> normals, bool side)
    {
        for (int i = 0; i < segments; i++)
        {
            float ratio = (float)i / (segments - 1);
            float rad = ratio * TwoPI;

            float cos = Mathf.Cos(rad), sin = Mathf.Sin(rad);
            float x = cos * radius, z = sin * radius;
            Vector3 tp = new Vector3(x, top, z), bp = new Vector3(x, bottom, z);

            vertices.Add(tp);
            uvs.Add(new Vector2(ratio, 1f));
            vertices.Add(bp);
            uvs.Add(new Vector2(radius, 0f));

            if (side)
            {
                var normal = new Vector3(cos, 0f, sin);
                normals.Add(normal);
                normals.Add(normal);
            }
            else
            {
                normals.Add(new Vector3(0f, 1f, 0f));
                normals.Add(new Vector3(0f, -1f, 0f));
            }
        }
    }
}
