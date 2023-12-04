using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayTime : MonoBehaviour
{
    public Text playTimeText;
    public static float playTime;

    void Update()
    {
        playTime += Time.deltaTime;
        UpdatePlayTimeText();
    }

    void UpdatePlayTimeText()
    {
        int minutes = (int)(playTime / 60);
        int seconds = (int)(playTime % 60);
        playTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
