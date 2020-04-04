using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer_image : MonoBehaviour
{
    
   public float count_time=10f;   //time in which the bomb will be destoyed
   public GameObject explosion;   //object to be destroy
   public Text timer_text;
   public int time_to_text;


    void Start()
    {
        
    }

   
    void Update()
    {
        count_time-=Time.deltaTime;
	time_to_text=(int)count_time;
        timer_text.text=time_to_text.ToString();
	if(count_time<=0){
	autodestroy();  //if the time is 0 we call the funtion autodestroy
	}
    }

    void autodestroy(){
	if(explosion!=null){
		Instantiate(explosion,transform.position, transform.rotation);   //i create our explosion object
	}
		Destroy(gameObject);
		Debug.Log("GAMEOVER!");
		Application.Quit();
		restart_game();
		score_value.score_counter=0;
	
    }

    void restart_game(){
	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
