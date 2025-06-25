using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        GameMenuScene,
        LoadingScen,
        GameScence
    }

    private static Scene targerScene;

    public static void Load(Scene _target)
    {
        targerScene = _target;
        SceneManager.LoadScene((int)Scene.LoadingScen);
        Time.timeScale = 1;
    }

    public static void LoadBack()
    {
        SceneManager.LoadScene((int)targerScene);
    }
}
