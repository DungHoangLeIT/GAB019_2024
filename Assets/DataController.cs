using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController Instance { get; private set; }
    public void Awake()
    {
        // Save a Reference to the component as our singleton instance
        Instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SaveValue(0, 1);
    }

    public void ClearData()
    {
        DeleteSave();
    }
    //public string saveFilePath = Application.persistentDataPath + "/save.json";

    // Function to save a value
    public void SaveValue(int value1, int value2)
    {
        SaveData saveData = new SaveData(value1, value2);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    // Function to load a value
    public int LoadValueLevelCurrentIndex()
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/save.json");
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            return saveData.levelCurrentIndex;
        }
        else
        {
            Debug.LogWarning("No saved value found. Returning default value.");
            return 0; // Return default value if no saved value is found
        }
    }

    public int LoadValueLevelMaxIndex()
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/save.json");
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            return saveData.maxLevelIndex;
        }
        else
        {
            Debug.LogWarning("No saved value found. Returning default value.");
            return 0; // Return default value if no saved value is found
        }
    }

    // Function to delete the saved value
    public void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            File.Delete(Application.persistentDataPath + "/save.json");
        }
        else
        {
            Debug.LogWarning("No saved value found. Delete operation aborted.");
        }
    }

    // Data structure for saving
    [System.Serializable]
    public class SaveData
    {
        public int levelCurrentIndex;
        public int maxLevelIndex;

        public SaveData(int value1, int value2)
        {
            levelCurrentIndex = value1;
            maxLevelIndex = value2;
        }
    }
}
