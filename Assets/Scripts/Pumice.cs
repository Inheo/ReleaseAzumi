using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumice : MonoBehaviour
{
    public int CountOfCollisionsToFill = 80;
    public float speedFill = 4;
    public float boxCollider2DFullSizeY;

    public Action WhenFilling;

    public Transform ChildTransform;

    private CheckResult CheckResult;

    private int CountOfCollisions = 0;

    private float boxCollider2DOffsetY;
    private float boxCollider2DFullOffsetY;
    private float fillPercent = 0;
    private float boxCollider2DSizeY;

    private BoxCollider2D boxCollider2D;


    private void Start()
    {
        CheckResult = AllDataInScene.Instance.CheckResult;
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2DFullOffsetY = -(boxCollider2DFullSizeY / 2);
        WhenFilling += CheckResult.LevelPassed;
    }

    private void Update()
    {
        if (CountOfCollisions > 0)
        {
            boxCollider2D.size = Vector2.MoveTowards(boxCollider2D.size, new Vector2(boxCollider2D.size.x, boxCollider2DSizeY), speedFill * Time.deltaTime);
            boxCollider2D.offset = Vector2.MoveTowards(boxCollider2D.offset, new Vector2(boxCollider2D.offset.x, boxCollider2DOffsetY), speedFill * Time.deltaTime);
            ChildTransform.localPosition = new Vector3(ChildTransform.localPosition.x, boxCollider2D.size.y, 0);
        }
    }

    public void AddFillPercent()
    {
        CountOfCollisions++;
        fillPercent = (CountOfCollisions * 100) / CountOfCollisionsToFill;
        fillPercent = Mathf.Clamp(fillPercent, 0f, 100f);
        boxCollider2DSizeY = (boxCollider2DFullSizeY * fillPercent) / 100;
        boxCollider2DOffsetY = (boxCollider2DFullOffsetY * (100 - fillPercent)) / 100;

        if (fillPercent == 100)
        {
            WhenFilling?.Invoke();
        }
    }
}
