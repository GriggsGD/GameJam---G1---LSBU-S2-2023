using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FudgeBarCtrl : MonoBehaviour
{
    [SerializeField] Image bar, barEndIMG;
    [SerializeField] Sprite heart, brokenHeart;
    [SerializeField] float brokenHeartTH = .1f;
    float fillAmount = 1;
    public float FillAmount { get { return fillAmount; } private set { fillAmount = value < 0 ? 0 : (value > 1 ? 1 : value); /*<-- keeps value between 0 - 1 range*/ UpdateUI(); } } //Calls UpdateUI everytime a new value is set
    [SerializeField] float decreasePerSec = .05f, startingFillAmount = .5f;
    float barWidth;
    private void Start()
    {
        barWidth = bar.rectTransform.sizeDelta.x;
        SetFill(startingFillAmount);
    }
    private void Update()
    {
        if (FillAmount > 0 && GameManager.instance.currGameState != GameStates.PAUSED)
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
        bar.fillAmount = FillAmount;
        barEndIMG.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(-barWidth, 0, FillAmount), barEndIMG.rectTransform.anchoredPosition.y);
        barEndIMG.sprite = FillAmount < brokenHeartTH ? brokenHeart : heart;
        if (FillAmount < brokenHeartTH)
        {
            barEndIMG.sprite = brokenHeart;
            barEndIMG.color = Color.white;
        }
        else {
            barEndIMG.sprite = heart;
            barEndIMG.color = Color.red;
        }
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
