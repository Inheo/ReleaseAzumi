using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    public GameObject[] Maps;

    private void Start()
    {
        GameObject map = Maps[PlayerPrefs.GetInt("Level", 0)];
        Instantiate(map);
    }
}
