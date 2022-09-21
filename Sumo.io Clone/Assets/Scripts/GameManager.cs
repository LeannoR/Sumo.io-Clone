using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public Timer timer;
    public GameObject PauseButtonUI;
    public GameObject ResumeButtonUI;
    public bool isGamePaused = false;
    public void Update()
    {
        PlayerFallControl();
        RestartGame();
        PauseAndResumeControl();
    }

    public void RestartGame()
    {
        if(players.Count == 1 || players[0].transform.position.y <= -2)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PauseAndResumeControl()
    {
        if(isGamePaused == false)
        {
            Resume();
        }
        else if(isGamePaused == true)
        {
            Pause();
        }
    }
    public void Pause()
    {
        PauseButtonUI.SetActive(false);
        ResumeButtonUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Resume()
    {
        ResumeButtonUI.SetActive(false);
        PauseButtonUI.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void PlayerFallControl()
    {
        for(int i = 0; i <= players.Count -1; i++)
        {
            if(players[i].transform.position.y <= -3)
            {
                Destroy(players[i]);
                players.RemoveAt(i);
            }
        }
    }
}
