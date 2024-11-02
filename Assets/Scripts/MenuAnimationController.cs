using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationController : MonoBehaviour
{
    public Animator menuController;
    public Animator levelInfoController;

    public void ToLevels()
    {
        Debug.Log("ToLevels");
        menuController.SetTrigger("ToLevels");
    }
    public void BackHome()
    {
        menuController.SetTrigger("BackHome");
    }
    public void levelInfoIn()
    {
        levelInfoController.SetBool("LevelIn", true);
    }
    public void levelInfoOut()
    {
        levelInfoController.SetBool("LevelIn", false);
    }

}
