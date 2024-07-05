using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] winObject;
    [SerializeField]
    private GameObject[] loseObject;
    [SerializeField] 
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private int chance = 5;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        scoreText.text = "Chance: " + chance.ToString();

        if(GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            EndGame(winObject);
        }
        else if (GameObject.FindGameObjectWithTag("Enemy") != null && chance <= 0)
        {
            chance = 0;
            EndGame(loseObject);
        }
    }

    private static void EndGame(GameObject[] values)
    {
        Time.timeScale = 0f;
        foreach (GameObject condition in values)
        {
            condition.SetActive(true);
        }
    }

    public void DecreaseChance()
    {
        chance--;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
