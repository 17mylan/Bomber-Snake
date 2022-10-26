using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagerHard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshProScoreHardUI;
    [SerializeField] TextMeshProUGUI TextMeshProBestScoreHardUI;
    private int _scrh;
    private int _bscrh;
    public int ScoreHard
    {
        get{ return _scrh; }
        set {
            _scrh = value;
            TextMeshProScoreHardUI.text = ScoreHard.ToString();
        }
    }
    public int BestScoreHard
    {
        get { return _bscrh; }
        set
        {
            _bscrh = value;
            TextMeshProBestScoreHardUI.text = BestScoreHard.ToString();
        }
    }
}
