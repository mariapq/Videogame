using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_script : MonoBehaviour
{
    bool active;
    Canvas canvas;    

    void Start()
    {
        canvas=GetComponent<Canvas>();
	canvas.enabled=false;     //it is initialize a false because i want the user to decide by pressing the key when he wants to pause the game
    }

   
    void Update()
    {
        if(Input.GetKeyDown("space")){   //if we press the space, we pause the game
		active=!active;     //change the value to the contrary it has
		canvas.enabled=active;    
		Time.timeScale= (active)? 0: 1f;    // 0 means the game has no velocity, so the game is stopped, and 1 means that the game has its normal velocity
		//so, if canvas.enabled is active is 0 so the game is stopped, otherwise it continues at its normal velocity
	
			
	}
    }

    public void LoadMenu(){
	Debug.Log("Loading menu...");
	Time.timeScale=1f;
	SceneManager.LoadScene("menu");
	}

    public void QuitGame(){
	Debug.Log("Quitting game...");
	Application.Quit();
	}
}
