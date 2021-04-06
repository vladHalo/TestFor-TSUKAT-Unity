using UnityEngine;

public class ItemsName : MonoBehaviour
{
    ///Поворот назв обєктів на камеру
    public GameObject[] textItems;

    void Start()
    {
        textItems[0].transform.rotation = Camera.main.transform.rotation;
    }

    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 objectNormal = textItems[i].transform.rotation * Vector3.forward;
            Vector3 cameraToText = textItems[i].transform.position - Camera.main.transform.position;
            float f = Vector3.Dot(objectNormal, cameraToText);
            
            if (f < 0f)
            {
                textItems[i].transform.Rotate(0f, 180f, 0f);
            }
        }
    }
}
