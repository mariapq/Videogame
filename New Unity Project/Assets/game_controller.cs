using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_controller : MonoBehaviour
{
    
    public static int counter=0;
    public string score="Diamonds";

    public Text text_score;

    public static game_controller GameController;


     void Awake()
    {
        GameController=this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if(text_score!=null){
		text_score.text=score+counter.ToString();
	}
    }
}
