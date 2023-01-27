using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateCtrl : MonoBehaviour
{
    [SerializeField] Animator anim, dateIMGAnim;
    [SerializeField] TimerUICtrl timerCtrl;
    [Header("Info Components")]
    [SerializeField]
    TextMeshProUGUI infoNameTXT;
    [SerializeField]
    TextMeshProUGUI ageTXT,
        occupationTXT,
        notesTXT,
        bioTXT,
        likesTXT,
        dislikesTXT;
    [SerializeField] Image infoDateIMG;
    [Header("Date Components")]
    [SerializeField]
    TextMeshProUGUI dateNameTXT;
    [SerializeField]
    TextMeshProUGUI dialogTXT,
        response1TXT,
        response2TXT,
        response3TXT;
    [SerializeField]
    Button response1BTN,
        response2BTN,
        response3BTN;
    [SerializeField] Image dateIMG;
    [SerializeField] Transform buttonsParent;
    [SerializeField] FudgeBarCtrl fudgeCtrl;
    [Header("Gameplay Settings")]
    [SerializeField] float fudgeBadDecrease = -.2f;
    [SerializeField] float fudgeGoodIncrease = .25f;
    GameManager gm;
    DateGameplaySO currDateData;
    int currDialogIndex = 0;
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Setup()
    {
        gm = GameManager.instance;
        currDateData = gm.dates[gm.currDateIndex];
        infoNameTXT.text = currDateData.dateName;
        ageTXT.text = currDateData.age;
        occupationTXT.text = currDateData.occupation;
        notesTXT.text = currDateData.notes;
        bioTXT.text = currDateData.bio;
        likesTXT.text = currDateData.likes;
        dislikesTXT.text = currDateData.dislikes;
        infoDateIMG.sprite = currDateData.neutralIMG;
        timerCtrl.onTimeUp = LoadDate;
    }
    public void LoadDate()
    {
        dialogTXT.text = currDateData.dialogs[0].dialog;
        response1TXT.text = currDateData.dialogs[0].gResponse;
        response2TXT.text = currDateData.dialogs[0].nResponse;
        response3TXT.text = currDateData.dialogs[0].bResponse;
        dateIMG.sprite = currDateData.neutralIMG;
        timerCtrl.enabled = false;
        timerCtrl.onTimeUp = null;
        anim.SetTrigger("InfoDone");
    }
    public void OnLoadDateAnimDone()
    {
        timerCtrl.enabled = true;
        timerCtrl.onTimeUp = EndDate;
    }
    public void LoadNextDialog()
    {
        if(currDialogIndex < currDateData.dialogs.Length - 1)
        {
            currDialogIndex++;
            dialogTXT.text = currDateData.dialogs[currDialogIndex].dialog;
            response1TXT.text = currDateData.dialogs[currDialogIndex].gResponse;
            response2TXT.text = currDateData.dialogs[currDialogIndex].nResponse;
            response3TXT.text = currDateData.dialogs[currDialogIndex].bResponse;
            RandomiseButtons();
        }
        else
        {
            EndDate();
        }
    }
    public void GoodResponse()
    {
        fudgeCtrl.AdjustFill(fudgeGoodIncrease);
        LoadNextDialog();
        StopAllCoroutines();
        StartCoroutine(ShowEmotion(true));
    }
    public void NeutralResponse()
    {
        LoadNextDialog();
    }
    public void BadResponse()
    {
        fudgeCtrl.AdjustFill(fudgeBadDecrease);
        LoadNextDialog();
        StopAllCoroutines();
        StartCoroutine(ShowEmotion(false));
    }
    public void RandomiseButtons()
    {
        buttonsParent.GetChild(Random.Range(0, buttonsParent.childCount)).SetAsFirstSibling();
    }
    public void EndDate()
    {
        anim.SetTrigger("DateDone");
    }
    public void OnEndDateAnimDone()
    {
        gm.LoadNextDate();
    }
    IEnumerator ShowEmotion(bool _happy)
    {
        dateIMG.sprite = _happy ? currDateData.happyIMG : currDateData.angryIMG;
        dateIMGAnim.SetTrigger(_happy ? "Happy" : "Angry");
        yield return new WaitForSeconds(2.5f);
        dateIMG.sprite = currDateData.neutralIMG;
    }
}
