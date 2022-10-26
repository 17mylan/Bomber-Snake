using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombShakeEnable : MonoBehaviour
{
    public void ButtonClicked()
    {
        if (PlayerPrefs.GetInt("BombStatus") == 1)
        {
            PlayerPrefs.SetInt("BombStatus", 0);
        }
    }
}
