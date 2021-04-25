using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressUpHero : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer head;
    [SerializeField] protected SpriteRenderer body;

    [SerializeField] protected SpriteRenderer rightHand;
    [SerializeField] protected SpriteRenderer leftHand;

    [SerializeField] protected SpriteRenderer rightLeg;
    [SerializeField] protected SpriteRenderer leftLeg;

    [Space]
    [SerializeField] protected Sprite[] heads;
    [SerializeField] protected Sprite[] bodies;
    [SerializeField] protected Sprite[] rightHands;
    [SerializeField] protected Sprite[] leftHands;
    [SerializeField] protected Sprite[] rightLegs;
    [SerializeField] protected Sprite[] leftLegs;

    protected AllData allData;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(AllData.KEY))
            allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(AllData.KEY));
    }
    private void Start()
    {
        DressUp();
    }
    protected void DressUp()
    {
        head.sprite = heads[allData.Head];
        body.sprite = bodies[allData.Body];
        rightHand.sprite = rightHands[allData.Hand];
        leftHand.sprite = leftHands[allData.Hand];
        rightLeg.sprite = rightLegs[allData.Leg];
        leftLeg.sprite = leftLegs[allData.Leg];
    }
}
