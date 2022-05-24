using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI lpWinsText;
    public TextMeshProUGUI rpWinsText;
    public TextMeshProUGUI retryText;

    public GameObject retryButton;
    public PlayerScore ps;

    void Update()
    {
        if (ps.lpWins)
        {
            gameOverText.gameObject.SetActive(true);
            lpWinsText.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
            retryText.gameObject.SetActive(true);
        }
        else if (ps.rpWins)
        {
            gameOverText.gameObject.SetActive(true);
            rpWinsText.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
            retryText.gameObject.SetActive(true);
        }
    }
}
