

Shader "Water2D/Metaballs_Simple" {
Properties {    
    _MainTex ("Texture", 2D) = "white" { }    
    _Color_r ("Color_1", Color) = (1,1,1,1)
    _Color_g ("Color_2", Color) = (1,0,0,1)
	_Color_b("Color_3", Color) = (1,0,0,1)
    _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5

	_Stroke ("Stroke alpha", Range(0,1)) = 0.1
	_StrokeColor ("Stroke color", Color) = (1,1,1,1)
    _StrokeColor_2 ("Stroke color", Color) = (0,0,0,1)
}

/// </summary>
SubShader {
	Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
	GrabPass{}
    Pass {
    Blend SrcAlpha OneMinusSrcAlpha     
  // Blend One One // Additive
  // Blend One OneMinusSrcAlpha
	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag	
	#include "UnityCG.cginc"	
	float4 _Color_r;
    float4 _Color_g;
	float4 _Color_b;
	sampler2D _MainTex;	
	fixed _Cutoff;
	fixed _Stroke;
	half4 _StrokeColor_1;
    half4 _StrokeColor_2;
	float2 _screenPos;



	float4 _CameraDepthTexture_TexelSize;


	struct v2f {
	    float4  pos : SV_POSITION;
	    float2  uv : TEXCOORD0;
	};	

	float4 _MainTex_ST;		
	v2f vert (appdata_base v){
	    v2f o;
	    o.pos = UnityObjectToClipPos (v.vertex);
	    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
	    return o;
	};


	

	half4 frag (v2f i) : COLOR{		
		half4 texcol= tex2D (_MainTex, i.uv); 
		//half4 finalColor = texcol; 
		clip(texcol.a - _Cutoff);

		if (texcol.a < _Stroke) {
            if(texcol.g>0.1){
			    texcol = _StrokeColor_1;
            }
            else if(texcol.r>0.1){
                texcol = _StrokeColor_2;
            }
		} 
        else 
        {
            if(texcol.r>0.5){
                texcol = _Color_r;
            }
            else if(texcol.g>0.5){
                texcol = _Color_g;
            }
			else if (texcol.b>0.5) {
				texcol = _Color_b;
			}
		}
	 	return texcol;
	 	
	}




	ENDCG

    }
}
Fallback "VertexLit"
} 