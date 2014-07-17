
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]

public class TVShader : MonoBehaviour
{
	public Material outMaterial;
	public Shader shader;
	public Material Additive;
	private Material _material;
	[Range(0, 1)] public float verts_force = 0.0f;
	[Range(0, 1)] public float verts_force_2 = 0.0f;
	[Range(0, 100000)] public float distanceFalloff = 0.0f;
	
	protected Material material
	{
		get
		{
			if (_material == null)
			{
				_material = new Material(shader);
				_material.hideFlags = HideFlags.HideAndDontSave;
			}
			return _material;
		}
	}
	
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{

		if (shader == null) return;
		Material mat = material;

		mat.SetFloat("_VertsColor", 1-verts_force);
		mat.SetFloat("_VertsColor2", 1-verts_force_2);
		mat.SetFloat("_Distance", distanceFalloff);
		outMaterial.mainTexture = source;
		Graphics.Blit(source, destination, mat);

		//Graphics.Blit(destination, destination, mat);
	}
	
	void OnDisable()
	{
		if (_material)
		{
			DestroyImmediate(_material);
		}
	}
}