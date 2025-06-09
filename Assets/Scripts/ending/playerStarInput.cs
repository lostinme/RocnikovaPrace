// Jakub Fussek, 3.C PVA, Sticker Mania

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStarInput : MonoBehaviour
{
    public static int starCount;

    public List<GameObject> evidenceHvezd = new List<GameObject>();

    public LayerMask mask;

    public GameObject star;

    GameObject starGm;
    public GameObject starStartPoint;

    RaycastHit hit;

    Vector3 mousePos;
    Vector3 zPos;

    bool isHoldingStar;

    int vyhodnoceniInt = 0;

    public GameObject konecnaTabulka;
    public TextMeshProUGUI textKonce;
    // Start is called before the first frame update
    void Start()
    {
        konecnaTabulka.SetActive(false);

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        starRay();
    }

    void starRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000, mask))
            {
                starGm = Instantiate(star);
                isHoldingStar = true;

                zPos.z = hit.distance;
            }
        }

        if (isHoldingStar)
        {
            Debug.Log(starGm.name);

            mousePos = Input.mousePosition;
            mousePos.z = zPos.z;

            Vector3 starPos = Camera.main.ScreenToWorldPoint(mousePos);

            starGm.transform.position = starPos;

            if (Input.GetMouseButtonDown(1))
            {
                starGm.transform.position = starPos;
                isHoldingStar = false;

                evidenceHvezd.Add(starGm);

                AudioSource source = starGm.GetComponent<AudioSource>();

                source.volume = source.volume * mainMenu.audioValue;

                source.Play();
            }
        }
    }

    public void vyhodnoceni()
    {
        for (int i = 0; i < evidenceHvezd.Count; i++)
        {
            starRay script = evidenceHvezd[i].GetComponent<starRay>();

            vyhodnoceniInt += script.count;
        }

        konecnaTabulka.SetActive(true);
        textKonce.text = $"Dìkuji, že jsi ohodnotil hru {vyhodnoceniInt} hvìzd. \n\n\n Stisknutím tlaèítka se vrátíš do hlavního menu.";
    }

    public void konec()
    {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }
}
