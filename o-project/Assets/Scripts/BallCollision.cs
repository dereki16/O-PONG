using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public bool ballHitWall;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
            ballHitWall = true;
    }
}