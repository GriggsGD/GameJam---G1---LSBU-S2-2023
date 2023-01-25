using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimerUICtrl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTXT;
    [SerializeField] float countDownFrom = 60;
    [SerializeField] UnityEvent timerDone;
    float timer;
    float Timer { get { return timer; } set { timer = value < 0 ? 0 : value; /*<-- Stops timer dropping below 0*/ UpdateTimer(); } } //Calls UpdateTimer when value is changed
    private void OnEnable()
    {
        ResetTimer();
    }
    private void Update()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        if(Timer <= 0)
        {
            this.enabled = false;
            Debug.Log("Timer done");
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
