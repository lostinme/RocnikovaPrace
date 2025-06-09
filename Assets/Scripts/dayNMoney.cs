// Jakub Fussek, 3.C PVA, Sticker Mania

using TMPro;
using UnityEngine;

public class dayNMoney : MonoBehaviour
{
    public static float currentMoney;

    public static int days;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dayText;

    void Start()
    {
        currentMoney = playerEconomy.playerMoney;

        moneyText.text = $"Pen�ze: {playerEconomy.playerMoney} K�";

        days = dayManager.days;

        dayText.text = $"Den: {dayManager.days}";
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMoney < playerEconomy.playerMoney || currentMoney > playerEconomy.playerMoney)
        {
            moneyText.text = $"Pen�ze: {playerEconomy.playerMoney} K�";
            currentMoney = playerEconomy.playerMoney;
        }

        if(days < dayManager.days)
        {
            dayText.text = $"Den: {dayManager.days}";

            days = dayManager.days;
        }
    }
}
