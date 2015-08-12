using UnityEngine;
using System.Collections;

public class Debug : MonoBehaviour {
	private GameStates gs;

	// Use this for initialization
	void Start () {
		gs = GameObject.Find ("GameStates").GetComponent<GameStates> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
			

	}
}
