using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using com.ootii.Messages;
using System.Linq;

public class TargetPictureController : MonoBehaviour, IPointerClickHandler
{
    private Sprite[] _pictures;
    public Sprite[] Pictures => _pictures;

    private string _id;
    public string ID => _id;

    public List<Image> SprNormal;

    public TargetPictureController AutoInitSprite()
    {
        SprNormal = GetComponentsInChildren<Image>().ToList();
        return this;
    }

    public TargetPictureController InitPicture(params Sprite[] pictures)
    {
        _pictures = pictures;
        int count = 0;
        foreach(var picture in _pictures)
        {
            SprNormal[count].sprite = picture;
            count++;
        }
        return this;
    }

    public TargetPictureController InitID(string id)
    {
        _id = id;
        return this;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MessageDispatcher.SendMessage(this, MessageID.OnClickPicture, (ID, gameObject), 0);
    }
}
