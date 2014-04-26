using UnityEngine;
using System.Collections;

public class CarvalloController : MonoBehaviour {

	[SerializeField]
	private float runAcceleration;
	[SerializeField]
	private float walkTopSpeed;
	[SerializeField]
	private float runTopSpeed;

	[SerializeField]
	[Range(0,1)]
	private float kineticFriction;
	private float staticFriction = 0.002f;

	[SerializeField]
	private float jumpSpeed;
	[SerializeField]
	[Range(0,1)]
	private float jumpHoldTime;
	[SerializeField]
	[Range(1,2)]
	private float jumpFallGravityAccel;
	private float jumpStartTime = 0;
	private bool wasJumping = false;
	private bool headingDown = false;

	private float initialGravity;

	void Start () {
		initialGravity = rigidbody2D.gravityScale;
	}
	
	void FixedUpdate () {
		FixedRun ();
		if(Input.GetAxis(InputAxes.ATTACK_MELEE) > 0){
		}
		if(Input.GetAxis(InputAxes.ATTACK_RANGED) > 0){
		}
		FixedJump();
	}

	void FixedRun(){
		float horizontal = Input.GetAxis(InputAxes.HORIZONTAL);
		bool running = Input.GetButton(InputAxes.RUN);
		float topSpeed = running ? runTopSpeed * horizontal : walkTopSpeed * horizontal;
		if(horizontal != 0){
			rigidbody2D.AddForce(runAcceleration * horizontal * Time.fixedDeltaTime * transform.right);
			if(Mathf.Abs(rigidbody2D.velocity.x) > topSpeed){
				rigidbody2D.velocity = new Vector2(topSpeed,rigidbody2D.velocity.y);
			}
		} else {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x*kineticFriction,rigidbody2D.velocity.y);
			if(Mathf.Abs(rigidbody2D.velocity.x) < staticFriction){
				rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
			}
		}
	}
	void FixedJump(){
		bool jumping = Input.GetButton(InputAxes.JUMP);
		if(jumping){
			if(!wasJumping){
				jumpStartTime = Time.time;
			}
			if(Time.time - jumpStartTime < jumpHoldTime){
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,jumpSpeed);
			}
			wasJumping = true;
		}
		if(wasJumping){
			if(rigidbody2D.velocity.y < 0){
				headingDown = true;
			}
		}
		if(headingDown){
			rigidbody2D.gravityScale *= jumpFallGravityAccel;
			if(rigidbody2D.velocity.y >= 0 && !jumping){
				rigidbody2D.gravityScale = initialGravity;
				headingDown = false;
				wasJumping = false;
			}
		}
	}
}
