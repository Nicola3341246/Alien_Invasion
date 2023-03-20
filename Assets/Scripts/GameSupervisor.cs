using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSupervisor : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    float kills = 0;

    void Start()
    {
        ScoreText.text = $"Score: {kills}";
    }

    public void ChangeKillScore(float change)
    {
        kills += change;
        ScoreText.text = $"Score: {kills}";
    }
}
