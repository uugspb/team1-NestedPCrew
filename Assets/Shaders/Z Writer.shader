Shader "ZWriter"
{
    SubShader
    {
        Tags{ "RenderType" = "Opaque" }
        LOD 200

        Pass
        {
            ZWrite On
            ColorMask 0
        }
    }
}