using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxElement : MonoBehaviour
{
    public Transform targetPos;
    public int boxID;
    public BoxController boxController;
    private ItemElement currentItemElement;



    public void MovingNext()
    {
        targetPos = null;
        for (int i = boxID; i >= 0; i--)
        {
            if (boxController.boxElements[i].GetComponentInChildren<ItemElement>() == null)
            {
                targetPos = boxController.boxElements[i].transform;
            }
        }
        if(boxID != 0)
        {

            currentItemElement = GetComponentInChildren<ItemElement>();
            currentItemElement.transform.DOMove(targetPos.position, 0.5f);
            currentItemElement.transform.SetParent(targetPos);
        }
    }
    private void Update()
    {
        MovingNext();
    }


}
