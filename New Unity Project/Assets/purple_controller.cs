using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class purple_controller : MonoBehaviour
{
    public float maxSpeed=1f;
    public float speed=1f;

    private Rigidbody2D rb2d;

    void Start(){
        rb2d=GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate(){
        rb2d.AddForce(Vector2.right*speed);
	float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		
	rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

	if(rb2d.velocity.x>-0.01f && rb2d.velocity.x<0.01f){

		speed=-speed;
		rb2d.velocity=new Vector2(speed, rb2d.velocity.y);	

	}

    }

  void OnTriggerEnter2D( Collider2D col){
	
	if(col.gameObject.tag=="Player"){
		score_value.score_counter++;
		if(transform.position.y<col.transform.position.y){	
			col.SendMessage("EnemyJump");
			Destroy(gameObject);
			
			
		}
	}

	}



}
