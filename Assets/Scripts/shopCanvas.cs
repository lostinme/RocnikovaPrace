// Jakub Fussek, 3.C PVA, Sticker Mania

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shopCanvas : MonoBehaviour
{
    public List<GameObject> counts = new List<GameObject>();

    public static int Id = -1;

    public TextMeshProUGUI nadpis;

    public GameObject colorGm;
    public GameObject paperGm;
    public GameObject glueGm;

    public float moneyToSpend;
    public TextMeshProUGUI money;

    // Start is called before the first frame update
    void Start()
    {
        colorGm.SetActive(false);
        paperGm.SetActive(false);
        glueGm.SetActive(false);

        money.text = $"{moneyToSpend} / {playerEconomy.playerMoney} Kè";
        starting();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        starting();
    }

    void starting()
    {
        if (Id == 0)
        {
            colorGm.SetActive(true);
            paperGm.SetActive(false);
            glueGm.SetActive(false);

        } else if(Id == 1)
        {
            colorGm.SetActive(false);
            paperGm.SetActive(true);
            glueGm.SetActive(false);
        }
        else if (Id == 2)
        {
            colorGm.SetActive(false);
            paperGm.SetActive(false);
            glueGm.SetActive(true);
        }
    }

    public void colorP()
    {
        moneyToSpend++;

        money.text = $"{moneyToSpend} / {playerEconomy.playerMoney} Kè";
    }

    public void colorM()
    {
        moneyToSpend--;

        money.text = $"{moneyToSpend} / {playerEconomy.playerMoney} Kè";

        if (moneyToSpend <= 0)
        {
            moneyToSpend = 0;
        }
    }

    public void paperP()
    {
        moneyToSpend += 10;

        money.text = $"{moneyToSpend} / {playerEconomy.playerMoney} Kè";
    }

    public void paperM()
    {
        moneyToSpend -= 10;

        money.text = $"{moneyToSpend} / {playerEconomy.playerMoney} Kè";

        if (moneyToSpend <= 0)
        {
            moneyToSpend = 0;
        }
    }

    public void glueP()
    {
        moneyToSpend += 5;

        money.text = $"{moneyToSpend} / {playerEconomy.playerMoney} Kè";
    }

    public void glueM()
    {
        moneyToSpend -= 5;

        money.text = $"{moneyToSpend} / {playerEconomy.playerMoney} Kè";

        if (moneyToSpend <= 0)
        {
            moneyToSpend = 0;
        }
    }

    public void buy()
    {
        playerEconomy.playerMoney -= moneyToSpend;

        moneyToSpend = 0;

        money.text = $"{moneyToSpend} / {playerEconomy.playerMoney} Kè";

        for (int i = 0; i < counts.Count; i++)
        {
            if (counts[i].name.Contains("colorPanel"))
            {
                playerQue.colorQueI.Add(counts[i].GetComponent<buttonShelfScirpt>().thisCount);
                playerQue.colorQueS.Add(counts[i].GetComponent<buttonShelfScirpt>().nadpis);

                int index = playerQue.colorQueS.IndexOf(playerQue.colorQueS[i]);

                if (index >= 10)
                {
                    playerQue.colorQueI[index] += playerQue.colorQueI[i];

                    playerQue.colorQueI[i] = 0;
                }
            }
            else if (counts[i].name == "50x50" || counts[i].name == "20x20")
            {
                if (counts[i].name == "50x50")
                {
                    if (playerQue.hasGenerated)
                    {
                        float.TryParse(playerQue.paperQue[0].Substring(1), out float numb);

                        numb += counts[i].GetComponent<buttonShelfScirpt>().thisCount;

                        playerQue.paperQue[0] = $"5{numb}";

                    } else if (!playerQue.hasGenerated)
                    {
                        playerQue.paperQue.Add($"5{counts[i].GetComponent<buttonShelfScirpt>().thisCount}");
                    }

                } else if (counts[i].name == "20x20")
                {
                    if (playerQue.hasGenerated)
                    {
                        float.TryParse(playerQue.paperQue[1].Substring(1), out float numb);

                        numb += counts[i].GetComponent<buttonShelfScirpt>().thisCount;

                        playerQue.paperQue[1] = $"2{numb}";

                    }
                    else if (!playerQue.hasGenerated)
                    {
                        playerQue.paperQue.Add($"2{counts[i].GetComponent<buttonShelfScirpt>().thisCount}");
                    }
                }
            }
            else
            {
                playerQue.glueQue += counts[i].GetComponent<buttonShelfScirpt>().thisCount;
            }

            Debug.Log(counts[i].name);

            counts[i].GetComponent<buttonShelfScirpt>().thisCount = 0;

            TextMeshProUGUI text = counts[i].transform.GetChild(counts[i].transform.childCount - 1).GetComponent<TextMeshProUGUI>();

            if (counts[i].tag == "paper")
            {
                text.text = counts[i].GetComponent<buttonShelfScirpt>().thisCount.ToString();
            }
            else
            {
                text.text = $"{counts[i].GetComponent<buttonShelfScirpt>().thisCount} ml";
            }
        }
    }

    public void close()
    {
        colorGm.SetActive(false);
        paperGm.SetActive(false);
        glueGm.SetActive(false);

        gameObject.SetActive(false);

        playerMovement.canMove = true;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
