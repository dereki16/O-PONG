using UnityEngine;
using TMPro;

public class PlayerRightScore : MonoBehaviour
{
    public TextMeshProUGUI RPlayerScoreText;
    public PlayerScore ps;

    void Update()
    {
        int RPScore = ps.RPScore;
        RPlayerScoreText.text = RPScore.ToString();
    }
}
