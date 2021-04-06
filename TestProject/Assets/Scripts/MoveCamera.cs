using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    ///Вільний рух камери в просторі
    public static float mainSpeed = 100.0f;
    public static float camSens = 2f;
    private Vector3 lastMouse;
    public static bool activateScrollMove= false;
    public Toggle[] toggleCheckMove=new Toggle[2];
    public Text textChangeNameTypeSpeedMove;
    public GameObject[] enableSettingsMove = new GameObject[4];

    void LateUpdate()
    {
        ChangeTypeMove();
  
        if (toggleCheckMove[0].isOn == true)
        {
            textChangeNameTypeSpeedMove.text = "SpeedMove";
            for(int i = 0; i < 4; i++) 
            {
                enableSettingsMove[i].SetActive(true);
            }
            activateScrollMove = false;

            lastMouse = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);

            transform.eulerAngles = lastMouse;

            Vector3 p = GetBaseInputSpeedMove() * mainSpeed;
            p = p * Time.deltaTime;
            transform.Translate(p);
        }
        else if(toggleCheckMove[1].isOn == true)
        {
            textChangeNameTypeSpeedMove.text = "SpeedScroll";
            for (int i = 0; i < 4; i++)
            {
                enableSettingsMove[i].SetActive(false);
            }
            activateScrollMove = true;
        }
    }

    private void ChangeTypeMove()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            toggleCheckMove[0].isOn = true;
            toggleCheckMove[1].isOn = false;
        }

        if (Input.GetKey(KeyCode.E))
        {
            toggleCheckMove[1].isOn = true;
            toggleCheckMove[0].isOn = false;
        }

        if (Input.GetKey(KeyCode.R))
        {
            toggleCheckMove[1].isOn = false;
            toggleCheckMove[0].isOn = false;
            activateScrollMove = false;
        }
    }

    private Vector3 GetBaseInputSpeedMove()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
