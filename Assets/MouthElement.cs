using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthElement : MonoBehaviour
{
    public int mouthID;
    public int mouthEID;
    public MouthEatting mouthEatting;
    public Transform targetPos;
    public Transform[] items;
    public Vector3 nextPos;
    public Transform currentPos;
    private void Start()
    {
        nextPos = new Vector3(transform.position.x, transform.position.y - 2.25f, transform.position.z);
        mouthID = 0;
    }
    public void Update()
    {
        items = GetComponentsInChildren<Transform>();
        mouthEatting = GetComponentInChildren<MouthEatting>();
        mouthID = mouthEatting.mouthEatingID;
        currentPos = GetComponentInParent<RowElement>().transform;
        if(items.Length >= 8)
        {
            for (int i = 2; i < items.Length; i++) Destroy(items[i].gameObject,1f);
            StartCoroutine(DelayMove());
        }
    }

    public void MovePosNext(Transform x)
    {
        StartCoroutine(MovePosNextDelay(x));
    }

    private IEnumerator MovePosNextDelay(Transform x)
    {
        yield return new WaitForSeconds(1f);
        transform.DOMove(x.position, 0.5f);
        transform.SetParent(x);

    }
    private IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(1f);
        Debug.LogWarning(items.Length);
        transform.DOMove(targetPos.position, 0.5f);
        transform.SetParent(targetPos);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
