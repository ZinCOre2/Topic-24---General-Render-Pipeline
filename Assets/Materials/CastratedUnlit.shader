Shader "Playtika/MyUnlit"
{
    Properties
    {
        _Color ( "My Color", Color ) = ( 1, 1, 1, 1 )
        _Power ( "Color Power", Range( 0.2, 1 ) ) = 0.5
        _MainTex ( "Main Texture", 2D ) = "black" {}
        _MyVector ( "My Vector", Vector ) = ( 0.2, 0.3, 1, 1 )
    }
    
    SubShader
    {
        Pass
        {
            Cull Front
            ZTest Greater
            CGPROGRAM
            #pragma target 4.0
            #pragma vertex MyVertShader
            #pragma fragment MyFragShader

            #include "UnityCG.cginc"

            float4 _Color;
            float _Power;

            struct myfoodata
            {
                float4 pos : POSITION;
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };
            

            v2f MyVertShader (myfoodata v)
            {
                v2f o;
                v.pos *= 1.1;
                o.vertex = UnityObjectToClipPos(v.pos);
                return o;
            }

            half4 MyFragShader (v2f i) : SV_Target
            {
                return float4(1, 1, 1, 1);
            }
            ENDCG
        }
        
        Pass
        {
            Cull Back
            CGPROGRAM
            #pragma target 4.0
            #pragma vertex MyVertShader
            #pragma fragment MyFragShader

            #include "UnityCG.cginc"

            float4 _Color;
            float _Power;

            struct myfoodata
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };
            

            v2f MyVertShader (myfoodata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.pos);
                o.color.rgba = _WorldSpaceLightPos0;
                //o.color.xyz = v.normal.xyz;
                o.color.a = 1;
                return o;
            }

            half4 MyFragShader (v2f i) : SV_Target
            {
                return i.color * _Power;
            }
            ENDCG
        }
    }
}
