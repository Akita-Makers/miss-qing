using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public float LoadingDelay;
    public IEnumerator LoadScene(string loadingScene)
    {
        yield return new WaitForSeconds(LoadingDelay);
        //loading the next scene while still running the current scene :)
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadingScene);
    }

    public void Load(string loadingScene)
    {
        StartCoroutine(LoadScene(loadingScene));
    }
}
