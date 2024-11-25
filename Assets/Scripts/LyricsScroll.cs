using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LyricsScroll : MonoBehaviour
{
    public ScrollRect lyricBox;
    public float scrollAmount = .1f;
    public float lerpTime = 1f;
    // void Start()
    // {
    //     //lyricBox.verticalNormalizedPosition = 1f;
    // }
    // void Update()
    // {
    //     // Trigger the lerp when the space key is pressed
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         StartCoroutine(LerpOverTime());
    //     }
    // }
    void Start()
    {
        
    }
    public IEnumerator LerpOverTime()
    {
        float timeElapsed = 0;
        float startingScrollPosition = lyricBox.verticalNormalizedPosition; 

        while (timeElapsed < lerpTime)
        {
            lyricBox.verticalNormalizedPosition = Mathf.Lerp(startingScrollPosition, startingScrollPosition - scrollAmount, timeElapsed / lerpTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the object reaches the final position
        lyricBox.verticalNormalizedPosition = startingScrollPosition - scrollAmount;
    }
}
