using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    static public int score = 0;

	
    void OnGUI()
    {


        GUI.Box(new Rect(10, 10, 150, 100), "SCORE: " + score);
    }
}
