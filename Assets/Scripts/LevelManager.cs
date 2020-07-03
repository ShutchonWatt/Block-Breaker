using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name) {
        Debug.Log("Level load requested for:" +name);
        Brick.breakableCount = 0;
        Application.LoadLevel(name);
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel+1);
    }

    public void BrickDestoyed()
    {
        if (Brick.breakableCount <= 0){
            LoadNextLevel();
        }

    }
}
