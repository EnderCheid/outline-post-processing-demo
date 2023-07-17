Shader "Hidden/OutlineComposite"
{

    SubShader
    {
		HLSLINCLUDE
		#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
		float4 _MainTex_TexelSize;

		TEXTURE2D_SAMPLER2D(_OutlineTex, sampler_OutlineTex);
		float4 _OutlineTex_TexelSize;

		float4x4 unity_MatrixMVP;

		half4 _Color;

		struct v2f
		{
			float2 uv : TEXCOORD0;
			float4 vertex : SV_POSITION;
			float2 screen_pos : TEXCOORD2;
		};

		inline float4 ComputeScreenPos(float4 pos)
		{
			float4 o = pos * 0.5f;
			o.xy = float2(o.x, o.y * _ProjectionParams.x) + o.w;
			o.zw = pos.zw;
			return o;
		}

		inline float4 ObjectToClipPos(float3 pos) {
			return mul(unity_MatrixMVP, float4(pos, 1.0));
		}

		ENDHLSL

		Cull Off
		ZWrite Off
		ZTest Always

		Pass
		{
			HLSLPROGRAM
			#pragma vertex Vert;
			#pragma fragment Frag;

			v2f Vert(AttributesDefault v)
			{
				v2f o;
				o.vertex = float4(v.vertex.xy, 0.0, 1.0);
				o.uv = TransformTriangleVertexToUV(v.vertex.xy);
				o.screen_pos = ComputeScreenPos(o.vertex);
	#if UNITY_UV_STARTS_AT_TOP
				o.uv = o.uv * float2 (1.0, -1.0) + float2 (0.0, 1.0);
	#endif
				return o;
			}

		    float4 Frag (v2f i) : SV_Target
            {
				float4 original = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
				float4 outline = SAMPLE_TEXTURE2D(_OutlineTex, sampler_OutlineTex, i.uv);
				outline.rgb *= _Color;
				
				float4 output = lerp(original, outline, outline.a);
                return output;
            }

			ENDHLSL
        }
    }
}
