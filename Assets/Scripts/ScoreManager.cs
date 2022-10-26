using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshProScoreUI;
    [SerializeField] TextMeshProUGUI TextMeshProBestScoreUI;
    private int _scr;
    private int _bscr;
    public int Score
    {
        get{ return _scr; }
        set {
            _scr = value;
            TextMeshProScoreUI.text = Score.ToString();
        }
    }
    public int BestScore
    {
        get { return _bscr; }
        set
        {
            _bscr = value;
            TextMeshProBestScoreUI.text = BestScore.ToString();
        }
    }
}
