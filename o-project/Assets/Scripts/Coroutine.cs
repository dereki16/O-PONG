using System.Collections;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] private int timer;

    public bool ballHitWall = false;

    private void Start()
    {
        StartCoroutine(HiddenObject());
    }
    IEnumerator HiddenObject()
    {

        ballHitWall = false;

        // code making ball appear
        yield return new WaitForSeconds(timer);
        Box.SetActive(true);       
    }

    public void BallHitBorder()
    {
        if (ballHitWall)
        {
            StartCoroutine(HiddenObject());
            Box.SetActive(false);
        }
    }

    public void Update()
    {
        BallHitBorder();
    }


}
