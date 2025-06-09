// Jakub Fussek, 3.C PVA, Sticker Mania

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class bottomPanel : MonoBehaviour
{
    int countOfChildren;

    public RawImage sticker;
    public Transform panel;
    public TextMeshProUGUI count;

    public static int ID;
    int printCount;

    public static string paperType;

    public GameObject butt50;
    public GameObject butt20;

    public GameObject startPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EmailContent.currentTexture != null)
        {
            sticker.texture = EmailContent.currentTexture;

            if (panel.childCount == 0)
            {
                Instantiate(sticker, panel);
            }

        }
    }

    public void b50()
    {
        ID = 0;

        paperType = "50x50";
    }

    public void b20()
    {
        ID = 1;

        paperType = "20x20";
    }

    public void print()
    {
        float time = Time.time;

        if(machineManager.isDone)
        {
            for(int i = 0; i < printCount; i++)
            {
                Invoke("countdown", 1);
            }
        }
    }

    void countdown()
    {
        if (ID == 0)
        {
            Instantiate(butt50, startPosition.transform.position, startPosition.transform.rotation);
        }
        else if (ID == 1)
        {
            Instantiate(butt20, startPosition.transform.position, startPosition.transform.rotation);
        }

    }
    public void plus()
    {
        printCount++;

        count.text = printCount.ToString();
    }

    public void minus()
    {
        printCount--;

        if(printCount < 0)
        {
            printCount = 0;
        }

        count.text = printCount.ToString();
    }
}
