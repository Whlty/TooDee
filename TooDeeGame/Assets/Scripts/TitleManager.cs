using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    private float showTime;
    private float fadeTime;

    private void Update()
    {
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;
            if (showTime < fadeTime)
            {
                titleText.alpha = showTime / fadeTime;
            }
        }
        else
        {
            showTime = 0;
            titleText.text = "";
        }

    }

    public void NewTitle(string text, float time = 1f, float startFade = 0f, Color? color = null)
    {
        fadeTime = startFade;
        titleText.color = color ?? Color.white;
        titleText.alpha = 1f;
        titleText.text = text;
        showTime = time;

    }

}
