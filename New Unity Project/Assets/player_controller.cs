using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
	public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded;
	public float jumpPower = 6.5f;   //jump power of the player

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;
	private bool doubleJump;    

    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();  //looks for a Rigid Body
	anim=GetComponent<Animator>();    //looks for the animator component
    }

    
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
	anim.SetBool("grounded", grounded);

	if(Input.GetKeyDown(KeyCode.UpArrow)){   //we want to know if we are`pushing the up arrow
		if(grounded){
			jump=true;
			doubleJump=true;
		}else if (doubleJump){
			jump=true;
			doubleJump=false;  //not allowing the player to jump three times consecutively
		}
	}
    }

    void FixedUpdate(){

		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x*=0.75f;

		if(grounded){

		rb2d.velocity = fixedVelocity;

		}

		float h = Input.GetAxis("Horizontal");  //detects automatically when left or right buttons are pressed
		
		rb2d.AddForce(Vector2.right*speed*h);
		
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if(h>0.1f){  //the player is going to the right
			transform.localScale = new Vector3(1f,1f,1f);   //the eyes of the player are looking to the right
		}

		if(h<-0.1f){  //the player is going to the left
			transform.localScale = new Vector3(-1f,1f,1f);    //the eyes of the player are looking to the left
		}

		if(jump){   //if is true we are pressing the arrow key and we are jumping, we add a force 
			rb2d.velocity = new Vector2(rb2d.velocity.x,0);
			rb2d.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
			jump=false;   //when we have made the jump, we put it to false to avoid jumping again in the next loop, just we want to wait for the user to press the key again
		}
			
	}

   void OnBecameInvisible(){  //detects when the player became invisible and it appears again in that oint assign in the vector

	transform.position=new Vector3(-1,0,0);

  }
 
  public void EnemyJump(){
	jump=true;
  }
}
