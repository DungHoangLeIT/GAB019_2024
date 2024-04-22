using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MouthElement[] mouthElements;
    public MouthEatting[] mouthEattings;
    public MouthElement mouthElementPref;
    public Transform mouthSpawn;
    public int numberOfMouth;
    public int numberOfAllMouths;
    public Transform rowController;
    public Transform[] rows;
    public Transform unlockMouthPos;
    public bool isPush = true;

    public LevelData levelData;
    public int levelIndex;

    public void Awake()
    {
        // Save a Reference to the component as our singleton instance
        Instance = this;
    }
    public static GameController Instance { get; private set; }
    private void Start()
    {
        levelIndex = DataController.Instance.LoadValue();
        mouthElements = FindObjectsOfType(typeof(MouthElement)) as MouthElement[];
        numberOfAllMouths = mouthElements.Length;
        isPush = true;
        UpToDateMouth();
    }

    private void Update()
    {
        UpToDateMouth();
         
    }
    public void UpToDateMouth()
    {
      
        mouthElements = FindObjectsOfType(typeof(MouthElement)) as MouthElement[];
        Array.Reverse(mouthElements);
        int i = 0;
        int j = 0;
    }

    public void UnlockMouth()
    {
        mouthElements[numberOfMouth].GetComponentInParent<RowElement>().transform.DOMove(unlockMouthPos.position, 0.25f);
        numberOfMouth++;
    }


}
