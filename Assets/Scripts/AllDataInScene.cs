using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDataInScene : MonoBehaviour
{
    public static AllDataInScene Instance;

    public CheckResult CheckResult;

    public GameObject ParentWater,
                        ParentLava;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
