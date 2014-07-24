using UnityEngine;
using System.Collections;

public class PitchOccilate : MonoBehaviour 
{

	public AudioSource audioSource;

	public float min;
	public float max;
	public float freq;

	void Start () 
	{
	
	}
	
	void Update ()
	{
		//0.1, 4, 0.05
		//audioSource.pitch = Mathf.Lerp( min, max, Mathf.PingPong(Time.time,freq));
		audioSource.pitch = Mathf.Lerp( min, max, Mathf.PingPong(freq*Time.time,1));
	}
}
