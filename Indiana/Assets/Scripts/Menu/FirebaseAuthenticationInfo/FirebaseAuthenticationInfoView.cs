using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirebaseAuthenticationInfoView : View
{
    [SerializeField] private TextMeshProUGUI textInfo;

    public void SetMessgae(string message)
    {
        textInfo.text = message;
    }
}
