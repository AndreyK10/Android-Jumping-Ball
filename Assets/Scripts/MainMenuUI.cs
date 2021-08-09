using UnityEngine;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainMenuHighscore;

    private void Update()
    {
        mainMenuHighscore.text = "Delete Highscore \n(Current Highscore: " + PlayerPrefs.GetInt(ScoreManager.PREFS_HIGHSCORE).ToString() + ")";
    }
}
