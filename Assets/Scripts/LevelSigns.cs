using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSigns : MonoBehaviour
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
    public GameObject lyrics;
    public Animator player;
    public Animator enemy;

    void Start()
    {
        foreach(string word in GameSettings.wordsPerLevel)
        {
            levelSigns[word] = Resources.Load<Sprite>($"Images/SignImages/{word}Normal");
        }
        levelData.LoadJson();
        levelPositions = levelData.levelPositions;
        playedMeasures = levelData.loadedData.playedMeasures;
        lyrics.transform.Find("Viewport/Content").gameObject.GetComponent<TMP_Text>().text = string.Join("\n", levelData.loadedData.lyrics);
        StartCoroutine(WaitForAudioToFinish(GetComponent<AudioSource>()));
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
                player.SetBool("Bounce", true);
                enemy.SetBool("SideToSide", false);
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
            else
            {
                player.SetBool("Bounce", false);
                enemy.SetBool("SideToSide", true);
            }
            currentRow++;
        }
        else if(GameSettings.dotIndex == 7)
        {
            StartCoroutine(lyrics.GetComponent<LyricsScroll>().LerpOverTime());
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
                // Debug.Log("Displayed Sign: " + signName);
                // Debug.Log("Recognized Sign: " + recognizedSign);
                GetComponent<CsvWriter>().AddValue(signName);
                GetComponent<CsvWriter>().AddValue(recognizedSign);
                GetComponent<CsvWriter>().NextRow();
                GetComponent<TriggerRecognizer>().ChangeScore(signName.ToLower() == recognizedSign);
            }
        }
        if(currentMeasure - 2 > 0)
        {
            if(levelPositions[currentMeasure - 2].ContainsKey(7) && GameSettings.dotIndex == 0){
                string signName = levelPositions[currentMeasure - 2][7]; 
                GetComponent<TriggerRecognizer>().RunRecognizer();
                string recognizedSign = GetComponent<TriggerRecognizer>().recognizedSign;
                // Debug.Log("Displayed Sign: " + signName);
                // Debug.Log("Recognized Sign: " + recognizedSign);
                GetComponent<CsvWriter>().AddValue(signName);
                GetComponent<CsvWriter>().AddValue(recognizedSign);
                GetComponent<TriggerRecognizer>().ChangeScore(signName.ToLower() == recognizedSign);
            }
        }
    }
    private IEnumerator WaitForAudioToFinish(AudioSource source)
    {
        yield return new WaitForSeconds(source.clip.length);
        GetComponent<CsvWriter>().WriteCsv();
    }
}

