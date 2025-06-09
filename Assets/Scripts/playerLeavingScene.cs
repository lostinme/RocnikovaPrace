// Jakub Fussek, 3.C PVA, Sticker Mania

using UnityEngine;

public class playerLeavingScene : MonoBehaviour
{
    Ray ray;

    bool activeToSpawn;

    public GameObject camera;
    public GameObject doorsActionButt;
    public GameObject pcActionButt;
    public GameObject bedActionButt;
    public GameObject shelfActionButt;

    public GameObject sceneManager;
    public GameObject inventoryCanvas;

    public GameObject shelfCanvas;

    public GameObject pointSpawn;

    GameObject nalepka;

    RaycastHit hit;

    public LayerMask doorLayer;
    public LayerMask pcMask;
    public LayerMask bedMask;
    public LayerMask boxMask;
    public LayerMask boxPosition;
    public LayerMask shelfMask;

    public float raycastLenght;

    bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(camera.transform.position, camera.transform.forward);

        doorsActionButt.SetActive(false);
        sceneManager.SetActive(false);
        inventoryCanvas.SetActive(false);

        hit.distance = 200;

        if (pcMask != 0)
        {
            pcActionButt.SetActive(false);
        }

        if (shelfMask != 0)
        {
            shelfCanvas.SetActive(false);
            shelfActionButt.SetActive(false);
        }

        bedActionButt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.transform.position, camera.transform.forward * raycastLenght, Color.blue);

        doorRay();
        
        if (pcMask != 0)
        {
            pcRay();
        }

        if (bedMask != 0)
        {
            bedRay();
        }

        if (shelfMask != 0)
        {
            shelfRay();
        }

        if (!isHolding)
        {
            boxRay();
        }
        else
        {
            dropBox();
        }
    }

    void pcRay()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, raycastLenght, pcMask))
        {
            pcActionButt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                playerMovement.canMove = false;

                Cursor.lockState = CursorLockMode.Confined;
                inventoryCanvas.SetActive(true);
            }
        }
        else
        {
            pcActionButt.SetActive(false);
        }
    }

    void doorRay()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, raycastLenght, doorLayer))
        {
            doorsActionButt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                playerMovement.canMove = false;

                Cursor.lockState = CursorLockMode.Confined;
                sceneManager.SetActive(true);
            }
        }
        else
        {
            doorsActionButt.SetActive(false);
        }
    }

    void bedRay()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, raycastLenght, bedMask))
        {
            bedActionButt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                dayManager.days = dayManager.days + 1;
            }
        }
        else
        {
            bedActionButt.SetActive(false);
        }
    }

    void boxRay()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, raycastLenght, boxMask))
        {
            if (Input.GetKeyDown(KeyCode.F) && boxScript.createdCount == boxScript.globalCount)
            {
                hit.collider.gameObject.transform.parent = gameObject.transform;

                hit.collider.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);

                hit.collider.transform.position = pointSpawn.transform.position;
                hit.collider.transform.rotation = pointSpawn.transform.rotation;

                isHolding = true;
            }
        }
    }

    void dropBox()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, raycastLenght, boxPosition))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Transform krabice = gameObject.transform.Find("Krabice(Clone)").gameObject.transform;
                krabice.parent = hit.collider.gameObject.transform;

                krabice.position = hit.collider.gameObject.transform.position;

                krabice.GetChild(0).gameObject.SetActive(true);

                isHolding = false;
            }
        }
    }

    void shelfRay()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, raycastLenght, shelfMask))
        {
            shelfActionButt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                playerMovement.canMove = false;

                shelfCanvas.SetActive(true);

                Cursor.lockState = CursorLockMode.Confined;

                if (hit.transform.gameObject.tag == "colorTag")
                {
                    shopCanvas.Id = 0;
                } else if (hit.transform.gameObject.tag == "paperTag")
                {
                    shopCanvas.Id = 1;
                } else
                {
                    shopCanvas.Id = 2;
                }
            }
        }
        else
        {
            shelfActionButt.SetActive(false);
        }
    }
}
