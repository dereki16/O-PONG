using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownTexts;

    float currentTime = 0f;
    float startingTIme = 3f;

    public bool RoundBegin = false;

    void Start()
    {
        currentTime = startingTIme;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownTexts.text = Mathf.RoundToInt(currentTime).ToString();

        // if time left is less than or equal to 1, disable text
        if (currentTime <= 1)
        {
            countdownTexts.enabled = false;
        }
    }
}
