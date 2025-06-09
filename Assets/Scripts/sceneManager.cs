// Jakub Fussek, 3.C PVA, Sticker Mania

using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Factory()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("factory", LoadSceneMode.Single);
        playerMovement.canMove = true;
    }

    public void Shop()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("shop", LoadSceneMode.Single);
        playerMovement.canMove = true;
    }

    public void House()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("house", LoadSceneMode.Single);
        playerMovement.canMove = true;
    }

    public void Back()
    {
        playerMovement.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }
}
