using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject startPanel = null;
    [SerializeField] private GameObject explanPanel = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartButtonClick()
    {
        startPanel.SetActive(false);
        explanPanel.SetActive(true);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void RetryButtonClick()
    {
        SceneManager.LoadScene("Play");
    }

    public void ExplanButtonClick()
    {
        explanPanel.SetActive(false);

        // 비행기 출발
        player.SetActive(true);
    }
}
