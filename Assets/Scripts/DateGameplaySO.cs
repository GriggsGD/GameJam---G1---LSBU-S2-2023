using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DateGameplay", menuName = "New Date Gameplay")]
public class DateGameplaySO : ScriptableObject
{
    public string dateName;
    public string age;
    public Sprite neutralIMG, happyIMG, angryIMG;
    [TextArea] public string bio;
    [TextArea] public string occupation;
    [TextArea] public string likes;
    [TextArea] public string dislikes;
    [TextArea] public string notes;

    public DialogWave[] dialogs;
}
[System.Serializable]
public class DialogWave
{
    [TextArea] public string dialog;
    public bool responsable = true;
    public string gResponse;
    public string nResponse;
    public string bResponse;
}
