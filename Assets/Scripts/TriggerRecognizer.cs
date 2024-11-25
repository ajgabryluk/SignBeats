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

    // Start is called before the first frame update
    void Start()
    {
        engine = GameObject.Find("SimpleSLREngine").GetComponent<SimpleExecutionEngine>();
        engine.recognizer.AddCallback("Sign", GetSign);
    }
    public void RunRecognizer()
    {
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
