using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitButton : MonoBehaviour {

    public void OnClick()
    {
        SceneManager.LoadScene("Level");
    }
}
