using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckResult : MonoBehaviour
{
    public static CheckResult Instance;

    public SpawnLevel SpawnLevel;

    public Action HidePin;
    public event Action LevelPassedEvent;

    public GameObject BgWin;

    private bool win;

    public bool Win { get { return win; } }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (win)
        {
            BgWin.transform.localScale = Vector3.MoveTowards(BgWin.transform.localScale, Vector3.one, Time.deltaTime * 5);
        }
    }

    public void LevelPassed()
    {
        //Invoke("MethodForDelay", 3f);
        HidePin?.Invoke();
        win = true;
        IndexNextLevel();
        LevelPassedEvent?.Invoke();
    }


    public void NextLevelLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void MethodForDelay()
    {
        HidePin?.Invoke();
        win = true;
    }

    private void IndexNextLevel()
    {
        int indexLevel = PlayerPrefs.GetInt("Level", 0) + 1;
        indexLevel = Mathf.Clamp(indexLevel, 0, SpawnLevel.Maps.Length - 1);

        PlayerPrefs.SetInt("Level", indexLevel);
    }
}
