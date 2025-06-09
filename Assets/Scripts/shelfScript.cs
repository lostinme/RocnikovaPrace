// Jakub Fussek, 3.C PVA, Sticker Mania

using System.Collections.Generic;
using UnityEngine;

public class shelfScript : MonoBehaviour
{
    public Transform panel;

    public static List<string> saveColorName = new List<string>();
    public static List<float> saveColorValues = new List<float>();

    public static float[] savePaperValues = new float[2]; //50 20

    public static float saveGlueValue;

    public static bool setup;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void close()
    {
        gameObject.SetActive(false);

        playerMovement.canMove = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void send()
    {
        buttonShelfScirpt script;

        int count = machineManager.colorNames.Count;

        for (int i = 0; i < panel.GetChild(0).GetChild(1).childCount; i++)
        {
            script = panel.GetChild(0).GetChild(1).GetChild(i).GetComponent<buttonShelfScirpt>();

            if(script.nadpisCount >= script.thisCount && script.thisCount != 0)
            {
                int index = machineManager.colorNames.IndexOf(script.nadpis.ToLower());

                if (index != -1)
                {
                    machineManager.realColorState[index] += script.thisCount;

                    script.nadpisCount = script.nadpisCount - script.thisCount;
                }
            }
        }

        string plateType = EmailContent.names[EmailContent.names.Count - 1];

        script = GameObject.Find(plateType).GetComponent<buttonShelfScirpt>();

        if (script.nadpisCount >= script.thisCount && script.thisCount != 0)
        {
            machineManager.paperStat += script.thisCount;

            script.nadpisCount = script.nadpisCount - script.thisCount;
        }

        script = panel.GetChild(2).GetComponent<buttonShelfScirpt>();

        if (script.nadpisCount >= script.thisCount && script.thisCount != 0)
        {
            machineManager.realGlue += script.thisCount;

            script.nadpisCount = script.nadpisCount - script.thisCount;
        }

        machineManager.buildingPovolenka = true;
    }
}
