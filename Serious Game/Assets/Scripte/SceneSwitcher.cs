using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher: MonoBehaviour
{
    public string sceneToLoad;
    public GameObject lodingpanel;

    public void LoadScene()
    {
      
        StartCoroutine(LoadSceneAsync(sceneToLoad));
        lodingpanel.SetActive(true);
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
         

            yield return null;
        }
    }
}
