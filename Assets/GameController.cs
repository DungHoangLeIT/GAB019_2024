using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MouthElement[] mouthElements;
    public MouthEatting[] mouthEattings;
    public List<MouthElement> _mouthElements;
    public Transform mouthSpawn;
    public int numberOfMouth;
    public int numberOfAllMouths;
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
        mouthElements[numberOfMouth].GetComponentInParent<RowElement>().transform.DOMove(unlockMouthPos.position, 0.25f);
        numberOfMouth++;
    }


}
