using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPins : MonoBehaviour
{
    public CheckResult CheckResult;

    public float SpeedChangeColorPin;

    private SpriteRenderer[] spriteRendererPins;

    private bool Hide;

    void Start()
    {
        CheckResult.HidePin += HidePins;
        spriteRendererPins = ParentOfPins.Instance.ChildPinSprites;
    }

    private void Update()
    {
        if (Hide && spriteRendererPins[spriteRendererPins.Length - 1].color.a > 0)
        {
            for (int i = 0; i < spriteRendererPins.Length; i++)
            {
                Vector4 color = new Vector4(spriteRendererPins[i].color.r, spriteRendererPins[i].color.g, spriteRendererPins[i].color.b, 0);
                spriteRendererPins[i].color = Vector4.MoveTowards(spriteRendererPins[i].color, color, SpeedChangeColorPin * Time.deltaTime);
            }
        }
    }

    public void HidePins()
    {
        Hide = true;
    }
}
