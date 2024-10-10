using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    public bool alive = true;
    
    public void KillSelf()
    {
        alive = !alive;
        gameObject.SetActive(alive);
    }
}
