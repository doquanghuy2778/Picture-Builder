using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControler : MonoBehaviour
{
    public Image HealthPrefab;
    public int CurrHealth;
    public Transform HealthTranform;

    private List<Image> _imagesHP;

    private void Start()
    {
        Init(); 
    }

    private void Update() 
    {
        //if (ObjectController.Instance.IsUnTarget)
        //{
        //    CaculatorHP();
        //    ObjectController.Instance.IsUnTarget = false;
        //}
    }

    private void Init()
    {
        _imagesHP = new List<Image>();
        for(int i = 0; i < CurrHealth; i++) 
        {
            Image _images = Instantiate(HealthPrefab, HealthTranform);
            _imagesHP.Add(_images);
        }
    }

    private void CaculatorHP()
    {
        Destroy(_imagesHP[CurrHealth - 1]);
        CurrHealth--;
    }
}
 