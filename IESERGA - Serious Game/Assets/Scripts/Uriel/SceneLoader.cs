using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : Singleton<SceneLoader>
{
    // Load a scene by its name
    public void LoadSceneByName(string sceneName)
    {
        if (IsValidScene(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene " + sceneName + " is not valid or not included in the build settings.");
        }
    }

    // Load a scene by its build index
    public void LoadSceneByIndex(int buildIndex)
    {
        if (IsValidScene(buildIndex))
        {
            SceneManager.LoadScene(buildIndex);
        }
        else
        {
            Debug.LogError("Scene index " + buildIndex + " is not valid or not included in the build settings.");
        }
    }

     public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Game_Manager.Instance.ResetAllVariables();
            UI_Manager.Instance.Initialize();
        }
        else
        {
            Debug.LogWarning("Next scene index " + nextSceneIndex + " is not valid. No more scenes to load.");
        }
    }

    // Check if a scene name is valid and included in the build settings
    private bool IsValidScene(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameInBuild = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            if (sceneNameInBuild == sceneName)
            {
                return true;
            }
        }
        return false;
    }

    // Check if a scene build index is valid and included in the build settings
    private bool IsValidScene(int buildIndex)
    {
        return buildIndex >= 0 && buildIndex < SceneManager.sceneCountInBuildSettings;
    }
}
