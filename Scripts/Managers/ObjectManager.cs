using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public ObjectController ObjectController;
    private List<PictureData> _pictureDatas;
    [SerializeField] ObjectController itemPrefab;
    [SerializeField] Transform itemParentTranform;
    private static ObjectManager _instance;
    public static ObjectManager Instance { get => _instance; }
    private List<ObjectController> _listObjectController;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _pictureDatas = PlayyardManager.Instance.ListTargetData;
        CreateItem();
    }

    public void CreateItem()
    {
        _listObjectController = new List<ObjectController>();
        foreach (var item in _pictureDatas)
        {
            ObjectController objectController = Instantiate(itemPrefab, itemParentTranform);
            objectController.ID = item.ID;
            objectController.Image.sprite = item.Sprite;
            _listObjectController.Add(objectController);
            objectController.gameObject.SetActive(false);
        }
    }

    public ObjectController GetObject(string id)
    {
        foreach (var item in _listObjectController)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        return null;
    }
}
