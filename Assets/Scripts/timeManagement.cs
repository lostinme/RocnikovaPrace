// Jakub Fussek, 3.C PVA, Sticker Mania

using TMPro;
using UnityEngine;

public class timeManagement : MonoBehaviour
{
    public static float hours = 6;
    public static float minutes;

    float countTime;

    public static string realTime;

    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        countTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= countTime + 1)
        {
            countTime++;
            minutes++;

            if (minutes == 60)
            {
                minutes = 0;
                hours++;
            }

            if (minutes < 10)
            {
                realTime = $"{hours}:0{minutes}";
            } else
            {
                realTime = $"{hours}:{minutes}";
            }

            timeText.text = "Èas: " + realTime;
        }
    }

    
}
