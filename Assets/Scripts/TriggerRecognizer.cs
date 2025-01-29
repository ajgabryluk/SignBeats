using System.Collections;
using System.Collections.Generic;
using Engine;
using UnityEngine;
using TMPro;

public class TriggerRecognizer : MonoBehaviour
{
    private SimpleExecutionEngine engine;
    private int score = 0;
    public string recognizedSign = "";
    public TMP_Text scoreText;

    public void RunRecognizer()
    {
        if (!engine) {
            engine = GameObject.Find("SimpleSLREngine").GetComponent<SimpleExecutionEngine>();
            engine.recognizer.AddCallback("Sign", GetSign);
        }
        engine.buffer.TriggerCallbacks();  
    }
    public void GetSign(string sign)
    {
        recognizedSign = sign;
    }
    public void ChangeScore(bool result)
    {
        if(result)
        {
            score += 10;
        }
        else
        {
            score -= 2;
        }
        scoreText.text = score.ToString();
    }
}
