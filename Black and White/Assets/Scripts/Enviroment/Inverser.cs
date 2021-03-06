﻿using UnityEngine;
using System.Collections;

public class Inverser : MonoBehaviour 
{

	private GameStates gs;

	[SerializeField]
	private Material InverseMat;

	[SerializeField]
	private Material SpriteMat;




	private bool PreviousInverseState = false;

	private Renderer renderer;
	// Use this for initialization
	void Start () 
	{
		gs = GameObject.Find ("GameStates").GetComponent<GameStates> ();
		renderer = gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(PreviousInverseState != gs.Inversed)
		{
			if(gs.Inversed)
			{
				if(gameObject.layer == gs.BlackLayer)
					gameObject.layer = gs.WhiteLayer;
				else
					gameObject.layer = gs.BlackLayer;
				renderer.material = InverseMat;
			}
			else
			{
				if(gameObject.layer == gs.BlackLayer)
					gameObject.layer = gs.WhiteLayer;
				else
					gameObject.layer = gs.BlackLayer;
				renderer.material = SpriteMat;
			}
		}
		PreviousInverseState = gs.Inversed;
	}
}
