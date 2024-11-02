using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class PopulateLevelSelect : MonoBehaviour
{
    public GameObject levelButton;
    public string resourceFolder;

    void Start()
    {
        int levels = Resources.LoadAll(resourceFolder).Length;
        Debug.Log(levels);
        for(int i = 1; i <= levels; i++ )
        {
            GameObject button = Instantiate(levelButton, Vector3.zero, Quaternion.identity, transform);
            button.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = i.ToString();
        }
    }
}
