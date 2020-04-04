using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private player_controller player;
    private Rigidbody2D rb2d;

    void Start()
    {
        player=GetComponentInParent<player_controller>();   //we are looking for the script player_controller and we can access to its private variables
	rb2d=GetComponentInParent<Rigidbody2D>();
	
    }

   void OnCollisionEnter2D(Collision2D col){   //detects the first momentthe player collisionate with a platform

	if(col.gameObject.tag=="platform"){
		rb2d.velocity=new Vector3(0f,0f,0f);
		player.transform.parent=col.transform;
		player.grounded=true;   
	}

  }
 

   void OnCollisionStay2D(Collision2D col){//checks if we are collisioning with something
	if(col.gameObject.tag=="Ground"){
		player.grounded=true; //we are collising with the ground
	}

	if(col.gameObject.tag=="platform"){
		player.transform.parent=col.transform;
		player.grounded=true;  //we are collising with the platform
	}

	}

  void OnCollisionExit2D(Collision2D col){   //checks if the collision has finished
	if(col.gameObject.tag=="Ground"){
		player.grounded=false;  
	
	}

	if(col.gameObject.tag=="platform"){
		player.transform.parent=null;
		player.grounded=false;
	
	}

	}
}
