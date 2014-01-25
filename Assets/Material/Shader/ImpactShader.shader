Shader "Custom/ImpactShader" {
	Properties {
		_Radius1 ("Radius", Range(0,10)) = 0.5
		_Radius2 ("Blur Radius", Range(0,2)) = 0.1
		_InsideTex ("Inside Texture", 2D) = "white" {}
		_OutsideTex ("Outside Texture", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _InsideTex;
		sampler2D _OutsideTex;
		float _Radius1;
		float _Radius2;
		float3 _centerPos;
		float weight;


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
			weight = 1 - deltaR / _Radius2;
			weight = max(0, min(1, weight));
			

			o.Albedo = weight * insideTex + (1 - weight) * outsideTex;
			o.Alpha = 1;


			/* Check for distance from world origin
			if(length(IN.worldPos - _centerPos) <= (_Radius1 - (_Radius2 / 2.0f)))
			{
				o.Albedo = insideTex.rgb;
				o.Alpha = insideTex.a;
			}
			else if(length(IN.worldPos - _centerPos) <= (_Radius1 + (_Radius2 / 2.0f)))
			{
				o.Albedo = outsideTex.rgb;
				o.Alpha = outsideTex.a;
			}*/
		}
		ENDCG
	} 
	FallBack "Diffuse"

}
