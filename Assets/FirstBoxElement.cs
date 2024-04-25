using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoxElement : MonoBehaviour
{
    public List<BoxElement> boxElements;
    public ItemElement currentItemElement;
    private List<MouthElement> mouthElements;
    public int firstBoxID;
    private bool isNotCheck = false;

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
                    currentItemElement.SetAnimation("Eat", true);
                    currentItemElement.transform.DOMove(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform.position, 0.8f);
                    currentItemElement.transform.SetParent(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform);
                    GameController.Instance.numberCountCombo++;
                    if(mouthElements[i].mouthEatting.itemElement.Length == 2)
                    {
                        isNotCheck = true;
                        StartCoroutine(CheckAgain());
                        mouthElements[i].mouthEatting.DiscountTarget();
                        GameController.Instance.comboCount++;
                        GameController.Instance.numberCountCombo = 0;
                        if(GameController.Instance.comboCount == 5)
                        {
                            StartCoroutine(ResetCombo());
                            StartCoroutine(DelayMovement(mouthElements[i].transform));
                        }
                    }
                    if(GameController.Instance.numberCountCombo >= 3)
                    {
                        GameController.Instance.comboCount = 0;
                        GameController.Instance.numberCountCombo = 0;
                    }
                    currentItemElement.transform.DOScale(0.8f, 0.5f);
                    foreach (BoxElement box in boxElements) box.MovingNext();
                    /*if(GameController.Instance.levelData.levelInfors[GameController.Instance.levelIndex + 1].idFoodEated == currentItemElement.itemID)
                    {
                        GameController.Instance.levelData.levelInfors[GameController.Instance.levelIndex + 1].numberOfFoodEated--;
                    }*/
                    break;
                }
                if(mouthElements[i].mouthID == 0)
                {
                    currentItemElement.SetAnimation("Eat", true);
                    GameController.Instance.numberCountCombo++;
                    currentItemElement.transform.DOMove(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform.position, 0.5f);
                    currentItemElement.transform.SetParent(mouthElements[i].mouthEatting.mouthTargetPos[mouthElements[i].mouthEatting.itemElement.Length].transform);
                    currentItemElement.transform.DOScale(0.8f, 0.5f);
                    foreach (BoxElement box in boxElements) box.MovingNext();
                    break;
                }
            }
        }
    }
    IEnumerator CheckAgain()
    {
        yield return new WaitForSeconds(4f);
        isNotCheck = false;
    }
    IEnumerator ResetCombo()
    {
        yield return new WaitForSeconds(4f);
        GameController.Instance.comboCount = 0;
    }

    IEnumerator DelayMovement(Transform _transform)
    {
        yield return new WaitForSeconds(1.5f);
        for (int z = 0; z < GameController.Instance.itemElements.Count; z++)
        {
            if (GameController.Instance.itemElements[z].itemID == currentItemElement.itemID)
            {
                GameController.Instance.itemElements[z].transform.DOMove(_transform.position, 2f);
                GameController.Instance.itemElements[z].transform.SetParent(_transform.transform);
                GameController.Instance.itemElements[z].transform.DOScale(0f, 2f);
            }
        }
    }
    public bool isCheckedBlock = false;
    private void Update()
    {
        if (isNotCheck) {
            isCheckedBlock = false;
        }
        if (!isNotCheck)
        {
            currentItemElement = GetComponentInChildren<ItemElement>();
            mouthElements = GameController.Instance._mouthElements;
            for (int i = 0; i < GameController.Instance.numberOfMouth; i++)
            {
                if (currentItemElement.itemID == mouthElements[i].mouthID)
                {
                    isCheckedBlock = false;
                    break;
                }
                if (mouthElements[i].mouthID == 0)
                {
                    isCheckedBlock = false;
                    break;
                }
                isCheckedBlock = true;
            }
        }
    }
}
