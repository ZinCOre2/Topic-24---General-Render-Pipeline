Shader "Unlit/MyLambert"
{
    Properties
    {
        _Color ( "My Color", Color ) = ( 1, 1, 1, 1 )
    }
    
    SubShader
    {
//        Pass
//        {
//            Cull Front
//            ZTest Greater
//            CGPROGRAM
//            #pragma target 4.0
//            #pragma vertex MyVertShader
//            #pragma fragment MyFragShader
//
//            #include "UnityCG.cginc"
//
//            float4 _Color;
//            float _Power;
//
//            struct myfoodata
//            {
//                float4 pos : POSITION;
//                float4 color : COLOR;
//                float2 uv : TEXCOORD0;
//            };
//
//            struct v2f
//            {
//                float4 vertex : SV_POSITION;
//            };
//            
//
//            v2f MyVertShader (myfoodata v)
//            {
//                v2f o;
//                v.pos *= 1.1;
//                o.vertex = UnityObjectToClipPos(v.pos);
//                return o;
//            }
//
//            half4 MyFragShader (v2f i) : SV_Target
//            {
//                return float4(1, 1, 1, 1);
//            }
//            ENDCG
//        }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex MyVertShader
            #pragma fragment MyFragShader

            #include "UnityCG.cginc"

            float4 _Color;

            struct appdata
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };
            

            v2f MyVertShader (appdata v)
            {
                v2f o;
                o.color = _Color;
                o.color.rgb *= dot(v.normal, _WorldSpaceLightPos0);
                o.vertex = UnityObjectToClipPos(v.pos);
                return o;
            }

            half4 MyFragShader (v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }
    }
}
