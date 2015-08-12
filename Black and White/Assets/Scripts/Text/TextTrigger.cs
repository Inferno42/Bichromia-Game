using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour 
{
	[SerializeField]
	private float duration = 0.0f;

	[SerializeField]
	private int id = 0;

	[SerializeField]
	private bool Final = false;


	private TextWriter tw;
	// Use this for initialization
	void Start () 
	{
		tw = GameObject.Find ("Canvas").GetComponent<TextWriter> ();
	}

	void OnTriggerEnter2D(Collider2D o)
	{
		tw.ShowText (id, duration, Final);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
