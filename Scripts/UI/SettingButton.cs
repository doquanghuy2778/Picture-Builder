using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public Image ButtonImg;
    public Sprite ButtonSprite1, ButtonSprite2;

    private void OnMouseDown()
    {
        ButtonImg.sprite = ButtonSprite2;
    }

    private void OnMouseUp()
    {
        ButtonImg.sprite = ButtonSprite1;
    }
}
