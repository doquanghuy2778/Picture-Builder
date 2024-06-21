using com.ootii.Messages;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PictureController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject Target;
    private Sprite _picture;
    public Sprite Picture => _picture;

    private string _id;
    public string ID => _id;

    private Vector2 _mouPos;
    private RectTransform _targetRectTransform, _myRectTransform;
    public bool IsInside;
    [SerializeField] Image _sprNormal;
    private static PictureController _instance;
    public static PictureController Instance { get => _instance; }

    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        MessageDispatcher.AddListener(MessageID.OnClickPicture, ONPicture, true);
    }

    private void OnDisable()
    {
        MessageDispatcher.RemoveListener(MessageID.OnClickPicture, ONPicture, true);
    }

    public PictureController InitPicture(Sprite picture)
    {
        _picture = picture;
        _sprNormal.sprite = _picture;
        return this;
    }

    public PictureController InitID(string id)
    {
        _id = id;
        return this;
    }

    private void Start()
    {
        _myRectTransform = GetComponent<RectTransform>();
        SetScale();
        _targetRectTransform = PictureManager.Instance.TargetRectTransform;
    }

    private void Update()
    {
        _mouPos = PictureManager.Instance.GetMousePosition();
        //check vi tri bam nam trong ScrollBar
        IsInside = RectTransformUtility.RectangleContainsScreenPoint(_targetRectTransform, _myRectTransform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        MessageDispatcher.SendMessage(this, MessageID.OnSendPicData, ID, 0);
        if (!IsInside)
        {
            gameObject.GetComponent<Image>().enabled = false;
            ObjectManager.Instance.GetObject(_id).gameObject.SetActive(true);
        }
        _myRectTransform.position = _mouPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        BackToStart();
    }

    private void ONPicture(IMessage msg)
    {
        BackToStart();
        gameObject.GetComponent<Image>().enabled = true;
    }

    private void SetScale()
    {
        GameObject Target;
        Target = TargetManager.Instance.GetTarget(ID);
        float widthTarget = Target.GetComponent<RectTransform>().sizeDelta.x;
        float heightTarget = Target.GetComponent<RectTransform>().sizeDelta.y;  
        _myRectTransform.sizeDelta = new Vector2(widthTarget * 4f, heightTarget * 4f);
    }

    private void BackToStart()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 13, 0);
    }
}
