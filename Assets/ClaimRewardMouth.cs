using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaimRewardMouth : MonoBehaviour
{
    public GameObject adIcon;
    public GameObject spriteRenderer;
    private bool isPush = true;
    public void Awake()
    {
        // Save a Reference to the component as our singleton instance
        Instance = this;
    }
    public static ClaimRewardMouth Instance { get; private set; }
    private void OnMouseDown()
    {
        if(isPush == true && GameController.Instance.isPush)
        {
            isPush = false;
            ClickAdReward();
        }
    }

    public void ClickAdReward()
    {
        adIcon.SetActive(false);
        spriteRenderer.SetActive(false);
        GameController.Instance.UnlockMouth();
    }
}
