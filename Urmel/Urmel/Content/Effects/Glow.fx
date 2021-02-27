texture blurSampleTexture;

float t;

sampler mainSampler;
sampler blurSampler = sampler_state
{
	Texture = <blurSampleTexture>;
};

float4 PixelShaderFunction(float2 coords: TEXCOORD0) : COLOR0
{
    float4 colA = tex2D(mainSampler, coords);
	float4 colB = tex2D(blurSampler, coords);

	float4 col;
	col.r = (1.0f - t) * colA.r + t * colB.r;
	col.g = (1.0f - t) * colA.g + t * colB.g;
	col.b = (1.0f - t) * colA.b + t * colB.b;
	col.a = (1.0f - t) * colA.a + t * colB.a;
	return col;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}