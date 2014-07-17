using UnityEngine;
using System.Collections;

public class Trip : MonoBehaviour {
	public Texture2D tex;
	public Material mat;
	// Use this for initialization
	void Start () {
		tex = new Texture2D(Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPostRender() {
		Debug.Log ("hello2");
		tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		tex.Apply();
		mat.mainTexture = tex;


		/*
		// Create a shader that renders white only to alpha channel
		if(!mat) {
			mat = new Material( "Shader \"Hidden/SetAlpha\" {" +
			                   "SubShader {" +
			                   "	Pass {" +
			                   //"		ZTest Always Cull Off ZWrite Off" +
			                   //"		ColorMask A" +
			                   "		Color (1,0,0,1)" +
			                   "	}" +
			                   "}" +
			                   "}"
			                   );
		}
		// Draw a quad over the whole screen with the above shader
		GL.PushMatrix ();
		GL.LoadOrtho ();
		for (var i = 0; i < mat.passCount; ++i) {
			mat.SetPass (i);
			GL.Begin( GL.QUADS );
			GL.Vertex3( 0, 0, 0.1f );
			GL.Vertex3( 1, 0, 0.1f );
			GL.Vertex3( 1, 1, 0.1f );
			GL.Vertex3( 0, 1, 0.1f );
			GL.End();
		}
		GL.PopMatrix ();	
		*/
	}
}
