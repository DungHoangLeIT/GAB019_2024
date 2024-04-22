using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthEatting : MonoBehaviour
{
    public int mouthEatingID = 0;
    public ItemElement[] itemElement;
    public Transform[] mouthTargetPos;
    private void Update()
    {
        itemElement = GetComponentsInChildren<ItemElement>();
        if(itemElement.Length != 0)
        {
            mouthEatingID = itemElement[0].itemID;
        }
    }
}
