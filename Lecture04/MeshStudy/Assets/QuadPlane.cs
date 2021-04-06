using System.Collections.Generic;

using UnityEngine;

public class QuadPlane : MonoBehaviour
{
    private void Start()
    {
        // Create mesh instance
        var mesh = new Mesh();

        var vertices = new List<Vector3>();
        var uv = new List<Vector2>();
        var normals = new List<Vector3>();

        // ���� ������ ������ ��
        int widthSegments = 5;
        // ���� ������ ������ ��
        int heightSegments = 6;
        // �ʺ�
        float width = 10.0f;
        // ����
        float height = 10.0f;

        // ���� �� ������ �迭�� ��ġ�� ����(0.0 ~ 0.1)�� �����ϱ� ���� ��-�� ������ ����
        var winv = 1.0f / (widthSegments - 1);
        var hinv = 1.0f / (heightSegments - 1);

        for (int y = 0; y < heightSegments; y++)
        {
            var ry = y * hinv;

            for (int x = 0; x < widthSegments; x++)
            {
                var rx = x * winv;
                vertices.Add(new Vector3((rx - 0.5f) * width, 0f, (0.5f - ry) * height));
                uv.Add(new Vector2(ry, rx));
                normals.Add(new Vector3(0f, 1f, 0f));
            }
        }

        var triangles = new List<int>();
        for (int y = 0; y < heightSegments - 1; y++)
        {
            for (int x = 0; x < widthSegments - 1; x++)
            {
                int index = y * widthSegments + x;
                var a = index;
                var b = index + 1;
                var c = index + 1 + widthSegments;
                var d = index + widthSegments;

                // �ﰢ�� 2�� = Quad 1��
                triangles.Add(a);
                triangles.Add(b);
                triangles.Add(c);
                triangles.Add(c);
                triangles.Add(d);
                triangles.Add(a);
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.uv = uv.ToArray();
        mesh.normals = normals.ToArray();
        mesh.triangles = triangles.ToArray();

        // mesh bounding box �� ���
        mesh.RecalculateBounds();

        // mesh ����
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
