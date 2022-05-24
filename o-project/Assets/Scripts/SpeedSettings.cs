using UnityEngine;
using TMPro;

public class SpeedSettings : MonoBehaviour
{
    public TextMeshProUGUI speed;

    public static int speedLevelDisplay = 3;
    private static float zero = 5f;
    private static float one = 5.5f;
    private static float two = 6f;
    private static float three = 6.5f;
    private static float four = 7f;
    public static float five = 7.5f;
    private static float six = 8f;
    private static float seven = 9f;
    private static float eight = 10f;
    private static float nine = 11f;

    public static float ballSpeed = three;

    void Start()
    {
        SpeedDisplay();   
    }

    public void NumAss()
    {
        switch (speedLevelDisplay)
        {
            case 9:
                ballSpeed = nine;
                break;
            case 8:
                ballSpeed = eight;
                break;
            case 7:
                ballSpeed = seven;
                break;
            case 6:
                ballSpeed = six;
                break;
            case 5:
                ballSpeed = five;
                break;
            case 4:
                ballSpeed = four;
                break;
            case 3:
                ballSpeed = three;
                break;
            case 2:
                ballSpeed = two;
                break;
            case 1:
                ballSpeed = one;
                break;
            case 0:
                ballSpeed = zero;
                break;
            default:
                break;
        }
    }

    // Ball Speed
    public void LeftSpeed()
    {
        if (speedLevelDisplay > 0)
        {
            speedLevelDisplay -= 1;
            speed.text = speedLevelDisplay.ToString();
            NumAss();
        }
    }
    public void RightSpeed()
    {
        if (speedLevelDisplay < 9)
        {
            speedLevelDisplay += 1;
            speed.text = speedLevelDisplay.ToString();
            NumAss();
        }
    }

    public void SpeedDisplay()
    {
        speed.text = speedLevelDisplay.ToString();
    }
}
