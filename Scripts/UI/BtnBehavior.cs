using DG.Tweening;
using System;
using UnityEngine;

public class BtnBehavior : MonoBehaviour
{
    [SerializeField] GameObject SpriteOn;
    [SerializeField] GameObject SpriteOff;
    [SerializeField] GameObject BgOn;
    [SerializeField] GameObject BgOff;
    [SerializeField] Transform toggle;
    protected bool value;
    protected bool isTweening = false;

    private void OnEnable()
    {
        float x = value ? Mathf.Abs(toggle.localPosition.x) : -Mathf.Abs(toggle.localPosition.x);
        toggle.localPosition = new Vector3(x, 0, 0);
        Debug.Log("value: " + value);
        SetSprIcon();
    }

    public virtual void OnClick()
    {
        Toggle();
    }

    private void Toggle()
    {
        isTweening = true;
        value = !value;
        toggle.DOLocalMoveX(-toggle.localPosition.x, 0.1f).SetEase(Ease.InOutQuad).OnComplete(() => isTweening = false);
        Debug.Log(-toggle.localPosition.x);
        SetSprIcon();
    }

    private void SetSprIcon()
    {
        SpriteOn.SetActive(value);
        SpriteOff.SetActive(!value);

        BgOn.SetActive(value);
        BgOff.SetActive(!value);
    }
}
