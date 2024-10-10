using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    public Transform[] dotPositions;

    public void MoveDotHighlight()
    {
        transform.position = dotPositions[GameSettings.dotIndex].position;
        GameSettings.dotIndex++;
        if(GameSettings.dotIndex >= dotPositions.Length)
            GameSettings.dotIndex = 0;
    }
}
