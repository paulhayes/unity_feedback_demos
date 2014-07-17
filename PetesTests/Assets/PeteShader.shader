Shader "Custom/PeteShader" 
{
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _VertsColor("Verts fill color", Float) = 0 
		_VertsColor2("Verts fill color 2", Float) = 0
		_Distance("fall off", Float) = 0


    }
 
    SubShader {
        Pass {
            ZTest Always Cull Off ZWrite Off Fog { Mode off }
 
            CGPROGRAM
 
            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest
            #include "UnityCG.cginc"
            #pragma target 3.0
 
            struct v2f
            {
                float4 pos      : POSITION;
                float2 uv       : TEXCOORD0;
                float4 scr_pos 	: TEXCOORD1;


            };
 
            uniform sampler2D _MainTex;
 			uniform float _VertsColor;
			uniform float _VertsColor2;
			uniform float _Distance;
		
 
            v2f vert(appdata_img v)
            {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord);
                o.scr_pos = ComputeScreenPos(o.pos);
                
                return o;
            }
 
            half4 frag(v2f i): COLOR
            {
      
                
                float2 ps = i.scr_pos.xy *_ScreenParams.xy / i.scr_pos.w;
                
                float2 cp = float2(_ScreenParams.x/2 + _SinTime.w * _ScreenParams.x/4 ,_ScreenParams.y/2+ _CosTime.w * _ScreenParams.y/2 );
            	float curDistance  = distance(cp, ps);
            	i.uv.x += curDistance/ _Distance *_SinTime.w;
            	i.uv.y += curDistance/ _Distance*_SinTime.w;
                half4 color = tex2D(_MainTex, i.uv);
                
                
                
                int pp = (int)ps.x % 3; 
				float4 outcolor = float4(0, 0, 0, 1);
				float4 muls = float4(_VertsColor, _VertsColor, _VertsColor, _VertsColor);
				//_VertsColor2 *= _SinTime;
				
				if (pp == 1) { muls.r = 1; muls.g = _VertsColor2; }
    				else if (pp == 2) { muls.g = 1; muls.b = _VertsColor2; }
        				else { muls.b = 1; muls.r = _VertsColor2; } 
        			
        		color = color * muls;
				//color = muls;
				return color;
				/*
				if (pp == 1) outcolor.r = color.r;
    			else if (pp == 2) outcolor.g = color.g;
        		else outcolor.b = color.b;
				return outcolor;
				*/
               
            }
 
            ENDCG
        }
    }
    FallBack "Diffuse"
}