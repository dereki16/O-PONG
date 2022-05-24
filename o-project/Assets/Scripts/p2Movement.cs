using UnityEngine;

// left player
public class p2Movement : MonoBehaviour
{
    public BezierSpline spline;
    public float duration;
    public bool lookForward;

    public SplineWalkerMode mode;
    public float progress;

    public float playerRotationSpeed;

    public GameObject p2Paddle;

    public bool lefttPlayerAbove0 = false;

    public void Start()
    {
        progress = 0.25f;
        playerRotationSpeed = 80.0f;
        duration = SensSettings.sensitivityLevel;
    }

    public void Move()
    {
        // makes lp go up
        if (Input.GetKey(KeyCode.W))
        {
            progress += Time.deltaTime / duration;
        }
        // makes lp go down
        else if (Input.GetKey(KeyCode.S))
        {
            progress -= Time.deltaTime / duration;
        }
        // Rotation controls
        // if player hits q, paddle begins to rotate
        if (Input.GetKey(KeyCode.A))
        {
            lookForward = false;
            transform.Rotate(playerRotationSpeed * Time.deltaTime, 0f, 0f);
        }
        // if player hits r, paddle begins to rotate opposite direction
        if (Input.GetKey(KeyCode.D))
        {
            lookForward = false;
            transform.Rotate(-playerRotationSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
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

        if (p2Paddle.transform.position.y > 0)
        {
            lefttPlayerAbove0 = true;
        }
        else
        {
            lefttPlayerAbove0 = false;
        }

        if (lookForward && lefttPlayerAbove0)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
        else if (lookForward && !lefttPlayerAbove0)
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