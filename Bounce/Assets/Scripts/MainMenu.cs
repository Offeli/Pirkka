using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MainMenu mainMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(LevelController.levelIndex);
    }

    public void QuitGame()
    {
        Debug.Log("QUITED!");
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene(LevelController.levelIndex);
            mainMenu.gameObject.SetActive(mainMenu.gameObject.activeSelf);
        }
    }



}
