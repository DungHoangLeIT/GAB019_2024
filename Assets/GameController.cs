using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int timeDelayMovement;
    public MouthElement[] mouthElements;
    public MouthEatting[] mouthEattings;
    public List<MouthElement> _mouthElements;
    public Transform mouthSpawn;
    public int numberOfMouth;
    public int mouthUnlockID;
    public int numberOfAllMouths;
    public Transform unlockMouthPos;
    public bool isPush = true;

    [Header("COmbo Function")]
    public bool isInCombo;
    public int comboCount;
    public int numberCountCombo = 0;
    public List<BoxElement> boxElements;
    public List<ItemElement> itemElements;
   
    

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
        timeDelayMovement = 1;
        mouthUnlockID = numberOfMouth;
        levelIndex = DataController.Instance.LoadValue();
        numberOfAllMouths = mouthElements.Length;
        isPush = true;
        UpToDateMouth();
    }

    private void Update()
    {
        itemElements.Clear();
        foreach (var x in boxElements) itemElements.Add(x.GetComponentInChildren<ItemElement>());
        Debug.Log(comboCount);
        UpToDateMouth();
         
    }
    public void UpToDateMouth()
    {
      
        //mouthElements = FindObjectsOfType(typeof(MouthElement)) as MouthElement[];
        _mouthElements.Clear();
        foreach (var x in mouthElements)
        {
            if (x.gameObject.active)
            {
                _mouthElements.Add(x);
            }
        }
    }

    public void UnlockMouth()
    {
        mouthUnlockID += numberOfAllMouths - _mouthElements.Count;
        Debug.Log(mouthUnlockID);
        mouthElements[mouthUnlockID].GetComponentInParent<RowElement>().transform.DOMove(unlockMouthPos.position, 0.2f);
        numberOfMouth++;
    }

    public void ComboCount()
    {

    }
}
