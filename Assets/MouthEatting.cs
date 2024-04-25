using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthEatting : MonoBehaviour
{
    public int mouthEatingID = 0;
    public ItemElement[] itemElement;
    public Transform[] mouthTargetPos;
    private SkeletonAnimation skeleton;

    private void Start()
    {
        skeleton = GetComponent<SkeletonAnimation>();
    }
    private void Update()
    {
        itemElement = GetComponentsInChildren<ItemElement>();
        if(itemElement.Length != 0)
        {
            mouthEatingID = itemElement[0].itemID;
        }
        if(itemElement.Length >= 1 && itemElement.Length < 3 && GameController.Instance.comboCount != 3)
        {
            SetAnimation("Eat", true);
        }
        if(GameController.Instance.comboCount == 4 && itemElement.Length >= 3)
        {
            for (int i = 0; i < 3; i++) Destroy(itemElement[i], 0.2f);
            StartCoroutine(DelayCap("Black_hole", true));
        }
        if(itemElement.Length >= 3 && GameController.Instance.comboCount != 4)
        {
            StartCoroutine(DelayCap("Eat_done", false));
        }
    }

    public void DiscountTarget()
    {
        for (int i = 0; i < GameController.Instance.targetLevels.Length; i++)
        {
            if (GameController.Instance.targetLevels[i].idFoodEated == mouthEatingID)
            {
                GameController.Instance.targetLevels[i].numberOfFoodEated -= 3;
                break;
            }
        }
    }

    IEnumerator DelayCap(string animName, bool loop)
    {
        yield return new WaitForSeconds(0.8f);
        SetAnimation(animName, loop);

    }
    string currentAnim;
    public void SetAnimation(string animName, bool islooped)
    {
        if (currentAnim == animName) return;
        currentAnim = animName;
        skeleton.AnimationState.SetAnimation(0, currentAnim, islooped);
    }

}
