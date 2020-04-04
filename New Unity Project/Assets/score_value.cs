using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score_value : MonoBehaviour
{
    public static int score_counter=0;
    Text score;

    void Start()
    {
        score=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text="Score:" + score_counter;
    }
}
