Shader "ZWriter"
{
    SubShader
    {
        Tags{ "RenderType" = "Opaque+1" }
        LOD 200

        Pass
        {
            ZWrite On
            ColorMask 0
        }
    }
}