// Jakub Fussek, 3.C PVA, Sticker Mania

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TextMeshProUGUI text;
    public RawImage img;

    public static bool tutorialDone;

    public static int currentSlide = 0;
    public static int lastSlide = 0;
    public static int currentScene = 0;

    public string[] texts = new string[0];
    public Texture[] images = new Texture[0];

    public int[] indexes = new int[0];

    bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        currentSlide = lastSlide;

        tutorialPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && indexes[currentScene] >= currentSlide && !playerMovement.canMove)
        {

            currentSlide++;

        } 
        
        if (Input.GetKeyDown(KeyCode.F) && indexes[currentScene] == currentSlide)
        {
            isDone = true;

            tutorialPanel.SetActive(false);

            lastSlide = indexes[currentScene];

            currentScene++;

            if(currentScene == 3)
            {
                tutorialDone = true;
            } 

            if (tutorialDone)
            {
                Destroy(gameObject);
            }
        }

        if (!isDone && !tutorialDone)
        {
            playerMovement.canMove = false;

            tutorialPanel.SetActive(!isDone);

            text.text = texts[currentSlide];
            img.texture = images[currentSlide];

        }
        else
        {
            playerMovement.canMove = true;
        }
    }
}
