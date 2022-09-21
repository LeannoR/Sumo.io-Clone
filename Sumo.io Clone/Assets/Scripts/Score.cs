using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;
    public int score = 0;

    public void Update()
    {
       score = player.playerScore;
       scoreText.text = score.ToString();
    }
}
