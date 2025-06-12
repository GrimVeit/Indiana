using System;

public class FirebaseAuthenticationInfoModel
{
    public event Action<string> OnSetMessage;

    private readonly IAuthenticationSignUpInfoProvider _signUpInfoProvider;

    public FirebaseAuthenticationInfoModel(IAuthenticationSignUpInfoProvider signUpInfoProvider)
    {
        _signUpInfoProvider = signUpInfoProvider;
    }

    public void Initialize()
    {
        _signUpInfoProvider.OnSignUpMessage_Action += SetMessage;
    }

    public void Dispose()
    {
        _signUpInfoProvider.OnSignUpMessage_Action -= SetMessage;
    }

    private void SetMessage(string messgae)
    {
        OnSetMessage?.Invoke(messgae);
    }
}
