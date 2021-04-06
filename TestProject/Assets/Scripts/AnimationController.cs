using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    ///Запуск і виключення анімації,змінна швидкості
    public Animation animationMove;
    public Image buttonChangeImage;
    public Sprite[] spriteArray=new Sprite[2];
    bool flag = true;
    public Slider speedSlider;
    public Text textNumberSpeed;

    private void Start()
    {
        speedSlider.value = 1;
    }

    public void StartAnimation()
    {
        if (flag)
        {
            animationMove.Play("AnimationMove");
            buttonChangeImage.sprite = spriteArray[1];
            flag = false;
        }
        else
        {
            animationMove["AnimationMove"].enabled = false;
            buttonChangeImage.sprite = spriteArray[0];
            flag = true;
        }
    }

    public void SumbitSliderSetting() 
    {
        animationMove["AnimationMove"].speed = speedSlider.value;
        textNumberSpeed.text = animationMove["AnimationMove"].speed.ToString();
    }
}