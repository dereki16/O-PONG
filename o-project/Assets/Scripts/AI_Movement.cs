using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    public BezierSpline spline;
    public BallMovement bm;
    public float duration;
    public bool lookForward;

    public SplineWalkerMode mode;
    public float progress;
    public float aiRotationSpeed;
    public GameObject aiPaddle;
    
    public bool aiAbove0 = false;
    public bool aiGoUp = false;
    public bool aiGoDown = false;


    public void Start()
    {
        progress = 0.25f;
        aiRotationSpeed = 80.0f;
    }

    public void Move()
    {
        float aiPaddlesY; 
        aiPaddlesY = aiPaddle.transform.position.y;
        if (bm.ballsY == aiPaddlesY)
        {
            aiGoUp = false;
            aiGoDown = false;
        }
        if (bm.ballsY > aiPaddlesY)
        {
            aiGoDown = false;
            aiGoUp = true;
        }
        else if (bm.ballsY < aiPaddlesY)
        {
            aiGoUp = false;
            aiGoDown = true;
        }

        // makes lp go up
        if (aiGoUp)
        {
            progress -= Time.deltaTime / duration;
        }
        // makes lp go down
        else if (aiGoDown)
        {
            progress += Time.deltaTime / duration;
        }
        // Rotation controls
        // if player hits q, paddle begins to rotate
        if (Input.GetKey(KeyCode.Q))
        {
            lookForward = false;
            transform.Rotate(aiRotationSpeed * Time.deltaTime, 0f, 0f);
        }
        // if player hits r, paddle begins to rotate opposite direction
        if (Input.GetKey(KeyCode.R))
        {
            lookForward = false;
            transform.Rotate(-aiRotationSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.R))
        {
            lookForward = true;
        }
    }

    public void Teleport()
    {
        // if player 2 goes past upper half of border, player appears at bottom half
        if (progress > 0.5f)
        {
            progress = 0.0f;
        }
        else if (progress < 0.0f)
        {
            progress = 0.5f;
        }
    }

    public void KeepRotationInPlace()
    {
        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;

        if (aiPaddle.transform.position.y > 0)
        {
            aiAbove0 = true;
        }
        else
        {
            aiAbove0 = false;
        }

        if (lookForward && aiAbove0)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
        else if (lookForward && !aiAbove0)
        {
            transform.LookAt(position - spline.GetDirection(progress));
        }
    }

    private void Update()
    {
        KeepRotationInPlace();
        Move();
        Teleport();

        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }
}