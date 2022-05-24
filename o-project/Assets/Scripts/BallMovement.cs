using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public CountdownTimer ct;
    public PlayerScore ps;
    public GameObject ball;
    
    public float speed = 12f;
    [HideInInspector]
    public float ballsX;
    [HideInInspector]
    public float ballsY;
    [HideInInspector]
    public float xDir;
    [HideInInspector]
    public float yDir;
    [HideInInspector]

    public bool xIsPositive = false;
    [HideInInspector]
    public bool yIsPositive = false;
    [HideInInspector]
    public bool ballHitWall = false;

    [HideInInspector]
    public bool p1Scores;
    [HideInInspector]
    public bool p2SCores;
    [HideInInspector]
    public bool lpGotScoredOn = false;
    [HideInInspector]
    public bool rpGotScoredOn = false;
    [HideInInspector]
    public bool gameIsOver = false;

    [HideInInspector]
    public bool lpLastPlayerToHitBall = false;
    [HideInInspector]
    public bool rpLastPlayerToHitBall = false;
    [HideInInspector]
    public bool ballNotHitYet = false;

    [HideInInspector]
    public int LPScore = 0;
    [HideInInspector]
    public int RPScore = 0;
    [HideInInspector]
    public int countdownNumber;
    [HideInInspector] 
    private int timer = 0;

    [HideInInspector]
    public AudioSource blip;

    Vector3 lastPos;
    float threshold = 0.0f; // minimum displacement

    public void PlayBlip()
    {
        blip.Play();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            ballHitWall = true;
        }

        else if (collision.gameObject.tag == "p1")
        {
            PlayBlip();
            lpLastPlayerToHitBall = false;
            rpLastPlayerToHitBall = true;
            ballNotHitYet = false;
        }

        else if (collision.gameObject.tag == "p2")
        {
            PlayBlip();
            rpLastPlayerToHitBall = false;
            lpLastPlayerToHitBall = true;
            ballNotHitYet = false;
        }
    }

    public void BallReposition()
    {
        rb.transform.position = new Vector3(0, 5f, 0);
        // decides direction ball heads after player gets scored on
        if (lpGotScoredOn)
        {
            xDir = Random.Range(-2f, -1f);
            yDir = Random.Range(-1f, 1f);

            rb.transform.position = new Vector3(xDir, yDir, 0f);
            rb.velocity = rb.transform.position * speed;
        }
        if (rpGotScoredOn)
        {
            xDir = Random.Range(1f, 2f);
            yDir = Random.Range(-1f, 1f);

            rb.transform.position = new Vector3(xDir, yDir, 0f);
            rb.velocity = rb.transform.position * speed;
        }
    }

    public void BallStart()
    {
        xDir = Random.Range(-2f, -1f);
        yDir = Random.Range(-2f, 2f);

        rb.transform.position = new Vector3(xDir, yDir, 0f);
        rb.velocity = rb.transform.position * speed;
    }

    public void BallHitBorder()
    {
        lpGotScoredOn = false;
        rpGotScoredOn = false;
        p1Scores = false;
        p2SCores = false;
        if (ballHitWall)
        {
            if (ballsX > 0.0f && lpLastPlayerToHitBall || ballsX > 0.0f && rpLastPlayerToHitBall || ballsX > 0.0f && ballNotHitYet) // and not the first round
            {
                lpGotScoredOn = false;
                rpGotScoredOn = true;

                if (!ps.someoneWon)
                {
                    p1Scores = true;
                    LPScore++;
                }
            }

            else if (ballsX < 0.0f && rpLastPlayerToHitBall && !ps.someoneWon || ballsX < 0.0f && lpLastPlayerToHitBall && !ps.someoneWon ||  ballsX < 0.0f && ballNotHitYet && !ps.someoneWon)
            {
                rpGotScoredOn = false;
                lpGotScoredOn = true;

                if (!ps.someoneWon)
                {
                    p2SCores = true;
                    RPScore++;
                }
            }
            ball.SetActive(false);
            BallReposition();
        }
        ballHitWall = false;
    }

    IEnumerator HidingTheBall()
    {
        // code making ball appear
        yield return new WaitForSeconds(timer);
        ball.SetActive(true);
        // if ball hits the wall, ball disappears again
        BallHitBorder();
    }

    void Start()
    {
        BallStart();
        StartCoroutine(HidingTheBall());
        ballNotHitYet = true;

        speed = SpeedSettings.ballSpeed;
        blip.volume = OptionsMenu.volumeLevel;
    }

    void Update()
    {
        BallHitBorder();

        rb.velocity = rb.velocity.normalized * speed;
        rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, 0f);
        ballsX = rb.transform.position.x;
        ballsY = rb.transform.position.y;

        Vector3 offset = rb.transform.position - lastPos;
        if (offset.x > threshold)
        {
            lastPos = rb.transform.position; // update lastpos
            xIsPositive = true;
        }
        else if (offset.x < -threshold)
        {
            lastPos = rb.transform.position; // update lastpos
            xIsPositive = false;
        }

        if (offset.y > threshold)
        {
            lastPos = rb.transform.position; // update lastpos
            yIsPositive = true;
        }
        else if (offset.x < -threshold)
        {
            lastPos = rb.transform.position; // update lastpos
            yIsPositive = false;
        }
    }
}
