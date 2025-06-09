// Jakub Fussek, 3.C PVA, Sticker Mania

using UnityEngine;

public class starRay : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public LayerMask star;

    float distance = 5;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, distance, star))
        {
            Debug.DrawRay(transform.position, Vector3.forward * distance, Color.blue);

            count = 1;
        } else
        {
            count = 0;
        }
    }
}
