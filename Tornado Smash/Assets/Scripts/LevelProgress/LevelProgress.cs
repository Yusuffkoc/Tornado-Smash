using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{

    static public int CubeNumbers;

    [SerializeField]
    private GameObject levelCompleteText;
    [SerializeField]
    private GameObject levelStartText;

    [SerializeField]
    private Image barFill;
    [SerializeField]
    private Image circle2;

    private Touch touch;

    private void Awake()
    {
        barFill.fillAmount = 0;
        circle2.fillAmount = 0;
        CubeNumbers = LearnCubeNumbers();
        levelCompleteText.SetActive(false);
        levelStartText.SetActive(true);
    }

    private int LearnCubeNumbers()
    {
        return GameObject.FindGameObjectsWithTag("Cube").Length;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            StartLevel();

        }

        if (CubeNumbers <= 0)
        {
            CompleteLevel();
        }
        else
        {
            ProgressBar();
        }


    }

    private void StartLevel()
    {
        levelStartText.SetActive(false);
    }

    private void ProgressBar()
    {
        
        barFill.fillAmount = 1 / (float)CubeNumbers * 100;
        
    }

    private void CompleteLevel()
    {
        circle2.fillAmount = 1;
        levelCompleteText.SetActive(true);

    }
}
