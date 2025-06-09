// Jakub Fussek, 3.C PVA, Sticker Mania

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class machineManager : MonoBehaviour
{
    public TextMeshProUGUI colorText;
    public TextMeshProUGUI paperText;
    public TextMeshProUGUI glueText;

    public static bool isDone = false;

    public static List<float> colorStats = new List<float>();
    public static List<string> colorNames = new List<string>();
    public static List<float> realColorState = new List<float>();

    public static float glueStat = 0;
    public static float realGlue = 0;

    public static float paperStat = 0;

    string colorBuildText;

    public static bool buildingPovolenka;
    int indexCheck;

    public static bool isGenerated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (EmailContent.isQuestActive && !isGenerated)
        {
            for (int i = 3; i < EmailContent.names.Count - 1; i++)
            {
                colorStats.Add((float)Math.Round(UnityEngine.Random.Range(0.1f, 3), 1));

                colorNames.Add(EmailContent.names[i]);

                realColorState.Add(0);

                Debug.Log(colorNames[i -3] + " " + colorStats[i -3]);
            }

            isGenerated = true;
        }

        if(glueStat <= 0)
        {
            glueStat = (float)Math.Round(UnityEngine.Random.Range(0.1f, 2), 1);
        }

        buildingPovolenka = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (buildingPovolenka)
        {
            colorText.text = "";
            paperText.text = "";
            check();
            buildText();
        }
    }

    public void buildText()
    {
        for(int i = 0; i < colorNames.Count; i++)
        {
            colorText.text = $"{colorText.text} {colorNames[i]}: {realColorState[i] * 10} / {colorStats[i] * 100} ml;";
        }

        paperText.text = $"{paperText.text} {EmailContent.names[EmailContent.names.Count-1]}: {paperStat} / {boxScript.globalCount};";

        glueText.text = $"Glue: {realGlue * 10} / {(glueStat * 100) + 10} ml;";

        buildingPovolenka = false;
    }

    void check()
    {
        for (int i = 0; i <3; i++)
        {
            if (indexCheck < colorNames.Count)
            {
                for (int j = 0; j < colorNames.Count; j++)
                {
                    if (realColorState[j] >= colorStats[j] * 10)
                    {
                        Debug.Log("TEST");

                        indexCheck++;
                    }

                    Debug.Log($"{realColorState[j]} {colorStats[j] * 10}");
                }
            }
            Debug.Log(indexCheck);

            if (indexCheck == colorNames.Count)
            {
                indexCheck = 3;
            }

            Debug.Log(indexCheck);

            if (paperStat == boxScript.globalCount && indexCheck == 3)
            {
                indexCheck = 4;
            }

            if (realGlue >= glueStat * 10 && indexCheck == 4)
            {
                Debug.Log("XD");

                isDone = true;
            }
        }
    }
}
