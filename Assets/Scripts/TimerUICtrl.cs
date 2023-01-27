using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class TimerUICtrl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTXT;
    [SerializeField] float countDownFrom = 60;
    [SerializeField] UnityEvent timerDone;
    public Action onTimeUp;
    Animator anim;
    float timer;
    float Timer { get { return timer; } set { timer = value < 0 ? 0 : value; /*<-- Stops timer dropping below 0*/ UpdateTimer(); } } //Calls UpdateTimer when value is changed
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        ResetTimer();
        anim.SetBool("Enabled", true);
    }
    private void OnDisable()
    {
        anim.SetBool("Enabled", false);
    }
    private void Update()
    {
        if(Timer > 0 && GameManager.instance.currGameState != GameStates.PAUSED)
        {
            Timer -= Time.deltaTime;
        }

        if(Timer <= 0)
        {
            this.enabled = false;
            //Debug.Log("Timer done");
            timerDone?.Invoke();
        }
    }
    void UpdateTimer()
    {
        timerTXT.text = Timer.ToString("0");
    }
    public void ResetTimer()
    {
        Timer = countDownFrom;
    }
}
