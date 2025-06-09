// Jakub Fussek, 3.C PVA, Sticker Mania

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject hlavniMenu;

    public Slider slider;

    public static float audioValue;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        settingsMenu.SetActive(false);
        hlavniMenu.SetActive(true);

        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        audioValue = slider.value;

        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("house", LoadSceneMode.Single);
        playerMovement.canMove = true;
    }

    public void settingsButt()
    {
        settingsMenu.SetActive(true);
        hlavniMenu.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void back()
    {
        settingsMenu.SetActive(false);
        hlavniMenu?.SetActive(true);
    }
}
