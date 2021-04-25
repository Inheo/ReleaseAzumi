using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentOfPins : MonoBehaviour
{
    public static ParentOfPins Instance;

    public SpriteRenderer[] ChildPinSprites;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
