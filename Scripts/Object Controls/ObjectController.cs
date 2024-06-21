using UnityEngine;
using UnityEngine.EventSystems;
using com.ootii.Messages;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject Target;
    private bool _isPoiter;
    public string ID;
    public Image Image;
    public RectTransform RectTransform;
    private static ObjectController _instance;
    public static ObjectController Instance { get =>  _instance; }

    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        ActiveInstance();
        _isPoiter = true;
        MessageDispatcher.AddListener(MessageID.OnSendPicData, GetTarget, true);
    }
    
    private void OnDisable()
    {
        MessageDispatcher.RemoveListener(MessageID.OnSendPicData, GetTarget, true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _isPoiter = false;
            float distance = Vector2.Distance(transform.position, (Vector2)Target.transform.position);
            if (distance <= 0.2f)
            {
                transform.position = (Vector2)Target.transform.position;
                GameManager.Instance.CountTarget++;
                PictureController pictureController = PictureManager.Instance.GetPictureController(ID);
                pictureController.Target.SetActive(false); 
                gameObject.GetComponent<ObjectController>().enabled = false;
            }
            else
            {
                
                MessageDispatcher.SendMessage(this, MessageID.OnClickPicture, ID, 0);
                gameObject.SetActive(false);
            }
        }

        if (_isPoiter)
        {
            ActiveInstance();
        }
    }

    private void ActiveInstance()
    {
        transform.position = PictureManager.Instance.GetMousePosition();
    }

    private void GetTarget(IMessage msg)
    {
        Target = TargetManager.Instance.GetTarget(ID);
        RectTransform.sizeDelta = TargetManager.Instance.GetSize(ID);
    }
}
