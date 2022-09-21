using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float matchTime;
    public float remainingTime;

    public void Start()
    {
        remainingTime = matchTime;
        timeText.text = remainingTime.ToString();
    }
    public void Update()
    {
        remainingTime -= 1 * Time.deltaTime;
        timeText.text = remainingTime.ToString("0");
    }
}
