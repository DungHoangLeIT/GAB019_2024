using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaimRewardMouth : MonoBehaviour
{
    public GameObject adIcon;
    public GameObject spriteRenderer;
    private bool isPush = true;

    private void OnMouseDown()
    {
        if(isPush == true)
        {
            GameController.Instance.UnlockMouth();
            adIcon.SetActive(false);
            spriteRenderer.SetActive(false);
            isPush = false;
        }
    }
}
