using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button quitBtn;
    void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScence);
        });
        quitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
