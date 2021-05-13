Shader "Unlit/Cube"
{
	Properties
	{
		_Height("Height", float) = 5.0
		_TopColor("Top Color", Color) = (0.0, 0.0, 1.0, 1.0)
		_BottomColor("Bottom Color", Color) = (1.0, 0.0, 0.0, 1.0)
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// geometry shader
			#pragma geometry geom

			#include "UnityCG.cginc"

			uniform float _Height;
			uniform float4 _TopColor, _BottomColor;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2g
			{
				float4 vertex : SV_POSITION;
			};

			struct g2f
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};

			v2g vert(appdata v)
			{
				v2g o;
				o.vertex = v.vertex;
				return o;
			}

			[maxvertexcount(24)] // 3 * 8
			void geom(triangle v2g input[3], inout TriangleStream<g2f> outstream)
			{
				float4 p0 = input[0].vertex;
				float4 p1 = input[1].vertex;
				float4 p2 = input[2].vertex;

				float4 c0 = p0 + float4(0.0f, 0.0f, -_Height, 1.0f);
				float4 c1 = p1 + float4(0.0f, 0.0f, -_Height, 1.0f);
				float4 c2 = p2 + float4(0.0f, 0.0f, -_Height, 1.0f);

				g2f out0;
				out0.vertex = UnityObjectToClipPos(p0);
				out0.color = _BottomColor;
				g2f out1;
				out1.vertex = UnityObjectToClipPos(p1);
				out1.color = _BottomColor;
				g2f out2;
				out2.vertex = UnityObjectToClipPos(p2);
				out2.color = _BottomColor;

				g2f conv0;
				conv0.vertex = UnityObjectToClipPos(c0);
				conv0.color = _TopColor;

				g2f conv1;
				conv1.vertex = UnityObjectToClipPos(c1);
				conv1.color = _TopColor;

				g2f conv2;
				conv2.vertex = UnityObjectToClipPos(c2);
				conv2.color = _TopColor;

				// bottom
				outstream.Append(out0);
				outstream.Append(out1);
				outstream.Append(out2);
				
				// side 1
				outstream.Append(conv2);
				outstream.Append(out1);
				outstream.Append(conv1);

				outstream.RestartStrip();
				//outstream.Append(conv2);

				// side 2
				outstream.Append(out0);
				outstream.Append(conv0);
				outstream.Append(out2);
				outstream.Append(conv2);

				outstream.RestartStrip();

				// top
				outstream.Append(conv0);
				outstream.Append(conv1);
				outstream.Append(conv2);

				outstream.RestartStrip();
			}

			fixed4 frag(g2f i) : COLOR
			{
				return i.color;
			}
			ENDCG
		}
	}
}
