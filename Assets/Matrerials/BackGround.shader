// BG_shader.shader
// 黄色くグラデーションする
Shader "Custom/BackGround" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Height ("Height", Float) = 0
		_HeightRate ("HeightRate", Float) = 2000
		_Grad ("Grad", Float) = 0.1
		_RampTex ("Albedo (RGB)", 2D) = "white" {} 
		_BackGroundStars ("BackGroundStar", 2D) = "white" {}
	}
	
    SubShader
    {
        
        Pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            // VS2015のグラフィックデバックON
            #pragma enable_d3d11_debug_symbols

            float4 _Color;
            float _Height;
            float _HeightRate;
            float _Grad;
            sampler2D _RampTex;
            sampler2D _BackGroundStars;

            
            
            float rand(float2 co){
                return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
            }
            
            struct VertexInput {
                float4 pos:  POSITION;    // 3D空間座標
                float2 uv:   TEXCOORD0;   // テクスチャ座標
            };

            struct VertexOutput {
                float4 v:    SV_POSITION; // 2D座標
                float2 uv:   TEXCOORD0;   // テクスチャ座標
            };

            // 頂点 shader
            VertexOutput vert(VertexInput input)
            {
                VertexOutput output;
                output.v = mul(UNITY_MATRIX_MVP, input.pos);
                output.uv = input.uv;

                return output;
            }

            // ピクセル shader
            fixed4 frag( VertexOutput output) : SV_Target
            {
                float2 tex = output.uv;
                //half4 stars = tex2D(_BackGroundStars, tex);
                                
                // 黄色→白色のグラデーション
                float4 color = tex2D (_RampTex, float2(_Height/_HeightRate+_Grad*tex.y, 0.5));
                //color.rgb = fixed4(stars.x, stars.y, stars.z, 1.0); 
                return fixed4(color.x , color.y , color.z , 1.0);
            }

            ENDCG
        }
    }
}