using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoxElement : MonoBehaviour
{
    public List<BoxElement> boxElements;
    private ItemElement currentItemElement;
    private MouthElement[] mouthElements;
    private void OnMouseDown()
    {
        currentItemElement = GetComponentInChildren<ItemElement>();
        mouthElements = GameController.Instance.mouthElements;
        for(int i = 0; i < mouthElements.Length; i++)
        {
            if(currentItemElement.itemID == mouthElements[i].mouthID)
            {
                currentItemElement.transform.DOMove(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform.position, 0.5f);
                currentItemElement.transform.SetParent(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform);
                currentItemElement.transform.DOScale(0.5f, 0.5f);
                foreach (BoxElement box in boxElements) box.MovingNext();
                break;
            }
            if(mouthElements[i].mouthID == 0)
            {
                currentItemElement.transform.DOMove(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform.position, 0.5f);
                currentItemElement.transform.SetParent(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform);
                currentItemElement.transform.DOScale(0.5f, 0.5f);
                foreach (BoxElement box in boxElements) box.MovingNext();
                break;
            }
        }
    }


}
