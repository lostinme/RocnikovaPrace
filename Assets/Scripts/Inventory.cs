// Jakub Fussek, 3.C PVA, Sticker Mania

using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject emailWindow;

    public GameObject emailPrefab;
    public Transform panelEmailTransform;

    bool patentBool = false;
    bool emailBool = false;

    int idToCreate = 0;

    public List<string> names = new List<string>();
    public List<string> lastNames = new List<string>();
    public List<string> describes = new List<string>();
    public List<Texture> pozadavky = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            emailWindow.SetActive(false);
        }
        catch
        {
            Debug.Log("pass");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dayManager.randEmails > 0)
        {
            instantiateEmail();
        }
    }

    public void Leave()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        playerMovement.canMove = true;
    }

    public void patent()
    {
        patentBool = !patentBool;
    }

    public void email()
    {
        emailBool = !emailBool;

        emailWindow.SetActive(emailBool);
    }

    public void instantiateEmail()
    {
        for (int i = dayManager.randEmails; i > 0; i--)
        {
            GameObject emailToSpawn = Instantiate(emailPrefab, panelEmailTransform);

            emailPrefabScript script = emailToSpawn.GetComponent<emailPrefabScript>();

            script.scriptReceiver(names[Random.Range(0, names.Count)] + " " + lastNames[Random.Range(0, lastNames.Count)], describes[Random.Range(0, describes.Count)], idToCreate, pozadavky[Random.Range(0, pozadavky.Count)]);

            idToCreate++;
        }

        dayManager.randEmails = 0;
    }
}
