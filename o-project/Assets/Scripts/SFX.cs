using UnityEngine;

public class SFX : MonoBehaviour
{
    public BallMovement bm;

    public AudioSource ballHit;
    public AudioClip zhwoop;

    public void PlayBallHit()
    {
        if (bm.ballHitWall)
        {
            ballHit.Play();
        }
    }

    private void OnTriggerEnter()
    {
        ballHit.Play ();
    }
}
