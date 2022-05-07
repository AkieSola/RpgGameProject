Shader "Custom/OutLineShader"
{

    Properties

    {

        [Header(OutlineSetiting)]

        [Space(10)]

        //定义轮廓颜色

        _OutlineColor ("OutlineColor", Color) = (1,1,1,1)

        //定义描边长度

        _OutlineLenth ("OutlineLenth", Range(0,0.1)) = 0.05

        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _Glossiness ("Smoothness", Range(0,1)) = 0.5

        _Metallic ("Metallic", Range(0,1)) = 0.0

    }

    SubShader

    {

        Tags { "RenderType"="Opaque"  "Queue"="Transparent"}

  

     //第一个Pass用来扩大物体本身并且渲染单个颜色

        Pass

        {

            ZWrite Off

            CGPROGRAM

            #pragma vertex vert

            #pragma fragment frag

            #include "UnityCG.cginc"

            half4 _OutlineColor;

            half _OutlineLenth;

  

            struct appdata

            {

                float4 vertex : POSITION;

                float2 uv : TEXCOORD0;

                float3 normal : NORMAL;

            };

  

            struct v2f

            {

                float2 uv : TEXCOORD0;

                float4 vertex : SV_POSITION;

            };

  

            v2f vert (appdata v)

            {

                v2f o;

                //对物体本身进行扩展沿着法线方向

                v.vertex.xyz+= v.normal * _OutlineLenth ;

                o.vertex = UnityObjectToClipPos(v.vertex);

  

                return o;

            }

  

            fixed4 frag (v2f i) : SV_Target

            {

                // 给物体上一个纯色

                return _OutlineColor;

            }

  

            ENDCG

        }

        CGPROGRAM

        // Physically based Standard lighting model, and enable shadows on all light types

        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting

        #pragma target 3.0

        sampler2D _MainTex;

  

        struct Input

        {

            float2 uv_MainTex;

        };

  

        half _Glossiness;

        half _Metallic;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.

        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.

        // #pragma instancing_options assumeuniformscaling

        UNITY_INSTANCING_BUFFER_START(Props)

        // put more per-instance properties here

        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)

        {

            // Albedo comes from a texture tinted by color

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) ;

            o.Albedo = c.rgb;

            // Metallic and smoothness come from slider variables

            o.Metallic = _Metallic;

            o.Smoothness = _Glossiness;

            o.Alpha = c.a;

        }

        ENDCG

    }
}
