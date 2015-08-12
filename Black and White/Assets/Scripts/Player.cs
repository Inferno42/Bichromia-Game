using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private GameStates gs;

	private Rigidbody2D body;

	private Animator animator;

	[SerializeField]
	private float xVel = 0.0f;

	[SerializeField]
	private float xInc = 0.1f;

	[SerializeField]
	private float xVelMax = 10.0f;
	
	[SerializeField]
	private float yVel = 0.0f;
	
	// Use this for initialization
	void Start () 
	{
		gs = GameObject.Find ("GameStates").GetComponent<GameStates> ();
		body = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void HandleMovement()
	{
		if(Input.GetKey(KeyCode.D))
		{
			xVel += xInc;
			xVel = Mathf.Clamp(xVel, 0.0f, xVelMax);
		}
		if(Input.GetKey(KeyCode.A))
		{

			xVel -= xInc;
			xVel = Mathf.Clamp(xVel, -xVelMax, 0.0f);
		}

		if(xVel < 0.0f)
		{
			gameObject.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
			animator.SetBool("Running", true);
		}
		else if(xVel > 0.0f)
		{
			gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			animator.SetBool("Running", true);
		}

		if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			if(xVel < 0.0f) //Was moving left
			{
				xVel = Mathf.Clamp(xVel + 0.3f, xVel, 0.0f);
			}
			else if(xVel > 0.0f) //Was moving right
			{
				xVel = Mathf.Clamp(xVel - 0.3f, 0.0f, xVel);
			}

			animator.SetBool("Running", false);

		}


		if(xVel != 0.0f)
		{
			body.AddForce(new Vector2(xVel*4, 0.0f));
			body.velocity = new Vector2(Mathf.Clamp (body.velocity.x,-xVelMax,xVelMax),body.velocity.y);
		}
	}

	void HandleShift()
	{
		if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
		{
			gs.Inversed = !gs.Inversed;
			if(gs.Inversed)
				gameObject.layer = LayerMask.NameToLayer("Black");
			else
				gameObject.layer = LayerMask.NameToLayer("White");


			Camera.main.transform.Rotate(new Vector3(0, 0, Random.Range(0,6)));


		}
	}

	
	// Update is called once per frame
	void Update () 
	{
		Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.rotation.eulerAngles, Vector3.zero, 3 * Time.deltaTime);

		HandleMovement ();
		HandleShift ();
	}
}
