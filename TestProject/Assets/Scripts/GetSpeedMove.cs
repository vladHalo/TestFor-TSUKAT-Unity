using UnityEngine;
using UnityEngine.UI;
using static MoveCamera;

public class GetSpeedMove : MonoBehaviour
{
    ///Отримання і встановлення швидкості і чутливості мишки
    public InputField []inputField=new InputField[2];

    private void Start()
    {
        inputField[0].GetComponent<InputField>().text = mainSpeed.ToString();
        inputField[1].GetComponent<InputField>().text = camSens.ToString();
    }

    public void GetTextSpeedMoveCamera(string speedMove)
    {
        mainSpeed = float.Parse(speedMove);
    }

    public void GetTextSpeedMoveMouse(string speedMove)
    {
        camSens = float.Parse(speedMove);
    }
}
