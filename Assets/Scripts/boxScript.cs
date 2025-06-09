// Jakub Fussek, 3.C PVA, Sticker Mania

using TMPro;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    public TextMeshProUGUI countText;

    public static int createdCount;
    public static int globalCount;
    public static int localCountCreated;

    float timeToDestroy = 0;
    float timeHolder = 0;

    bool isHolding = false;

    public GameObject machine;
    machineManager script;

    // Start is called before the first frame update
    void Start()
    {
        machine = GameObject.Find("Machn_2");

        localCountCreated = createdCount;

        countText.text = $"{createdCount}/{globalCount}";

        script = machine.GetComponent<machineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (localCountCreated < createdCount)
        {
            localCountCreated++;

            updateCount();
        }

        if (globalCount == createdCount)
        {
            countText.color = Color.green;
        }

        append();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Image")
        {
            Destroy(other.gameObject);

            script.buildText();

            if(bottomPanel.paperType == EmailContent.names[EmailContent.names.Count - 1])
            {
                createdCount++;
            }
        }
    }

    public void updateCount()
    {
        countText.text = $"{createdCount}/{globalCount}";
    }

    void append()
    {
        try
        {
            if (transform.parent.name == "boxLend" && createdCount == globalCount)
            {
                Debug.Log(timeHolder);

                if (isHolding)
                {
                    isHolding = !isHolding;
                    timeToDestroy = Time.time;
                }


                if (timeToDestroy <= Time.time + 1)
                {
                    timeHolder++;
                    timeToDestroy = Time.time;
                }

                if (timeHolder == 3)
                {
                    Destroy(gameObject);

                    EmailContent.isQuestActive = false;

                    playerEconomy.playerMoney += EmailContent.rewardQuest;

                    EmailContent.rewardQuest = 0;
                    createdCount = 0;
                    globalCount = 0;
                    localCountCreated = 0;

                    EmailContent.names.Clear();
                }
            }
        } catch
        {

        }
    }
}
