using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HomeLevelController : MonoBehaviour
{
    public List<Button> levelButton;
    public bool restart;

    private void Start()
    {
        if (restart)
        {
            PlayerPrefs.DeleteAll();
        }
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");

        for(int i = 0; i < levelButton.Count; i++)
        {
            if(i<=saveIndex)
            {
                levelButton[i].interactable = true;
            }
            else
            {
                levelButton[i].interactable = false;
            }
        }
    }

    public void LevelSelect()
    {
        int level = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene(level);
    }
}
