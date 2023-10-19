using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher: MonoBehaviour
{
    public string targetSceneName="Intro"; // Name of the scene to switch to (e.g., "Scene2")

    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
