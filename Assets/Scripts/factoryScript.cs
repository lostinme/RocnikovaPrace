// Jakub Fussek, 3.C PVA, Sticker Mania

using UnityEngine;

public class factoryScript : MonoBehaviour
{
    public Transform krabiceSpawnPoint;
    public GameObject krabice;

    public AudioSource staveniste;
    // Start is called before the first frame update
    void Start()
    {
        if (krabiceSpawnPoint.childCount <= 0)
        {
            Instantiate(krabice, krabiceSpawnPoint.position, transform.rotation);   
        }

        staveniste.volume = staveniste.volume * mainMenu.audioValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
