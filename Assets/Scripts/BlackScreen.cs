using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public float Speed;

    public CheckResult CheckResult;

    private Image blackScreenImage;

    private Color transitionColor;

    private void Start()
    {
        blackScreenImage = GetComponent<Image>();
        blackScreenImage.color = new Color(blackScreenImage.color.r, blackScreenImage.color.g, blackScreenImage.color.b, 1);
        transitionColor = blackScreenImage.color;
        transitionColor.a = 0;

        CheckResult.LevelPassedEvent += LevelPassed;
    }

    private void Update()
    {
        blackScreenImage.color = Vector4.MoveTowards(blackScreenImage.color, transitionColor, Time.deltaTime * Speed);
        if(CheckResult.Win && blackScreenImage.color.a == transitionColor.a && transitionColor.a == 1)
        {
            Invoke("NextLevel", 0.5f);
        }
    }

    public void LevelPassed()
    {
        Invoke("MethodForDelay", 0.5f);
    }
    
    private void MethodForDelay()
    {
        transitionColor.a = 1;
    }

    private void NextLevel()
    {
        CheckResult.NextLevelLoad();
    }
}
