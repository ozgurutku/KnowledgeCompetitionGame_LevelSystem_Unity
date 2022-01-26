using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    public int buildIndex = 0;
    public ArrayList answers = new ArrayList { "C", "C", "C", "B", "C" };
    
    private void Start() 
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        Text levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Level " + buildIndex.ToString();
    }

    public void NextLevel()
    {
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");

        if(buildIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }

        if (Convert.ToString(EventSystem.current.currentSelectedGameObject.name) == (string)answers[buildIndex - 1])
        {
            if (buildIndex == 5)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(buildIndex + 1);
            }
           
        }

    }
}
