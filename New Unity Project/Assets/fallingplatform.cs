using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatform : MonoBehaviour
{
    public float fallDelay=1f;   //delay time to fall
    public float respawnDelay=5f;

    private Rigidbody2D rb2d;
    private PolygonCollider2D pc2d;
    private Vector3 start;

    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
	pc2d=GetComponent<PolygonCollider2D>();
	start=transform.position;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
	if(col.gameObject.CompareTag("Player")){
		Invoke("Fall", fallDelay);   //when the fall delay time finish, the platform falls		
		Invoke("Respawn", fallDelay+respawnDelay); //after falling, we wait for the respawn time to finish nd then the platform appears again
	}
    }

   void Fall(){
	rb2d.isKinematic=false;
	pc2d.isTrigger=true;

	}

    void Respawn(){
	transform.position=start;
	rb2d.isKinematic=true;
	rb2d.velocity=Vector3.zero;
	pc2d.isTrigger=false;
	
    }
}
