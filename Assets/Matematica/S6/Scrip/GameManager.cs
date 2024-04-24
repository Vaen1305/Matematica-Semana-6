using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;
    [SerializeField] PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

    }
    private void Update()
    {

        score += Time.deltaTime;
        scoreText.text = "Score: " + score.ToString("0");

        if (player.vida <= 0)
        {
            EndGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
