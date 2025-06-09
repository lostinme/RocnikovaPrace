// Jakub Fussek, 3.C PVA, Sticker Mania

using UnityEngine;
using UnityEngine.UI;

public class imageMovement : MonoBehaviour
{
    public RawImage[] imgs = new RawImage[1];

    // Start is called before the first frame update
    void Start()
    {
        

        if (bottomPanel.ID == 0)
        {
            RawImage img = transform.GetComponentInChildren<RawImage>();
            img.texture = EmailContent.currentTexture;
        } else if (bottomPanel.ID == 1)
        {
            for (int i = 0; i < imgs.Length; i++)
            {
                imgs[i].texture = EmailContent.currentTexture;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 3f * Time.deltaTime);       
    }
}
