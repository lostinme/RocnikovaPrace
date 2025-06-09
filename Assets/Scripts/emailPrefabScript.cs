// Jakub Fussek, 3.C PVA, Sticker Mania

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class emailPrefabScript : MonoBehaviour
{
    Transform thisGameObject;
    TextMeshProUGUI buttonText;

    Transform emailContent;
    TextMeshProUGUI nameOfCustomer;
    TextMeshProUGUI emailText;

    string descriptionExport;
    public string nameExport;

    int thisID;

    public string timeToFinish;
    public int count;

    public float reward;

    public Texture img;

    public RawImage profilePicture;

    // Start is called before the first frame update
    void Start()
    {
        emailContent = GameObject.Find("emailContent").transform;

        nameOfCustomer = emailContent.GetChild(0).GetComponent<TextMeshProUGUI>();
        emailText = emailContent.GetChild(1).GetComponent<TextMeshProUGUI>();

        timeToFinish = $"{Random.Range(1,24)}:{Random.Range(0,59)}";

        count = Random.Range(1, 20);

        reward = Random.Range(250, 550);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scriptReceiver(string names, string descript, int childID, Texture rawImage)
    {
        Debug.Log(names + "|" + descript);

        nameExport = names;
        descriptionExport = descript;

        thisID = childID;

        img = rawImage;
    }

    public void onClicked()
    {
        nameOfCustomer.text = nameExport;
        emailText.text = cutString();

        EmailContent.rewardQuest = reward;

        EmailContent.CurrentID = thisID;
    }

    string cutString()
    {
        string[] cut = descriptionExport.Split(' ');

        descriptionExport = "";
        for (int i = 0; i < cut.Length; i++)
        {
            if (cut[i] == "COUNT")
            {
                cut[i] = count.ToString();
            } else if (cut[i] == "REWARD.")
            {
                cut[i] = reward.ToString() + " Kè.";
            } else if (cut[i] == "REWARD")
            {
                cut[i] = reward.ToString() + " Kè";
            }

            Debug.Log(reward);

            descriptionExport += cut[i] + " ";
        }

        return descriptionExport;
    }
}
