using System.Collections;
using System.Collections.Generic;
using Engine;
using UnityEngine;

public class TriggerRecognizer : MonoBehaviour
{
    private SimpleExecutionEngine engine;
    // Start is called before the first frame update
    void Start()
    {
        engine = GameObject.Find("SimpleSLREngine").GetComponent<SimpleExecutionEngine>();
        engine.recognizer.AddCallback("Sign", GetSign);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            engine.buffer.TriggerCallbacks();   
    }

    public void GetSign(string sign)
    {
        Debug.Log(sign);
    }
}
