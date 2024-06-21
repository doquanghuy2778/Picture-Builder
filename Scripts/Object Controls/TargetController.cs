using Unity.VisualScripting;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject Target;
    private static TargetController _instance;
    public static TargetController Instance { get => _instance; }

    private void Awake()
    {
        _instance = this;
    }

    private void Reset()
    {
        Target = gameObject;        
    }

    private void Start()
    {
        Target = gameObject;
    }

    public Vector2 GetSize()
    {
        float witdh = gameObject.GetComponent<RectTransform>().localScale.x;
        float height = gameObject.GetComponent<RectTransform>().localScale.y;
        float sizeDeltaX = gameObject.GetComponent<RectTransform>().sizeDelta.x;
        float sizeDeltaY = gameObject.GetComponent<RectTransform>().sizeDelta.y;
        return new Vector2(witdh * sizeDeltaX, height * sizeDeltaY);
    }
}
