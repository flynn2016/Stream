Shader "VueCode/UnlitMod"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		
        _Cutoff("Alpha cutoff", Range(0,1)) = 0.5
		_Stroke("Stroke Alpha", Range(0,1)) = 0.1
		_ColorDecider_red("Color Decider Red", Range(0,1)) = 0.5
		_ColorDecider_blue("Color Decider Blue", Range(0,1)) = 0.5
		_ColorDecider_green("Color Decider Green", Range(0,1)) = 0.5


		_WaterColor_1("WaterColor_1", Color) = (1,0,0,1)
	    _StrokeColor_1("Stroke Color_1", Color) = (1,1,1,1)

		_WaterColor_2("WaterColor_2", Color) = (1,0,0,1)
        _StrokeColor_2 ("Stroke Color_2", Color) = (1,1,1,1)

		_WaterColor_3("WaterColor_3", Color) = (1,0,0,1)
		_StrokeColor_3("Stroke Color_3", Color) = (1,1,1,1)

    }
    SubShader
    {
        Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout" }
        LOD 100

        Lighting Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                half2 texcoord : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _Cutoff;
			fixed _ColorDecider_red;
			fixed _ColorDecider_blue;
			fixed _ColorDecider_green;

			fixed _Stroke;
			half4 _StrokeColor_1;
            half4 _StrokeColor_2;
			half4 _StrokeColor_3;
			half4 _WaterColor_1;
			half4 _WaterColor_2;
			half4 _WaterColor_3;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
				fixed4 col = tex2D(_MainTex, i.texcoord);
                clip(col.a - _Cutoff);

                if(col.a < _Stroke){
					if (col.r > _ColorDecider_red) {
						col = _StrokeColor_1;
					}
					else if (col.b>_ColorDecider_blue) {
						col = _StrokeColor_2;
					}
					else if(col.g>_ColorDecider_green) {
						col = _StrokeColor_3;
					}
                }
                else{
                    if(col.r> _ColorDecider_red){
						col = _WaterColor_1;
                    }
					else if (col.b>_ColorDecider_blue) {
						col = _WaterColor_2;
					}
                    else if(col.g > _ColorDecider_green){
						col = _WaterColor_3;
                    }
                }
                return col;
            }
            ENDCG
        }
    }
}