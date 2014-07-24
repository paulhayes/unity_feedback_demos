using UnityEngine;
using System.Collections;
using System.Linq;

public class Feedback : MonoBehaviour 
{

	Texture2D lastScreenCapture;
	public Renderer renderQuad;

	void Awake () 
	{
		lastScreenCapture = new Texture2D(Screen.width,Screen.height);
		lastScreenCapture.SetPixels( lastScreenCapture.GetPixels().Select(c=>Color.black).ToArray() );
		lastScreenCapture.Apply();
		renderQuad.material.mainTexture = lastScreenCapture;
		
		float aspectRatio = 1f * Screen.width / Screen.height;
		renderQuad.transform.localScale = new Vector3(aspectRatio,1f,1f);
		
	}
	
	void Start(){
	
	}
	
	void Update ()
	{
		
	}
	
	void OnPostRender(){
		if( Camera.current == Camera.main ){
			lastScreenCapture.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0);
			lastScreenCapture.Apply();
            
		}
	}
}
