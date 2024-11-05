using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadSign : MonoBehaviour
{
    public string currentSign = "";
    public LevelSigns signInfo;
    public int score = 0;
    public TMP_Text scoreText;

    void Update()
    {
        //{"Cat", "Dad", "Red", "Yellow", "Where"}
        currentSign = signInfo.currentSign;
        scoreText.text = $"Score: {score.ToString()}";
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(currentSign == GameSettings.wordsPerLevel[0])
            {
                score += 50;
            }
            else
            {
                score -= 50;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(currentSign == GameSettings.wordsPerLevel[1])
            {
                score += 50;
            }
            else
            {
                score -= 50;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(currentSign == GameSettings.wordsPerLevel[2])
            {
                score += 50;
            }
            else
            {
                score -= 50;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            if(currentSign == GameSettings.wordsPerLevel[3])
            {
                score += 50;
            }
            else
            {
                score -= 50;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            if(currentSign == GameSettings.wordsPerLevel[4])
            {
                score += 50;
            }
            else
            {
                score -= 50;
            }
        }
    }
}
