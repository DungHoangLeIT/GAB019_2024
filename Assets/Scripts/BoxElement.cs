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
    public int foodElementSpawnID;
    private void Start()
    {
        Instantiate(GameController.Instance.foodPrefabs[foodElementSpawnID - 1], transform.position,Quaternion.identity, transform);
    }


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
            StartCoroutine(MoveTime(currentItemElement));
        }
    }
    private void Update()
    {
        MovingNext();
    }

    private IEnumerator MoveTime(ItemElement itemElement)
    {
        itemElement.SetAnimation("Move", true);
        yield return new WaitForSeconds(1f);;
        itemElement.SetAnimation("Idle", true);
    }


}
