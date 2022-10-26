using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    ScoreManager scoreManager;

    public void Start()
    {
        
    }

    public void ButtonClicked()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.SetInt("BestScoreHard", 0);
    }
}
