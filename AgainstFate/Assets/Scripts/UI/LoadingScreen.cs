using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject LoadScreen;
    public Slider slider;
   

    public void Loading(int num)
    {
        LoadScreen.SetActive(true);

        StartCoroutine(LoadAsyncs(num));
    }
    IEnumerator LoadAsyncs(int num)
    {
        AsyncOperation loadAsyncs = SceneManager.LoadSceneAsync(num);
        loadAsyncs.allowSceneActivation = false;

        while(!loadAsyncs.isDone)
        {
            slider.value = loadAsyncs.progress;

            if(loadAsyncs.progress >= .9f && !loadAsyncs.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsyncs.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
