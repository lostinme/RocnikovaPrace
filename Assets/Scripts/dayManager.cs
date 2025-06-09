// Jakub Fussek, 3.C PVA, Sticker Mania

using UnityEngine;
using UnityEngine.SceneManagement;

public class dayManager : MonoBehaviour
{
    public static int days;

    int currentDay = 0;

    public static int randEmails;

    // Start is called before the first frame update
    void Start()
    {
        currentDay = days;

        if(days == 0)
        {
            days++;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDay < days)
        {
            randEmails = Random.Range(1, 5);

            currentDay = days;

            if (currentDay == 6)
            {
                SceneManager.LoadScene("lastEndingScene", LoadSceneMode.Single);
            }
        }
    }
}
