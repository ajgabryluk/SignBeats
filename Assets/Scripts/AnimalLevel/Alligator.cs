using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Alligator : MonoBehaviour
{
    public LoadSignPositions levelData;
    public List<Dictionary<int, string>> levelPositions = new List<Dictionary<int, string>>();
    public List<int> playedMeasures;

    public GameObject signPill;
    public Dictionary<string, Sprite> levelSigns = new Dictionary<string, Sprite>();
    public Dictionary<int, GameObject> activeSigns = new Dictionary<int, GameObject>();
    public int currentRow = 0;
    public int currentMeasure = 0;
    public string currentSign = "";
    public Transform[] dotPositions;
    public Transform rhythmBox;

    void Start()
    {
        foreach(string word in GameSettings.wordsPerLevel)
        {
            levelSigns[word] = Resources.Load<Sprite>($"Images/SignImages/{word}Normal");
        }
        levelData.LoadJson();
        levelPositions = levelData.levelPositions;
        playedMeasures = levelData.loadedData.playedMeasures;
    }
    public void PlaceSigns()
    {
        //Only trigger when it is the first beat of a measure
        if(GameSettings.dotIndex == 0)
        {
            //Remove the previously active signs
            if(activeSigns.Count != 0)
            {
                foreach(KeyValuePair<int, GameObject> sign in activeSigns)
                {
                    Destroy(activeSigns[sign.Key]);
                }
                activeSigns = new Dictionary<int, GameObject>();
            }
            if(playedMeasures.Contains(currentRow))
            {
                //Place the signs that are meant to be active
                foreach(KeyValuePair<int, string> placement in levelPositions[currentMeasure])
                {  
                    Vector3 spawnPosition = dotPositions[placement.Key].position;
                    GameObject newObject = Instantiate(signPill, spawnPosition, Quaternion.identity, rhythmBox);
                    newObject.GetComponent<Image>().sprite = levelSigns[placement.Value];
                    activeSigns[placement.Key] = newObject;
                }
                currentMeasure++;
            }
            currentRow++;
        }
    }
    public void LightUpSign() 
    {
        if(activeSigns.ContainsKey(GameSettings.dotIndex))
        {
            if(activeSigns[GameSettings.dotIndex] != null)
            {
                string signName = levelPositions[currentMeasure - 1][GameSettings.dotIndex];
                currentSign = signName;
                activeSigns[GameSettings.dotIndex].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/SignImages/{signName}Highlighted");
            }
        }
        else
        {
            currentSign = "";
        }
        //Debug.Log(currentSign);
    }
    public void CompleteSign()
    {
        if(activeSigns.ContainsKey(GameSettings.dotIndex - 1))
        {
            if(activeSigns[GameSettings.dotIndex - 1] != null)
            {
                string signName = levelPositions[currentMeasure - 1][GameSettings.dotIndex - 1];
                activeSigns[GameSettings.dotIndex - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/SignImages/{signName}Completed");   
                GetComponent<TriggerRecognizer>().RunRecognizer();
                string recognizedSign = GetComponent<TriggerRecognizer>().recognizedSign;
                Debug.Log("Displayed Sign: " + signName);
                Debug.Log("Recognized Sign: " + recognizedSign);
                GetComponent<TriggerRecognizer>().ChangeScore(signName.ToLower() == recognizedSign);
            }
        }
    }
}

