using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthElement : MonoBehaviour
{
    public int mouthID;
    public MouthEatting mouthEatting;
    public Transform targetPos;
    public Transform[] items;
    public Vector3 nextPos;
    public Transform currentPos;
    private float timeDelaytion;
    private void Start()
    {
        nextPos = new Vector3(transform.position.x, transform.position.y - 2.25f, transform.position.z);
        mouthID = 0;
    }
    public void Update()
    {
        timeDelaytion = GameController.Instance.timeDelayMovement;
        items = GetComponentsInChildren<Transform>();
        mouthEatting = GetComponentInChildren<MouthEatting>();
        mouthID = mouthEatting.mouthEatingID;
        if (gameObject.active)
        {
            currentPos = GetComponentInParent<RowElement>().transform;
        }
        if(items.Length >= 8)
        {
            for (int i = 2; i < items.Length; i++) Destroy(items[i].gameObject, GameController.Instance.timeDeleteElement);
            StartCoroutine(DelayMove());
        }
    }

    public void MovePosNext(Transform x)
    {
        StartCoroutine(MovePosNextDelay(x));
    }

    private IEnumerator MovePosNextDelay(Transform x)
    {
        GameController.Instance.isPush = false;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(GameController.Instance.timeDelayMovement);
        transform.DOMove(x.position, 0.5f);
        transform.SetParent(x);
        yield return new WaitForSeconds(0.5f);
        GameController.Instance.isPush = true;

    }
    private IEnumerator DelayMove()
    {
        yield return new WaitForEndOfFrame();
        timeDelaytion = GameController.Instance.timeDelayMovement;
        yield return new WaitForSeconds(timeDelaytion);
        transform.DOMove(targetPos.position, 0.5f);
        transform.SetParent(targetPos);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
