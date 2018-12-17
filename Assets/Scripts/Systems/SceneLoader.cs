using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private AsyncOperation async;

    public string sceneName;
    public GameObject LoadingUI;

    public Slider slider;


    private void Start()
    {
        

        LoadingUI.SetActive(false);
    }

    private void Update()
    {
    }

    public void onClick()
    {
        LoadStart();
    }

    void LoadStart()
    {
        LoadingUI.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            slider.value = async.progress;

            yield return null;
        }
    }

}
