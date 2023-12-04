using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayTime : MonoBehaviour
{
    public Text playTimeText;
    public static float playTime;
    private int minutes;
    private int seconds;

    public void Update()
    {
        playTime += Time.deltaTime;
        UpdatePlayTimeText();
    }

    public void UpdatePlayTimeText()
    {
        minutes = (int)(playTime / 60);
        seconds = (int)(playTime % 60);
        playTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public int GetMinutes()
    {
        return minutes;
    }
    public int GetSeconds()
    {
        return seconds;
    }
}
