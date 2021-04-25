using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : DressUpHero
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        DressUp();
        CheckResult.Instance.LevelPassedEvent += Joy;
    }

    private void Joy()
    {
        animator.SetBool("Win", true);
    }

    private void Sad()
    {
        animator.SetBool("Lose", true);
    }
}
