using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, highscore, scoreTextLS;
    [SerializeField] private GameObject losePanel, pauseButton;


    private void Update()
    {
        scoreText.text = ScoreManager.Score.ToString();
        if (PlayerController.isDead)
        {
            scoreText.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);
            scoreTextLS.text = ScoreManager.Score.ToString();
            highscore.text = "Highscore: " + PlayerPrefs.GetInt(ScoreManager.PREFS_HIGHSCORE).ToString();
        }
    }
}
