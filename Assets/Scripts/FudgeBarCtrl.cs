using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FudgeBarCtrl : MonoBehaviour
{
    [SerializeField] RectTransform bar;
    float fillAmount = 1;
    public float FillAmount { get { return fillAmount; } private set { fillAmount = value < 0 ? 0 : (value > 1 ? 1 : value); /*<-- keeps value between 0 - 1 range*/ UpdateUI(); } } //Calls UpdateUI everytime a new value is set
    [SerializeField] float decreasePerSec = .05f, startingFillAmount = .5f;
    float maxFillWidth;
    private void Start()
    {
        maxFillWidth = bar.sizeDelta.x;
        SetFill(startingFillAmount);
    }
    private void Update()
    {
        if(FillAmount > 0)
        {
            FillAmount -= decreasePerSec * Time.deltaTime;
        }
        

        //Testing purposes
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AdjustFill(-.1f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AdjustFill(.1f);
        }
    }
    void UpdateUI()
    {
        bar.sizeDelta = new Vector2(maxFillWidth * FillAmount, bar.sizeDelta.y);
    }
    public void AdjustFill(float _amount)
    {
        FillAmount += _amount;
    }
    public void SetFill(float _value)
    {
        FillAmount = _value;
    }
}
