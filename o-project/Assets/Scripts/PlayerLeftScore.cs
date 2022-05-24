using UnityEngine;
using TMPro;

public class PlayerLeftScore : MonoBehaviour
{
    public TextMeshProUGUI RPlayerScoreText;
    public PlayerScore ps;

    void Update()
    {
        int LPScore = ps.LPScore;
        RPlayerScoreText.text = LPScore.ToString();
    }
}