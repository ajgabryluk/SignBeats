using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSignPositions : MonoBehaviour
{
    [System.Serializable]
    public class RhythmData
    {
        public List<Dictionary<string, string>> rhythm;
        public List<int> playedMeasures;
    }

    public string resourcePath = "LevelDesigns"; // Path within the Resources folder
    public RhythmData loadedData;

    void Start()
    {
        LoadJson();
    }

    private void LoadJson()
    {
        string fileName = $"Level {GameSettings.selectedLevel}";
        TextAsset jsonfile = Resources.Load<TextAsset>(Path.Combine(resourcePath, fileName));
        loadedData = JsonUtility.FromJson<RhythmData>(jsonfile.text);

        // Log the parsed data for verification
        Debug.Log("Loaded Rhythm Data:");
        for (int i = 0; i < loadedData.rhythm.Count; i++)
        {
            Debug.Log($"Rhythm {i}:");
            foreach (var pair in loadedData.rhythm[i])
            {
                Debug.Log($"  Time {pair.Key}: {pair.Value}");
            }
        }

        Debug.Log("Played Measures:");
        foreach (int measure in loadedData.playedMeasures)
        {
            Debug.Log(measure);
        }

    }
}
