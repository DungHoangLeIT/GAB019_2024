using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemElement : MonoBehaviour
{
    public int itemID;
    public SkeletonAnimation skeleton;

    private void Start()
    {
        skeleton = GetComponent<SkeletonAnimation>();
    }


    string currentAnim;
    public void SetAnimation(string animName, bool islooped)
    {
        if (currentAnim == animName) return;
        currentAnim = animName;
        skeleton.AnimationState.SetAnimation(0, currentAnim, islooped);
    }
}
