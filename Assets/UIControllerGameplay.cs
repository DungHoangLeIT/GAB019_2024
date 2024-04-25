using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerGameplay : MonoBehaviour
{
    public void Awake()
    {
        // Save a Reference to the component as our singleton instance
        Instance = this;
    }
    public static UIControllerGameplay Instance { get; private set; }
    [SerializeField] private GameObject reminderPopup;
    [SerializeField] private GameObject losePop;
    [SerializeField] private GameObject winPopUp;
    [SerializeField] private GameObject popUp;

    public void WinState()
    {
        popUp.SetActive(true);
        reminderPopup.SetActive(false);
        losePop.SetActive(false);
        winPopUp.SetActive(true);
    }
    public void LoseState()
    {
        popUp.SetActive(true);
        reminderPopup.SetActive(false);
        losePop.SetActive(true);
        winPopUp.SetActive(false);
    }
    public void ReminderState()
    {
        popUp.SetActive(true);
        reminderPopup.SetActive(true);
        losePop.SetActive(false);
        winPopUp.SetActive(false);
    }

    public void LoadToMainmenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnClickReminder()
    {
        GameController.Instance.UnlockMouth();
        popUp.SetActive(false);
    }

}
