using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public Animator animEnd;
    private int score;
    private bool canRestart;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake() {
        if (instance != null) 
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }

    void Start()
    {
        score = 0;
        canRestart = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE : " +score.ToString();

        if(canRestart)
        {
            if (Input.GetKeyDown (KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
        }
    }

    public void AddScore()
    {
        score += 1;
        FindObjectOfType<PlayerManager>().ResetPlayer();
    }

    public void EndGame()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = false;
        canRestart = true;
        endScoreText.text = "SCORE FINAL : " +score.ToString();
        animEnd.SetTrigger("FinishGame");
    }
}
