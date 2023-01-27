using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatePickerCtrl : MonoBehaviour
{
    [SerializeField] Image characterIMG;
    [SerializeField] TextMeshProUGUI characterTXT, scoreTXT;
    Animator anim;
    int currCharaIndex;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        if(GameManager.instance.pursuableDates.Count > 0)
        {
            characterIMG.sprite = GameManager.instance.pursuableDates[currCharaIndex].neutralIMG;
            characterTXT.text = GameManager.instance.pursuableDates[currCharaIndex].dateName;
        }
        else
        {
            characterIMG.gameObject.SetActive(false);
            SelectCharacter();
        }
        scoreTXT.text = GameManager.instance.currGameScore.ToString("0");
        anim = GetComponent<Animator>();
    }
    public void NextCharacter()
    {
        if(currCharaIndex + 1 > GameManager.instance.pursuableDates.Count -1)
        {
            currCharaIndex = 0;
        }
        else
        {
            currCharaIndex++;
        }
        characterIMG.sprite = GameManager.instance.pursuableDates[currCharaIndex].neutralIMG;
        characterTXT.text = GameManager.instance.pursuableDates[currCharaIndex].dateName;
    }
    public void PrevCharacter()
    {
        if (currCharaIndex - 1 < 0)
        {
            currCharaIndex = GameManager.instance.pursuableDates.Count - 1;
        }
        else
        {
            currCharaIndex--;
        }
        characterIMG.sprite = GameManager.instance.pursuableDates[currCharaIndex].neutralIMG;
        characterTXT.text = GameManager.instance.pursuableDates[currCharaIndex].dateName;
    }
    public void SelectCharacter()
    {
        if (GameManager.instance.pursuableDates.Count > 0)
        {
            characterIMG.sprite = GameManager.instance.pursuableDates[currCharaIndex].happyIMG;
        }
        else
        {

        }
        anim.SetTrigger("DatePicked");
    }
}
