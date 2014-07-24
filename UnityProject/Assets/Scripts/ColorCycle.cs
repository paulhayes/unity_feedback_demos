using UnityEngine;
using System.Collections;

public class ColorCycle : MonoBehaviour 
{
	public Color color1;
	public Color color2;
	public float speed;
	public Material mat;
		
	void Update ()
	{
		mat.color = Color.Lerp( color1, color2, Mathf.PingPong(Time.time + Random.Range(0f,0.2f),speed) );
	}
}
