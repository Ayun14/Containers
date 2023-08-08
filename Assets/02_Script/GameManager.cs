using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject startPanel = null;
    [SerializeField] private GameObject explanPanel = null;
    [SerializeField] private TextMeshProUGUI bulletText = null;

    public int bulletCount = 3;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        bulletCount = 3;
    }

    public void BulletTextUpdate()
    {
        bulletText.text = "x " + bulletCount;
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
