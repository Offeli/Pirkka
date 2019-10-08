using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Build index start from 0, you need to just add 1 to when 10 is collected
    public static int levelIndex = 0;

    // This method jsut changes the level from 1 onwards
    public  void TenCollected()
    {
            levelIndex++;
            SceneManager.LoadScene(levelIndex);
    }

}
