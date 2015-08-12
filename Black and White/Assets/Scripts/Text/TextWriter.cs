using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class TextWriter : MonoBehaviour 
{
	private Text text;
	private bool TextRead = false;
	private GameStates gs;
	private float TimeDuration = 0.0f;
	private float ReadTime = 0.0f;
	private bool finalmarker = false;
	public float fadeSpeed = 150.05f;  
	public float fadeCounter = 0.0f;

	private bool FadingIn = false;

	public GameObject FadeCube;
	// Use this for initialization
	void Start () 
	{
		text = gameObject.transform.GetChild (0).GetComponent<Text> ();
		gs = GameObject.Find ("GameStates").GetComponent<GameStates> ();
		text.text = "";
		FadeCube = GameObject.Find ("man").transform.FindChild ("FadeCube").gameObject;
		FadingIn = true;

	}

	void FadeIn()
	{
		fadeCounter += fadeSpeed;
		FadeCube.GetComponent<MeshRenderer> ().material.color = Color.Lerp(Color.white, Color.clear, fadeCounter / 30.0f);

		if(FadeCube.GetComponent<MeshRenderer> ().material.color.a == 0.0f)
		{
			FadingIn = false;
			fadeCounter = 0.0f;
		}
	}

	public void ShowText(int id, float duration, bool final)
	{
		if(gs.Inversed)
		{
			text.color = new Color(0,0,0,255);
			using (var sr = new StreamReader("dark.txt")) 
			{
				for (int i = 1; i < id; i++)
					sr.ReadLine();
				text.text = sr.ReadLine();
				TimeDuration = duration;
				TextRead = true;
				ReadTime = Time.time;
			}
		}
		else
		{
			text.color = new Color(255,255,255,255);
			using (var sr = new StreamReader("light.txt")) 
			{
				for (int i = 1; i < id; i++)
					sr.ReadLine();
				text.text = sr.ReadLine();
				TimeDuration = duration;
				TextRead = true;
				ReadTime = Time.time;
			}
		}

		finalmarker = final;
	}

	public void FadeToBlack ()
		
	{
		fadeCounter += fadeSpeed;
		// Lerp the colour of the texture between itself and black.
		if(gs.Inversed)
			FadeCube.GetComponent<MeshRenderer> ().material.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), fadeCounter / 30.0f);
		else
			FadeCube.GetComponent<MeshRenderer> ().material.color = Color.Lerp(new Color(255, 255, 255, 0), new Color(255, 255, 255, 1), fadeCounter / 30.0f);
	
		if(FadeCube.GetComponent<MeshRenderer> ().material.color.a == 1.0f)
		{
			text.text = "";
			TimeDuration = 0.0f;
			ReadTime = 0.0f;
			TextRead = false;
			Application.Quit();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(FadingIn)
		{
			FadeIn();
		}

		if(TextRead == true)
		{
			if(Time.time > ReadTime + TimeDuration)
			{
				if(!finalmarker)
				{
					text.text = "";
					TimeDuration = 0.0f;
					ReadTime = 0.0f;
					TextRead = false;
				}
				else
				{
					//GetComponent<GUITexture>().enabled = true;
					FadeToBlack();

				}
			}
		}
	}
}
