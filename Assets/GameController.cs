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
    public Transform rowController;
    public Transform[] rows;

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

    private void Update()
    {
        UpToDateMouth();
/*        foreach(Transform r in rows)
        {
            if(r.GetChildCount() == 1)
            {
                mouthElements[numberOfMouth].transform.DOMove(mouthSpawn.position, 0.5f);
                transform.SetParent(mouthSpawn);
                numberOfMouth++;
            }
        }*/
         
    }
    public void UpToDateMouth()
    {
        mouthElements = FindObjectsOfType(typeof(MouthElement)) as MouthElement[];
        Array.Reverse(mouthElements);
    }


}
