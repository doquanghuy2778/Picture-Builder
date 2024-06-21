using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LinkObject : MonoBehaviour
{
    [System.Serializable]
    public class TargetLink
    {
        public List<TargetController> _listNeerObject;
    }

    private List<PictureData> _pictureData;
    private List<TargetController> _targetsDel;
    private int _curr;
    [SerializeField] private List<TargetLink> _links;    
    private void Start()
    {
        _targetsDel = new List<TargetController>();
        _pictureData = PlayyardManager.Instance.ListTargetData;
        FindCurrObjectInTarget();
    }

    private void FindCurrObjectInTarget()
    {
        foreach (var item in _links)
        {
            int count = 0;
            foreach (var obj in item._listNeerObject)
            {
                Sprite spriteObject = obj.GetComponent<Image>().sprite;
                foreach (var objectData in _pictureData)
                {
                    if (spriteObject == objectData.Sprite)
                    {
                        count++;
                    }
                }
            }

            if (count >= 2)
            {
                int index = Random.Range(0, count);
                Debug.Log("index " + index);
                for (int i = 0; i < item._listNeerObject.Count; i++)
                {
                    if (i == index)
                    {
                        continue;
                    }
                    else
                    {
                        item._listNeerObject[i].gameObject.GetComponent<TargetController>().enabled = false;
                        item._listNeerObject[i].gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                        _targetsDel.Add(item._listNeerObject[i]);
                    }
                }
            }
        }
        DeleteTarget();
    }

    private void DeleteTarget()
    {
        List<PictureData> list = new List<PictureData>();
        foreach (var item in _targetsDel)
        {
            Sprite spriteItem = item.GetComponent<Image>().sprite;
            foreach (var obj in _pictureData)
            {
                if (spriteItem == obj.Sprite)
                {
                    list.Add(obj);  
                }
            }
        }


        foreach(var item in list)
        {
            _pictureData.Remove(item);
        }
    }
}
