using System;
using UnityEngine;

public class AllData
{
    public const string KEY = "allData";

    public int Head = 0;
    public int Body = 0;
    public int Hand = 0;
    public int Leg = 0;

    public void SaveAllParametrs(AllData allParametrs)
    {
        string json = JsonUtility.ToJson(allParametrs);
        PlayerPrefs.SetString(KEY, json);
    }

    //public AllData LoadAllParametrs()
    //{
    //    return JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(KEY, DefaultParametrValue()));
    //}

    //private string DefaultParametrValue()
    //{
    //    AllData newAllData = new AllData();
    //    string json = JsonUtility.ToJson(newAllData);
    //    PlayerPrefs.SetString(KEY, json);
    //    return PlayerPrefs.GetString(KEY);
    //}
}
