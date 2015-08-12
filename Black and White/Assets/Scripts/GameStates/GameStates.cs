using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour 
{

	[SerializeField]
	private bool inversed = false;

	public bool Inversed
	{
		get { return inversed; }
		set { inversed = value; }
	}

	public enum GameState
	{
		STATE_PLAYING,
		STATE_PAUSED
	}

	private GameState state;

	public GameState State
	{
		get { return state; }
		set { state = value; }
	}

	[SerializeField]
	public int BlackLayer;
	
	[SerializeField]
	public int WhiteLayer;

	void Start ()
	{

		BlackLayer = LayerMask.NameToLayer ("Black");
		

		WhiteLayer  = LayerMask.NameToLayer ("White");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Inversed)
		{
			//Camera.main.backgroundColor = new Color(0,0,0);
		}
		else
		{
			//Camera.main.backgroundColor = new Color(255, 255, 255);
		}
	}
}
