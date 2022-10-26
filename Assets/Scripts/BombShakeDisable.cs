using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombShakeDisable : MonoBehaviour
{
    public void ButtonClicked()
    {
        if (PlayerPrefs.GetInt("BombStatus") == 0)
        {
            PlayerPrefs.SetInt("BombStatus", 1);
        }
    }
}