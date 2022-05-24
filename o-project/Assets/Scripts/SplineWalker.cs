using UnityEngine;

public class SplineWalker : MonoBehaviour {

	public BezierSpline spline;
	public float duration;
	public bool lookForward;
	public SplineWalkerMode mode;
	private float progress;

    public void start()
    {
        progress = 0.25f;
    }

    private void Update () {

		if (Input.GetKey("up")) {
			progress += Time.deltaTime / duration;
           
        }
		else if (Input.GetKey("down")) {
            progress -= Time.deltaTime / duration;
        }

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
	}
}