using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class LoadSignPositions : MonoBehaviour
{
    public class RhythmData
    {
        public List<Dictionary<string, string>> rhythm { get; set; }
        public List<int> playedMeasures { get; set; }
        public List<string> lyrics { get; set; }
    }

    public string jsonFilePath = "Resources/LevelDesigns";  // Update with the path to your JSON file
    public List<Dictionary<int, string>> levelPositions = new List<Dictionary<int, string>>();
    public RhythmData loadedData;


    public void LoadJson()
    {
        string fileName = $"Level {GameSettings.selectedLevel}";
        // string jsonContent = File.ReadAllText(Path.Combine(Application.dataPath, jsonFilePath, fileName));
        string jsonContent = Resources.Load<TextAsset>("LevelDesigns/" + fileName).text;
        loadedData = JsonConvert.DeserializeObject<RhythmData>(jsonContent);
        Debug.Log(loadedData.lyrics);
        for (int i = 0; i < loadedData.rhythm.Count; i++)
        {
            levelPositions.Add(new Dictionary<int, string>());
            foreach (var pair in loadedData.rhythm[i])
            {
                levelPositions[i][int.Parse(pair.Key)] = pair.Value;
            }
        }
    }
}
