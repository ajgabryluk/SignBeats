using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCountDown : MonoBehaviour
{
    private int i = 3;
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = i.ToString();
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {
        while(i >= 1)
        {
            yield return new WaitForSeconds(1f);
            GetComponent<TMP_Text>().text = i.ToString();
            i--;
        }
        yield return new WaitForSeconds(1f);
        GetComponent<TMP_Text>().text = "GO!";
        yield return new WaitForSeconds(1f);
        GetComponent<TMP_Text>().text = "";
        controller.GetComponent<LevelSigns>().enabled = true;
        controller.GetComponent<BeatManager>().enabled = true;
        controller.GetComponent<AudioSource>().enabled = true;
    }
}
