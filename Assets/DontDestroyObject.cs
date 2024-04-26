using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObject : MonoBehaviour
{
    public static DontDestroyObject Instance { get; private set; }
    public void Awake()
    {
        // Save a Reference to the component as our singleton instance
        Instance = this;
        if (transform.childCount > 0)
            DontDestroyOnLoad(this.gameObject);
        else
            Destroy(this.gameObject);
    }
    void Start()
    {
        Application.targetFrameRate = 120;
    }



}