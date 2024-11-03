using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
public class SongData
{
    public string song;
    public string bpm;
    public int stars;
    public string difficulty;
    public List<string> words;
}

public class LoadLevelDetails : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text difficulty;
    public TMP_Text words;
    public string resourcePath = "LevelSelect"; // Path within the Resources folder
    public SongData songData;

    public void LoadSongData()
    {
        string fileName = $"Level {transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text}";
        TextAsset jsonFile = Resources.Load<TextAsset>(Path.Combine(resourcePath, fileName));
        songData = JsonUtility.FromJson<SongData>(jsonFile.text);
    }

    public void DisplaySongData()
    {
        if (songData != null)
        {
            title.text = songData.song;
            difficulty.text = $"Difficulty: [{songData.difficulty}]";
            words.text = $"Words: [{string.Join(", ", songData.words)}]";

            GameSettings.songTitle = songData.song;
            GameSettings.wordsPerLevel = new List<string>(songData.words);
            Debug.Log(GameSettings.wordsPerLevel[0]);
        }
    }
}
