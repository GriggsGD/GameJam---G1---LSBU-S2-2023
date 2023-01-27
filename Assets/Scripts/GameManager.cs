using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameStates
{
    MENU,
    PLAYING,
    PAUSED
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public DateGameplaySO[] dates;
    public int currDateIndex;
    public int currGameScore;
    public GameStates currGameState { get; private set; } = GameStates.MENU;
    public List<float> currDatesFudge = new List<float>();
    public List<DateGameplaySO> pursuableDates = new List<DateGameplaySO>();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        currGameState = GameStates.MENU;
    }
    public void PauseGame(bool _active)
    {
        currGameState = _active ? GameStates.PAUSED : GameStates.PLAYING;
    }
    public void StartGame()
    {
        ResetValues();
        SceneManager.LoadScene(1);
        currGameState = GameStates.PLAYING;
    }
    public void LoadNextDate()
    {
        float fudgeFill = FindObjectOfType<FudgeBarCtrl>().FillAmount;
        currDatesFudge.Add(fudgeFill);
        currGameScore += fudgeFill <= .25f ? 2 : (fudgeFill <= .5f ? 5 : (fudgeFill <= .75f ? 8 : 10));
        if(currDateIndex >= dates.Length - 1)
        {
            LoadDatePicker();
        }
        else
        {
            currDateIndex++;
            SceneManager.LoadScene(1);
        }
    }
    public void LoadDatePicker()
    {
        for (int i = 0; i < currDatesFudge.Count; i++)
        {
            if(currDatesFudge[i] > .75f)
            {
                pursuableDates.Add(dates[i]);
            }
        }
        pursuableDates.TrimExcess();
        //Load date picker scene
        SceneManager.LoadScene(2);
    }
    void ResetValues()
    {
        currDateIndex = 0;
        currGameScore = 0;
        currDatesFudge.Clear();
        currDatesFudge.TrimExcess();
        pursuableDates.Clear();
        pursuableDates.TrimExcess();
    }
}
