using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelElement : MonoBehaviour
{
    public int levelID;
    public GameObject nextButton;
    public GameObject previousButton;
    public GameObject noneButton;
    private int currentLevelIndex;
    private int maxLevelIndex;

    public void Update()
    {
        currentLevelIndex = DataController.Instance.LoadValueLevelCurrentIndex();
        maxLevelIndex = DataController.Instance.LoadValueLevelMaxIndex();
        if(levelID  < maxLevelIndex)
        {
            nextButton.SetActive(false);
            previousButton.SetActive(true);
            noneButton.SetActive(false);
        }
        if(levelID  == maxLevelIndex)
        {
            nextButton.SetActive(true);
            previousButton.SetActive(false);
            noneButton.SetActive(false);
        }
        else if(levelID > maxLevelIndex)
        {
            nextButton.SetActive(false);
            previousButton.SetActive(false);
            noneButton.SetActive(true);
        }
    }

    public void OnCLickPlay()
    {
/*        if(maxLevelIndex <= levelID - 1)
        {
            maxLevelIndex = levelID - 1;
        }*/
        DataController.Instance.SaveValue(levelID, maxLevelIndex);
        SceneManager.LoadScene("Gameplay");
    }

    
}
