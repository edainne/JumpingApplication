using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public float movementSpeed = 6.0f;
    private bool isGrounded = false;
	
	// START
	void Start ()
	{
		
	}
	
	//UPDATE
	void Update ()
	{
			//if (Input.GetKey (KeyCode.LeftArrow)) player1.transform.Translate (Vector3.left * Time.deltaTime*speed);
			//if (Input.GetKey (KeyCode.RightArrow)) player1.transform.Translate (Vector3.right * Time.deltaTime*speed);
		rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0); //Set X and Z velocity to 0
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0, 0);

	}
	//JUMP
	void Jump()
    {
        if (!isGrounded)
		{
			return;
		}
		
		isGrounded = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.AddForce(new Vector3(0, 600, 0), ForceMode.Force);
		
	}
	// UPDATE
	void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.0f);
		if (isGrounded)
			{		
            	Jump();
			}
    }

	
}