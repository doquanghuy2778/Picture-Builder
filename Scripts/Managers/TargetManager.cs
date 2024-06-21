using com.ootii.Messages;
using UnityEngine;      
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;

public class TargetManager : MonoBehaviour
{   
    [System.Serializable]
    public class TargetData
    {
        public string ID;
        public GameObject Target;
        public Vector2 SizeDelta;   
    }

    public static TargetManager Instance { get; private set; }
    private string ID;
    private bool _isGetData;
    private List<PictureData> _picturesTarget;

    [Header("TargetCTL")]
    public List<TargetData> Target;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _picturesTarget = PlayyardManager.Instance.ListTargetData;
        GetDataList();  
    }

    public GameObject GetTarget(string id)
    {
        foreach(var target in Target) 
        {
            if (target.ID == id)
                return target.Target;
        }
        return null;
    }

    public Vector2 GetSize(string id)
    {
        foreach (var target in Target)
        {
            if (target.ID == id)
            {
                return target.SizeDelta;
            }
        }
        return Vector2.zero;
    }

    private void GetDataList()
    {
        foreach(var item in PlayyardManager.Instance.SamePicture())
        {
            Target.Add(new TargetData {ID = item.ID,
                                       Target = item.TargetController.Target,
                                       SizeDelta = item.TargetController.GetSize()});
        }
    }
}
