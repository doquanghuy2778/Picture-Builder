using BayatGames.SaveGamePro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSave : MonoBehaviour
{
    public int CurrLevel;
    public int CurrSound;
    private static GameSave _instance;
    public static GameSave Instance { get =>  _instance; }
    public Button ButtonDelete;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GetLevel();
        //ButtonDelete.onClick.AddListener(DeleteData);
    }

    private void Update()
    {
        GetLevel();
    }

    private void GetLevel()
    {
        if (PlayerPrefs.GetInt("level") > 1)
        {
            CurrLevel = PlayerPrefs.GetInt("level");
        }
        else
        {
            CurrLevel = 1;
        }
    }

    private void DeleteData()
    {
        PlayerPrefs.DeleteKey("level");
    }


    public static void SetCacheObject<T>(string key, T objectSave)
    {
        SaveGame.Save(key, objectSave);
    }

    public static T LoadCacheObject<T>(string key)
    {
        T data = default;
        if (!SaveGame.Exists(key))
        {
            return data;
        }

        data = SaveGame.Load<T>(key);
        return data;
    }

    public static T LoadCacheObject<T>(string key, T defaultValue)
    {
        T data;
        if (!SaveGame.Exists(key))
        {
            data = defaultValue;
            SetCacheObject(key, data);
        }
        else
        {
            data = SaveGame.Load<T>(key);
        }
        return data;
    }

    public static bool IsConstainKey(string key)
    {
        return SaveGame.Exists(key);
    }

    public static void DeleteCacheObject(string key)
    {
        SaveGame.Delete(key);
    }
}
