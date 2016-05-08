Shader "Mark/ShaderTest"
{
     Properties {
         _Color ("Main Color", Color) = (1,1,1,1)
         _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
         _AlphaMap ("Additional Alpha Map (Greyscale)", 2D) = "white" {}
     }
      
     SubShader {
         Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
         LOD 200
		 Cull Off
			  Pass{
				 CGPROGRAM
				 #include "UnityCG.cginc"
				 #pragma vertex vert_img
				 #pragma fragment frag
      
				 sampler2D _MainTex;
				 float4 _MainTex_ST;
				 sampler2D _AlphaMap;
				 float4 _AlphaMap_ST;
				 float4 _Color;
      
				 float4 frag (v2f_img i) :COLOR{
					 float4 c = tex2D(_MainTex, i.uv*_MainTex_ST.xy+_MainTex_ST.zw) * _Color;
					 c.a * tex2D(_AlphaMap, i.uv*_AlphaMap_ST.xy+_AlphaMap_ST.zw).r;
					 return c;
				 }
				 ENDCG
			 }
     }
      
}