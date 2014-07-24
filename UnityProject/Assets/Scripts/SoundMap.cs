using UnityEngine;
using System.Collections;

public class SoundMap : MonoBehaviour 
{
	public int channels;
	public int maxChannel;
	
	public Texture2D banding;
	public Vector3 multiplier;
	private float[] samples;

	void Start () 
	{
		banding = new Texture2D(maxChannel,1,TextureFormat.RGB24,false);
		banding.filterMode=FilterMode.Point;
		samples = new float[channels];
		renderer.material.mainTexture = banding;
	}
	
	void Update ()
	{
		Color c = Color.black;
		audio.GetSpectrumData( samples, 0, FFTWindow.BlackmanHarris );
		for(int i=0;i<maxChannel;i++){
			c.r = samples[i] * multiplier.x;
			c.g = samples[i] * multiplier.y;
			c.b = samples[i] * multiplier.z;
			banding.SetPixel(i,0,c);
		}
		banding.Apply();
	}
	
	
}
