// Jakub Fussek, 3.C PVA, Sticker Mania

using System.Collections.Generic;
using UnityEngine;

public class EmailContent : MonoBehaviour
{
    public static List<string> names = new List<string>(); //name, count, time to finish, color, last: plate
    public static Texture currentTexture = null;

    public static int CurrentID = -1;

    public GameObject emailPanel;

    public List<string> color = new List<string>();
    public List<string> plates = new List<string>();

    public GameObject acceptButton;

    public static bool isQuestActive = false;
    public static float rewardQuest;

    void Start()
    {
        acceptButton.SetActive(false);
    }

    private void Update()
    {
        if(CurrentID != -1 && !isQuestActive)
        {
            acceptButton.SetActive(true);
        }
    }

    public void AcceptButt()
    {
        emailPrefabScript script = emailPanel.transform.GetChild(CurrentID).GetComponent<emailPrefabScript>();

        currentTexture = script.img;

        names.Add(script.nameExport);
        names.Add(script.count.ToString());
        names.Add(script.timeToFinish);

        for (int i = 0; i < Random.Range(1,3); i++)
        {
            names.Add(color[Random.Range(0, color.Count)]);
        }

        names.Add(plates[Random.Range(0, plates.Count)]);

        int.TryParse(names[1], out boxScript.globalCount);

        isQuestActive = true;
        acceptButton.SetActive(!isQuestActive);
    }
}
