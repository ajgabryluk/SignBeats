using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelSigns : MonoBehaviour
{
    public Dictionary<int, string>[] levelPositions = new Dictionary<int, string>[8];
    public Dictionary<string, GameObject> levelSigns = new Dictionary<string, GameObject>();
    public Dictionary<int, GameObject> activeSigns = new Dictionary<int, GameObject>();
    public int currentRow = 0;
    public Transform[] dotPositions;
    public Transform rhythmBox;

    public void level1PositionsIntialization()
    {
        levelSigns["Dad"] = Resources.Load("SignPrefabs/Dad") as GameObject; 

        levelPositions[0] = new Dictionary<int, string> { { 0, "Dad" },  { 3, "Dad" },  { 7, "Dad" } };
        levelPositions[1] = new Dictionary<int, string> { { 0, "Dad" },  { 2, "Dad" },  { 3, "Dad" } };
        levelPositions[2] = new Dictionary<int, string> { { 0, "Dad" },  { 1, "Dad" },  { 2, "Dad" } };
        levelPositions[3] = new Dictionary<int, string> { { 4, "Dad" },  { 5, "Dad" },  { 6, "Dad" } };
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
            //Place the signs that are meant to be active
            foreach(KeyValuePair<int, string> placement in levelPositions[currentRow])
            {  
                Vector3 spawnPosition = dotPositions[placement.Key].position;
                GameObject newObject = Instantiate(levelSigns[placement.Value], spawnPosition, Quaternion.identity, rhythmBox);
                activeSigns[placement.Key] = newObject;
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
                string signName = levelPositions[currentRow - 1][GameSettings.dotIndex];
                activeSigns[GameSettings.dotIndex].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/SignImages/{signName}Highlighted");
            }
        }
    }
    public void CompleteSign()
    {
        if(activeSigns.ContainsKey(GameSettings.dotIndex - 1))
        {
            if(activeSigns[GameSettings.dotIndex - 1] != null)
            {
                string signName = levelPositions[currentRow - 1][GameSettings.dotIndex - 1];
                activeSigns[GameSettings.dotIndex - 1].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/SignImages/{signName}Completed");   
            }
        }
    }

    void Start()
    {
        level1PositionsIntialization();
    }
}

