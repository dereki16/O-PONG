using System.Collections;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    public BallMovement bm;
    public int timer;

    public AudioSource blip;

    public void Start()
    {
        blip.volume = OptionsMenu.volumeLevel;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            PlayBlip();
            bm.ballHitWall = true;

            bm.BallReposition();
            StartCoroutine(RepositioningTheBall());
        }
    }

    IEnumerator RepositioningTheBall()
    {
        yield return new WaitForSeconds(timer);
        bm.ball.SetActive(true);
    }

    public void PlayBlip()
    {
        blip.Play();
    }
}
