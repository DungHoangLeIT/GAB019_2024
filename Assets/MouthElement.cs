using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthElement : MonoBehaviour
{
    public int mouthID;
    public MouthEatting mouthEatting;
    public Transform targetPos;

    private void Start()
    {
        mouthID = 0;
    }
    public void Update()
    {
        Transform[] items = GetComponentsInChildren<Transform>();
        mouthEatting = GetComponentInChildren<MouthEatting>();
        mouthID = mouthEatting.mouthEatingID;
        if(items.Length >= 8)
        {
            StartCoroutine(DelayMove());
        }
    }

    private IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(1f);
        mouthEatting.transform.DOMove(targetPos.position, 0.5f);
        mouthEatting.transform.SetParent(targetPos);
    }
}
