using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NicknameRandomView : View
{
    [SerializeField] private TextMeshProUGUI textNick;

    public void SetNickname(string nickname)
    {
        if(textNick != null)
           textNick.text = nickname.ToUpper();
    }
}
