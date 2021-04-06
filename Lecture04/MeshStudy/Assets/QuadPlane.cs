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

        // 세로 방향의 정점의 수
        int widthSegments = 5;
        // 가로 방향의 정점의 수
        int heightSegments = 6;
        // 너비
        float width = 10.0f;
        // 높이
        float height = 10.0f;

        // 격자 상에 정점을 배열할 위치의 비율(0.0 ~ 0.1)을 산출하기 위한 행-열 개수의 역수
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

                // 삼각형 2개 = Quad 1개
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

        // mesh bounding box 재 계산
        mesh.RecalculateBounds();

        // mesh 적용
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
