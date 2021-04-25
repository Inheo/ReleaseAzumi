using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customization : DressUpHero
{
    private void Start()
    {
        DressUp();
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    #region Head
    public void ChangeHead(int indexHead)
    {
        head.sprite = heads[indexHead];
        allData.Head = indexHead;
    }
    #endregion
    #region Body
    public void ChangeBody(int indexBody)
    {
        body.sprite = bodies[indexBody];
        allData.Body = indexBody;
    }
    #endregion
    #region Hand
    public void ChangeHand(int indexHand)
    {
        rightHand.sprite = rightHands[indexHand];
        leftHand.sprite = leftHands[indexHand];
        allData.Hand = indexHand;
    }
    #endregion
    #region Leg
    public void ChangeLeg(int indexLeg)
    {
        rightLeg.sprite = rightLegs[indexLeg];
        leftLeg.sprite = leftLegs[indexLeg];
        allData.Leg = indexLeg;
    }
    #endregion

    private void OnDestroy()
    {
        allData.SaveAllParametrs(allData);
    }
}
