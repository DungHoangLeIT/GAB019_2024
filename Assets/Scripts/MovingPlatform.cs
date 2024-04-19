using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject lipshead;
    [SerializeField] private Transform orinPos;
    public Transform targetPos;

    public void Moving()
    {
        transform.DOMove(targetPos.position, 0.5f);
        transform.SetParent(targetPos);
    }

    public void ConstainMoving()
    {
        Moving();
    }



}