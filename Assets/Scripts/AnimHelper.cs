using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHelper : MonoBehaviour
{
    public void DateLoadAnimDone()
    {
        FindObjectOfType<DateCtrl>().OnLoadDateAnimDone();
    }
    public void DateEndAnimDone()
    {
        FindObjectOfType<DateCtrl>().OnEndDateAnimDone();
    }
}
