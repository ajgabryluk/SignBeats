using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateLevelSelect : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text difficulty;
    public TMP_Text words;
    public GameObject levelButton;
    public string resourceFolder;
    public MenuAnimationController mac;

    void Start()
    {
        int levels = Resources.LoadAll(resourceFolder).Length;
        Debug.Log(levels);
        for(int i = 1; i <= levels; i++ )
        {
            GameObject button = Instantiate(levelButton, Vector3.zero, Quaternion.identity, transform);
            button.GetComponent<Button>().onClick.AddListener(mac.levelInfoIn);
            button.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = i.ToString();
            button.GetComponent<LoadLevelDetails>().title = title;
            button.GetComponent<LoadLevelDetails>().difficulty = difficulty;
            button.GetComponent<LoadLevelDetails>().words = words;
        }
    }
}
