sampler s0;

int width;
int height;

float4 PixelShaderFunction(float2 coords: TEXCOORD0) : COLOR0
{
    float4 col = tex2D(s0, coords);

	uint ppx = (uint)(coords.x * width) % 3;
	uint ppy = (uint)(coords.y * height) % 3;
	float4 outcolor = float4(0, 0, 0, 1);

	if (ppx == 1) 
	outcolor.r = col.r;
    else if (ppx == 2) outcolor.g = col.g;
    else outcolor.b = col.b;
	
	if(ppy == 1)
	outcolor *= 0.5;
	
	return ((outcolor * 1) + (col * 1)) / 2;
	//return col * 0.5;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}
