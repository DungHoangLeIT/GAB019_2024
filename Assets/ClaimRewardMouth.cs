using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaimRewardMouth : MonoBehaviour
{
    public GameObject sprite;
    private void OnMouseDown()
    {
        GameController.Instance.UnlockMouth();
/*        sprite.SetActive(false);*/
    }
}
