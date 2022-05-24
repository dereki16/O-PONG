using UnityEngine;
using TMPro;

public class SensSettings : MonoBehaviour
{
    public TextMeshProUGUI sensitivity;

    public static int sensitvityLevelDisplay = 5;
    private static float zero = -6.5f;
    private static float one = -6.25f;
    private static float two = -6f;
    private static float three = -5.5f;
    private static float four = -5f;
    public static float five = -4.5f;
    private static float six = -4f;
    private static float seven = -3.5f;
    private static float eight = -3f;
    private static float nine = -2.5f;

    public static float sensitivityLevel = five;
    void Start()
    {
        SensDisplay();
    }
    // Player sensitivity controls
    public void NumAss()
    {
        switch (sensitvityLevelDisplay)
        {
            case 9:
                sensitivityLevel = nine;
                break;
            case 8:
                sensitivityLevel = eight;
                break;
            case 7:
                sensitivityLevel = seven;
                break;
            case 6:
                sensitivityLevel = six;
                break;
            case 5:
                sensitivityLevel = five;
                break;
            case 4:
                sensitivityLevel = four;
                break;
            case 3:
                sensitivityLevel = three;
                break;
            case 2:
                sensitivityLevel = two;
                break;
            case 1:
                sensitivityLevel = one;
                break;
            case 0:
                sensitivityLevel = zero;
                break;
            default:
                sensitivityLevel = five;
                break;
        }
    }

    public void LeftSens()
    {
        if (sensitvityLevelDisplay > 0)
        {
            sensitvityLevelDisplay -= 1;
            sensitivity.text = sensitvityLevelDisplay.ToString();

            NumAss();
        }
    }
    public void RightSens()
    {
        if (sensitvityLevelDisplay < 9)
        {
            sensitvityLevelDisplay += 1;
            sensitivity.text = sensitvityLevelDisplay.ToString();

            NumAss();
        }
    }

    public void SensDisplay()
    {
        sensitivity.text = sensitvityLevelDisplay.ToString();
    }
}
