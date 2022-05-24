using UnityEngine;

// right player
public class PlayerMovement : MonoBehaviour
{
    public BezierSpline spline;
	public float duration;
	public bool lookForward;

	public SplineWalkerMode mode;
	public float progress;

    public GameObject p1Paddle;
    public float xAngle, yAngle, zAngle;
    public float playerRotationSpeed;

    public bool rightPlayerAbove0 = false;



    public void Start() {
        progress = 0.75f;
        playerRotationSpeed = 80.0f;
        duration = SensSettings.sensitivityLevel;
    }

    public void Move() {
        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            progress -= Time.deltaTime / duration;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            progress += Time.deltaTime / duration;
        }

        // if right player hits 1, paddle begins to rotate
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            lookForward = false;
            transform.Rotate(playerRotationSpeed * Time.deltaTime, 0f, 0f);
        }
        // if right player hits 3, paddle begins to rotate opposite direction
        if (Input.GetKey(KeyCode.RightArrow))
        {
            lookForward = false;
            transform.Rotate(-playerRotationSpeed * Time.deltaTime, 0f, 0f);
        }
        // if right player isnt rotating, face forward
        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            lookForward = true;
        }
    }

    public void Teleport() {
        // if player 2 goes past upper half of border, player appears at bottom half
        if (progress > 1f)
        {
            progress = 0.5f;
        }
        else if (progress < 0.5f)
        {
            progress = 1f;
        }
    }
    
    public void KeepRotationInPlace()
    {
        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;

        if (p1Paddle.transform.position.y > 0)
        {
            rightPlayerAbove0 = true;
        }
        else
        {
            rightPlayerAbove0 = false;
        }

        if (lookForward && rightPlayerAbove0)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
        else if (lookForward && !rightPlayerAbove0)
        {
            transform.LookAt(position - spline.GetDirection(progress));
        }
    }

    private void Update () {

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