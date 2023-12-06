using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndTxt : MonoBehaviour
{
    private TMP_Text m_TextMeshPro;

    private void Awake()
    {
        m_TextMeshPro = GetComponent<TMP_Text>();
    }
    void Start()
    {
        m_TextMeshPro.text = string.Format("{0:00}:{1:00}", GameManager.instance.currentMinutes, GameManager.instance.currentSeconds);
    }

}
