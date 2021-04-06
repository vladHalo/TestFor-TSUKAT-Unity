using UnityEngine;
using UnityEngine.UI;

public class EnableItems : MonoBehaviour
{
    ///Двойник клік для викл. обєкта
    int i = 0;
    float timeCheack = 0;
    public Toggle toggleCheck;

    void Update()
    {
        if (i == 1)
            timeCheack += Time.deltaTime;
    }

    public void OnMouseDown()
    {
        i++;
        if (timeCheack > 2f)
        {
            i = 0;
            timeCheack = 0;
        }

        if(i>1)
        {
            gameObject.SetActive(false);
            toggleCheck.isOn = false;
            i = 0;
            timeCheack = 0;
        }
    }

    public void ToggleChange(bool value)
    {
        if (value) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}