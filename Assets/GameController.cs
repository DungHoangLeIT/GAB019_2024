using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MouthElement[] mouthElements;

    public void Awake()
    {
        // Save a Reference to the component as our singleton instance
        Instance = this;
    }
    public static GameController Instance { get; private set; }
    private void Start()
    {
        UpToDateMouth();
    }
    public void UpToDateMouth()
    {
        mouthElements = FindObjectsOfType(typeof(MouthElement)) as MouthElement[];
    }
}
