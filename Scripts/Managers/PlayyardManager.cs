using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayyardManager : MonoBehaviour
{
    [System.Serializable]
    public class TargetPicture
    {
        public string ID;
        public TargetController TargetController;
    }

    public static PlayyardManager Instance;

    public int NumberPictureNeedCollect;

    public List<TargetPicture> Pictures;
    public static Dictionary<string, Sprite[]> PictureDict;
    public List<PictureData> ListTargetData;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnStart();
    }

    public void OnStart()
    {
        //InitData();
        ListTargetData = PictureToCollect();
        SamePicture();
    }

    private void Reset()
    {
        Pictures = new List<TargetPicture>();

        TargetController[] childs = transform.GetComponentsInChildren<TargetController>();
        int count = 0;
        foreach (var child in childs)
        {
            count++;
            TargetPicture targetPicture = new TargetPicture();
            targetPicture.ID = count.ToString();
            targetPicture.TargetController = child;
            Pictures.Add(targetPicture);
        }
        //InitData();
    }

    //private void InitData()
    //{
    //    PictureDict = new Dictionary<string, Sprite[]>();

    //    foreach(var targetPicture in Pictures)
    //    {
    //        List<Sprite> sprites = new List<Sprite>();
    //        foreach(var spr in targetPicture.TargetController.SprNormal)
    //        {
    //            sprites.Add(spr.sprite);
    //        }
    //        targetPicture.TargetController.InitID(targetPicture.ID).InitPicture(sprites.ToArray());
    //        PictureDict.Add(targetPicture.ID, targetPicture.TargetController.Pictures);
    //    }
    //}

    public List<PictureData> PictureToCollect()
    {
        List<PictureData> pictureDatas = new List<PictureData>();
        while(pictureDatas.Count < NumberPictureNeedCollect)
        {
            PictureData pictureData = new PictureData();
            TargetPicture picture = Pictures[Random.Range(0, Pictures.Count)];
            picture.TargetController.GetComponent<Image>().color = ImageColorReplacer.Instance.color;
            pictureData.ID = picture.ID;
            pictureData.Sprite = picture.TargetController.gameObject.GetComponent<Image>().sprite;
            if (!IsListContainID(pictureDatas, pictureData.ID))
                pictureDatas.Add(pictureData);
        }
        return pictureDatas;
    }

    public List<TargetPicture> SamePicture()
    {
        List<PictureData> pictureDatas = ListTargetData;
        List<TargetPicture> target = new List<TargetPicture>();
        foreach(var item in Pictures)
        {
            foreach(var obj in pictureDatas)
            {
                if(item.ID == obj.ID)
                {
                    target.Add(item);
                }
            }
        }
        return target; 
    }

    private bool IsListContainID(List<PictureData> pictureDatas, string id)
    {
        foreach(var pictureData in pictureDatas)
        {
            if (pictureData.ID == id)
                return true;
        }
        return false;
    }    

    public int GetPictureCount()
    {
        return Pictures.Count;
    }
}
