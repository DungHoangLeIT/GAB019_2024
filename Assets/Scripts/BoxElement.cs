using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxElement : MonoBehaviour
{
    public Transform targetPos;
    public int boxID;
    private ItemElement currentItemElement;
    public void MovingNext()
    {
        if(boxID != 0)
        {
            currentItemElement = GetComponentInChildren<ItemElement>();
            currentItemElement.transform.DOMove(targetPos.position, 0.5f);
            currentItemElement.transform.SetParent(targetPos);
        }
    }
}
