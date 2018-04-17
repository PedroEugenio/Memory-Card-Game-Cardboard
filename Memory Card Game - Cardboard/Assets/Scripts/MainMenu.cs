using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        StartCoroutine("Play");
    }
    public void MainMenuScene()
    {
        StartCoroutine("MenuScene");
    }
    public void QuitMenu()
    {
        Application.Quit();
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator MenuScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
