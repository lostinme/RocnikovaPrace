// Jakub Fussek, 3.C PVA, Sticker Mania

using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    float characterSpeed = 5f;

    float mouseX;
    float mouseY;

    public static bool canMove = true;

    public GameObject camera;

    Rigidbody rb;

    public AudioSource audioSource;
    public AudioClip clip;

    public GameObject pauseMenu;

    public Slider audio;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

        audioSource.clip = clip;

        audioSource.volume = audioSource.volume * mainMenu.audioValue;

        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            basicMovement();
            mouseY = Input.GetAxis("Mouse Y") * 500;
            mouseX = Input.GetAxis("Mouse X") * 500;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            isPaused = pauseMenu.activeSelf;

            audio.value = mainMenu.audioValue;

            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.Confined;
                canMove = false;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                canMove = true;
            }
        }
    }

    void basicMovement()
    {
        transform.Translate(Vector3.forward * characterSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Translate(Vector3.right * characterSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        if (Input.GetAxis("Vertical") > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * characterSpeed * 1.5f * Input.GetAxis("Vertical") * Time.deltaTime);
        } else
        {
            characterSpeed = 5f;
        }

        if (canMove)
        {
            camera.transform.Rotate(-mouseY * Time.deltaTime, 0, 0);
            transform.Rotate(0, mouseX * Time.deltaTime, 0);
        }

        if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void back()
    {
        mainMenu.audioValue = audio.value;

        audioSource.volume = audioSource.volume * mainMenu.audioValue;

        pauseMenu.SetActive(false);

        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;

        canMove = true;
    }
}
