using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float Distance;
    public bool Horizontal,
                Vertical;
    
    [HideInInspector]
    public Vector3 StartPosition;

    private void Awake()
    {
        StartPosition = transform.position;
    }
}
