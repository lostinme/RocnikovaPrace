// Jakub Fussek, 3.C PVA, Sticker Mania

using TMPro;
using UnityEngine;

public class buttonShelfScirpt : MonoBehaviour
{
    public TextMeshProUGUI count;

    public float thisCount;

    bool paper;

    public TextMeshProUGUI nadpisText;
    public float nadpisCount;
    float currentCount;
    public string nadpis;

    // Start is called before the first frame update
    void Start()
    {
        if (count.gameObject.tag == "paper")
        {
            paper = true;

            Debug.Log("paper");
        }

        currentCount = nadpisCount;

        if(paper)
        {
            nadpisText.text = $"{nadpisCount} / {nadpis}";
        } else
        {
            nadpisText.text = $"{nadpisCount * 10} ml / {nadpis}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCount != nadpisCount)
        {
            if (paper)
            {
                nadpisText.text = $"{nadpisCount} / {nadpis}";
            }
            else
            {
                nadpisText.text = $"{nadpisCount * 10} ml / {nadpis}";
            }

            currentCount = nadpisCount;
        }
    }

    public void plus()
    {
        thisCount++;

        if( paper )
        {
            count.text = $"{thisCount}";
        } else
        {
            count.text = $"{thisCount * 10} ml";
        }
    }

    public void minus()
    {
        if (thisCount <= 0)
        {
            thisCount = 0;
        } else
        {
            thisCount--;
        }

        if (paper)
        {
            count.text = $"{thisCount}";
        }
        else
        {
            count.text = $"{thisCount * 10} ml";
        }
    }
}