using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthController : MonoBehaviour
{
    public void Awake()
    {
        // Save a Reference to the component as our singleton instance
        Instance = this;
    }
    public static MouthController Instance { get; private set; }
    public List<MouthElement> mouthElements;
    public int indexOut = -100;

    private void Update()
    {
        mouthElements.Clear();
        indexOut = -100;
        foreach(MouthElement x in GameController.Instance.mouthElements)
        {
            mouthElements.Add(x);
        }
        for(int i = 0; i < mouthElements.Count; i++)
        {
            if(mouthElements[i].items.Length >= 8)
            {
                for (int j = i + 1; j <= mouthElements.Count; j++) mouthElements[j].MovePosNext(mouthElements[j - 1].currentPos);
            }
        }
    }
}
