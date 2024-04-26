using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public void Awake()
    {
        // Save a Reference to the component as our singleton instance
        Instance = this;
    }
    public static GameplayController Instance { get; private set; }
    public int currentLevel;
    public List<GameObject> levelPrefabs;

    private void Start()
    {
        currentLevel = DataController.Instance.LoadValueLevelCurrentIndex();
        Instantiate(levelPrefabs[currentLevel - 1]);
    }
}
