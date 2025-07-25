Shader "Custom/Toon"
/* Based on Roystan's tutorial*/
{
	Properties
	{
		_Color("Color", Color) = (0.5, 0.65, 1, 1)
		_MainTex("Main Texture", 2D) = "white" {}	
		[HDR]
		_AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimAmount("Rim Amount", Range(0, 1)) = 0.716
	}
		SubShader
	{
		Pass
		{
			Tags
			{
				"LightMode" = "ForwardBase"
				"PassFlafs" = "OnlyDirectional"
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase
			
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			struct appdata
			{
				float4 vertex : POSITION;				
				float4 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : NORMAL;
				float3 viewDir : TEXCOORD1;
				SHADOW_COORDS(2)
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				TRANSFER_SHADOW(o)
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = WorldSpaceViewDir(v.vertex);
				return o;
			}
			
			float4 _Color;
			float4 _AmbientColor;
			float4 _RimColor;
			float _RimAmount;

			float4 frag(v2f i) : SV_Target
			{
				float3 viewDir = normalize(i.viewDir);
				float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);

				float4 sample = tex2D(_MainTex, i.uv);
				float3 normal = normalize(i.worldNormal);

				// Shadow
				float shadow = SHADOW_ATTENUATION(i);

				// Lights
				float NdotL = dot(_WorldSpaceLightPos0, normal) - 0.5;
				float lightIntensity = smoothstep(0, 0.05, NdotL * shadow);

				// Rim 
				float4 rimDot = 1 - dot(viewDir, normal);
				float rimIntensity = rimDot * NdotL;
				rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
				float4 rim = rimIntensity * _RimColor;


				float4 light = (lightIntensity * _LightColor0)*0.60;

				return _Color * sample * (_AmbientColor + light + rim);
			}
			ENDCG
		}
	}
}