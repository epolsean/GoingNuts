using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	public float alpha = 0;

	// Use this for initialization
	void Start () 
	{
		Color color = renderer.material.color;
		color.a = 0f;
		renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void fadeToBlack()
	{
		float duration = 1;
		float lerp = (float) Mathf.PingPong(Time.time, duration) / duration;
		
		alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
		Color color = renderer.material.color;
		color.a = alpha;
		renderer.material.color = color;
	}
	public void endFade()
	{
		alpha = 0f;
		Color color = renderer.material.color;
		color.a = alpha;
		renderer.material.color = color;
	}
}
