using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Messages;
using UnityEngine.UI;
using System;

public class PictureManager : MonoBehaviour
{
    List<PictureData> PictureDatas;
    public int IndexTranform;
    private List<PictureController> _pictures;
    public List<PictureController> Pictures
    {
        get => _pictures;
        set
        {
            _pictures = value;
        }
    }

    private static PictureManager instance;
    public static PictureManager Instance { get => instance; }

    public RectTransform TargetRectTransform;

    [SerializeField] Transform ContentTransform;

    [Header("Prefabs")]
    [SerializeField] GameObject PicturePrefab;
    public GameObject ObjectPrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Init();
        CreateNewPictureScrollView();
        IndexTranform = 0;
    }

    private void Init()
    {
        PictureDatas = PlayyardManager.Instance.ListTargetData;
    }

    public void CreateNewPictureScrollView()
    {
        for (int i = ContentTransform.childCount - 1; i >= 0; i--)
            Destroy(ContentTransform.GetChild(i));
    
        Pictures = new List<PictureController>(); 
        foreach(var pictureData in PictureDatas)
        {
            GameObject picture = Instantiate(PicturePrefab, ContentTransform);
            picture.GetComponentInChildren<PictureController>().InitID(pictureData.ID).InitPicture(pictureData.Sprite);
            Pictures.Add(picture.GetComponentInChildren<PictureController>());
        }
    }

    //Get Mouse positon
    public Vector3 GetMousePosition()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        temp.z = 0;
        return temp;
    }    

    public PictureController GetPictureController(string id)
    {
        foreach(var picture in Pictures)
        {
            if(picture.ID == id)
                return picture;
        }
        return null;
    }
}
