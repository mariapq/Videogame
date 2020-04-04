using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour
{
    
    public GameObject follow;	
    public Vector2 minCameraPosition, maxCameraPosition;
    public float smoothtime;

    private Vector2 velocity;

    void Start(){
        
    }

    void FixedUpdate(){

        float positionX=Mathf.SmoothDamp(transform.position.x,follow.transform.position.x, ref velocity.x, smoothtime);
	float positionY=Mathf.SmoothDamp(transform.position.y,follow.transform.position.y, ref velocity.y, smoothtime);

	transform.position=new Vector3(
		Mathf.Clamp(positionX,minCameraPosition.x, maxCameraPosition.x),
		Mathf.Clamp(positionY,minCameraPosition.y, maxCameraPosition.y),
		transform.position.z);

	
    }
}
