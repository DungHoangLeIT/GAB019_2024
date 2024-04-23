using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoxElement : MonoBehaviour
{
    public List<BoxElement> boxElements;
    private ItemElement currentItemElement;
    private List<MouthElement> mouthElements;

    private void OnMouseDown()
    {
        if (GameController.Instance.isPush == true)
        {
            currentItemElement = GetComponentInChildren<ItemElement>();
            mouthElements = GameController.Instance._mouthElements;
            for(int i = 0; i < GameController.Instance.numberOfMouth; i++)
            {
                if(currentItemElement.itemID == mouthElements[i].mouthID)
                {
                    GameController.Instance.numberCountCombo++;
                    currentItemElement.transform.DOMove(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform.position, 0.5f);
                    currentItemElement.transform.SetParent(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform);
                    if(mouthElements[i].mouthEatting.itemElement.Length == 2)
                    {
                        GameController.Instance.comboCount++;
                        GameController.Instance.numberCountCombo = 0;
                    }
                    else if(GameController.Instance.numberCountCombo > 3)
                    {
                        GameController.Instance.comboCount = 0;
                        GameController.Instance.numberCountCombo = 0;
                    }
                    currentItemElement.transform.DOScale(0.75f, 0.5f);
                    foreach (BoxElement box in boxElements) box.MovingNext();
                    if(GameController.Instance.levelData.levelInfors[GameController.Instance.levelIndex + 1].idFoodEated == currentItemElement.itemID)
                    {
                        GameController.Instance.levelData.levelInfors[GameController.Instance.levelIndex + 1].numberOfFoodEated--;
                    }
                    break;
                }
                if(mouthElements[i].mouthID == 0)
                {
                    GameController.Instance.numberCountCombo++;
                    currentItemElement.transform.DOMove(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform.position, 0.5f);
                    currentItemElement.transform.SetParent(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform);
                    currentItemElement.transform.DOScale(0.75f, 0.5f);
                    foreach (BoxElement box in boxElements) box.MovingNext();
                    break;
                }
            }
        }
    }

}
