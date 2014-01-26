Shader "Custom/ImpactShader" {
	Properties {
		_Radius1 ("Radius", Range(0,10)) = 0.5
		_Radius2 ("Blur Radius", Range(0,10)) = 0.1
		_Radius3 ("Inner Alpha", Range(0,1)) = 1
		_InnerColor ("Inner Color Mask", COLOR) = (1,1,1,1)
		_OuterColor ("Outer Color Mask", COLOR) = (1,1,1,1)
		_InsideTex ("Inner Texture", 2D) = "white" {}
		_OutsideTex ("Outer Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 300
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _InsideTex;
		sampler2D _OutsideTex;
		float _Radius1;
		float _Radius2;
		float _Radius3;
		float3 _centerPos;
		float4 _InnerColor;
		float4 _OuterColor;

		struct Input 
		{
			float2 uv_InsideTex;
			float2 uv_OutsideTex;
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 insideTex = tex2D(_InsideTex, IN.uv_InsideTex);
			fixed4 outsideTex = tex2D(_OutsideTex, IN.uv_OutsideTex);
			float deltaR = length(IN.worldPos - _centerPos) - _Radius1 + _Radius2 / 2;
			float weight = 1 - deltaR / _Radius2;
			weight = max(0, min(_Radius3, weight));
			
			o.Albedo = (weight) * insideTex * _InnerColor.rgb + (1 - weight) * outsideTex * _OuterColor.rgb;
			o.Alpha = (weight) * _InnerColor.a + (1 - weight) * _OuterColor.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"

}
