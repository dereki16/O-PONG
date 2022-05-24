using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public BallMovement bm;
    public int LPScore;
    public int RPScore;

    public bool lpWins = false;
    public bool rpWins = false;
    public bool someoneWon = false;

    void Start()
    {
        LPScore = 0;
        RPScore = 0;
    }

    void SetScore()
    {
        if (bm.p1Scores)
        {
            LPScore = bm.LPScore;
        }

        if (bm.p2SCores)
        {
            RPScore = bm.RPScore;
        }
    }

    void WinCase()
    {
        if (LPScore == 10)
        {
            lpWins = true;
            someoneWon = true;
        }
        else if (RPScore == 10)
        {
            rpWins = true;
            someoneWon = true;
        }
    }

    void Update()
    {
        SetScore();
        WinCase();
    }
}
