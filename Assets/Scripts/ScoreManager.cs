using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float score;
    [SerializeField] private float scorePerSecond;
    public static int Score { get; private set; }
    public const string PREFS_HIGHSCORE = "Highscore_v2.0";

    void Start()
    {
        score = 0f;
    }

    void Update()
    {
        score += scorePerSecond * Time.deltaTime;
        Score = Mathf.RoundToInt(score);
        if (PlayerController.isDead)
        {
            if (Score > PlayerPrefs.GetInt(PREFS_HIGHSCORE))
            {
                PlayerPrefs.SetInt(PREFS_HIGHSCORE, Score);
            }
        }
    }
}