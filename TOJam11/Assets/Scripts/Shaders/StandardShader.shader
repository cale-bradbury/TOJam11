Shader "Custom/StandardShader" {
	Properties {
		_Red1 ("Red Low Color", Color) = (0,0,0,1)
		_Red2 ("Red High Color", Color) = (1,0,0,1)
		_Green1 ("Green Low Color", Color) = (0,0,0,1)
		_Green2 ("Green High Color", Color) = (0,1,0,1)
		_Blue1 ("Blue Low Color", Color) = (0,0,0,1)
		_Blue2 ("Blue High Color", Color) = (0,0,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		float4 _Red1;
		float4 _Red2;
		float4 _Green1;
		float4 _Green2;
		float4 _Blue1;
		float4 _Blue2;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			float4 c = tex2D (_MainTex, IN.uv_MainTex);
			
			float4 c1 = lerp(_Red1, _Red2, saturate(c.r*2-1));
			float4 c2 = lerp(_Green1, _Green2, saturate(c.g*2-1));
			float4 c3 = lerp(_Blue1, _Blue2, saturate(c.g*2-1));
			c1.rgb*=saturate(c.r*2);
			c2.rgb*=saturate(c.g*2);
			c3.rgb*=saturate(c.b*2);

			o.Albedo = (c1.rgb+c2.rgb+c3.rgb);
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
