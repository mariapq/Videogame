using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

	public void start_game(string name){

		SceneManager.LoadScene(name);		

	}
}
