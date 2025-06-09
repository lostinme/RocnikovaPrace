// Jakub Fussek, 3.C PVA, Sticker Mania

using System.Collections.Generic;
using UnityEngine;

public class playerQue : MonoBehaviour
{
    public static List<string> colorQueS = new List<string>();
    public static List<float> colorQueI = new List<float>();

    public static List<string> paperQue = new List<string>();

    public static float glueQue;

    public List<GameObject> gameObjects = new List<GameObject>();

    public static bool hasGenerated = false;

    // Start is called before the first frame update
    void Start()
    {
        buttonShelfScirpt scirpt;

        if (gameObject.tag == "Player")
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                scirpt = gameObjects[i].GetComponent<buttonShelfScirpt>();

                if (gameObjects[i].name.Contains("colorPanel"))
                {
                    for (int j = 0; j < colorQueS.Count; j++)
                    {
                        if (colorQueS[j] == scirpt.nadpis)
                        {
                            scirpt.nadpisCount = scirpt.nadpisCount + colorQueI[j];
                        }
                    }
                } else if (gameObjects[i].name == "50x50")
                {
                    string vyber;

                    for (int  j = 0; j < paperQue.Count; j++)
                    {
                        if (paperQue[j][0].ToString() == "5")
                        {
                            float.TryParse(paperQue[j].Substring(1), out float number);

                            scirpt.nadpisCount += number;
                        }
                    }
                } else if (gameObjects[i].name == "20x20")
                {
                    string vyber;

                    for (int j = 0; j < paperQue.Count; j++)
                    {
                        if (paperQue[j][0].ToString() == "2")
                        {
                            float.TryParse(paperQue[j].Substring(1), out float number);

                            scirpt.nadpisCount += number;
                        }
                    }
                } else if (gameObjects[i].name == "glue")
                {
                    scirpt.nadpisCount += glueQue;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < paperQue.Count; i++)
        {
            Debug.Log(paperQue[i] + " " + paperQue.Count);

            if (paperQue.Count > 0)
            {
                hasGenerated = true;
            }
        }
    }
}
