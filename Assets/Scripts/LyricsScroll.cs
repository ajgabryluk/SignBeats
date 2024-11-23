using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LyricsScroll : MonoBehaviour
{
    public ScrollRect lyricBox;
    void Start()
    {
        //lyricBox.verticalNormalizedPosition = 1f;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            lyricBox.verticalNormalizedPosition += 0.15f;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            lyricBox.verticalNormalizedPosition -= 0.15f;
        }
    }
}
