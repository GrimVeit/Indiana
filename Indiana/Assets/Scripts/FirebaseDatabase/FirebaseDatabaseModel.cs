using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseDatabaseModel
{
    public event Action<UserData> OnGetUserFromPlace;
    public event Action OnErrorGetUserFromPlace;

    public event Action<string> OnGetNickname;
    public event Action<int> OnGetAvatar;

    public event Action<List<UserData>> OnGetUsersRecords;

    public event Action<List<string>> OnGetCountries;
    public event Action OnErrorGetCountries;

    public event Action<string> OnGetLink;
    public event Action OnErrorGetLink;

    public string Nickname { get; private set; }
    public int Record { get; private set; }

    private List<UserData> userRecordsDictionary = new List<UserData>();


    private FirebaseAuth auth;
    private DatabaseReference databaseReference;

    public FirebaseDatabaseModel(FirebaseAuth auth, DatabaseReference database)
    {
        this.auth = auth;
        this.databaseReference = database;
    }

    public void Initialize()
    {
        Record = PlayerPrefs.GetInt(PlayerPrefsKeys.RECORD, 0);

        Debug.Log(Record);
    }

    public void Dispose()
    {

    }

    public void CreateNewAccountInServer()
    {
        Nickname = auth.CurrentUser.Email.Split('@')[0];
        Record = 0;
        PlayerPrefs.SetInt(PlayerPrefsKeys.RECORD, 0);
        PlayerPrefs.SetString(PlayerPrefsKeys.NICKNAME, Nickname);
        UserData user = new(Nickname, 0);
        string json = JsonUtility.ToJson(user);

        OnGetNickname?.Invoke(Nickname);

        Debug.Log(Nickname);

        databaseReference.Child("Users").Child(auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
    }

    public void SetNickname(string nickname)
    {
        Nickname = nickname;
        OnGetNickname?.Invoke(Nickname);
    }

    public void SaveChangesToServer()
    {
        Nickname = auth.CurrentUser.Email.Split('@')[0];
        UserData user = new(Nickname, Record);
        string json = JsonUtility.ToJson(user);
        databaseReference.Child("Users").Child(auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
    }

    public void GetUserFromPlace(int number)
    {
        Coroutines.Start(GetUser(number));
    }

    #region Countries

    public void GetCountries()
    {
        Coroutines.Start(GetCountriesCoro());
    }

    private IEnumerator GetCountriesCoro()
    {
        var task = databaseReference.Child("Cs").GetValueAsync();

        float timeOut = 5f;
        float startTime = Time.time;

        yield return new WaitUntil(() => task.IsCompleted || (Time.time - startTime) > timeOut);

        if (task.IsFaulted || task.IsCanceled || !task.IsCompleted)
        {
            Debug.Log("Error display countries");
            OnErrorGetCountries?.Invoke();
            yield break;
        }

        DataSnapshot data = task.Result;

        List<string> countries = new();

        foreach (var user in data.Children)
        {
            string name = user.Child("cs").Value.ToString();
            countries.Add(name);
            Debug.Log($"{name}");
        }

        OnGetCountries?.Invoke(countries);
    }

    #endregion

    #region Link

    public void GetLink()
    {
        Coroutines.Start(GetLinkCoro());
    }

    private IEnumerator GetLinkCoro()
    {
        var task = databaseReference.Child("Link").GetValueAsync();

        float timeOut = 5f;
        float startTime = Time.time;

        yield return new WaitUntil(() => task.IsCompleted || (Time.time - startTime) > timeOut);

        if (task.IsFaulted || task.IsCanceled || !task.IsCompleted)
        {
            Debug.Log("Error display link");
            OnErrorGetLink?.Invoke();
            yield break;
        }

        DataSnapshot data = task.Result;

        List<string> links = new();

        foreach (var user in data.Children)
        {
            string name = user.Child("link").Value.ToString();
            links.Add(name);
            Debug.Log($"{name}");
        }

        if (links.Count == 0)
        {
            Debug.Log("NOT FOUND LINKS");
            OnErrorGetLink?.Invoke();
        }
        else
        {
            Debug.Log(links[0]);
            OnGetLink?.Invoke(links[0]);
        }
    }

    #endregion

    #region Records

    public void DisplayUsersRecords()
    {
        Coroutines.Start(GetUsersRecords());
    }

    private IEnumerator GetUsersRecords()
    {
        //var task = databaseReference.Child("Users").OrderByChild("Record").LimitToFirst(15).GetValueAsync();
        var task = databaseReference.Child("Users").OrderByChild("Record").LimitToLast(20).GetValueAsync();

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            Debug.Log("Error display record");
            yield break;
        }

        userRecordsDictionary.Clear();

        DataSnapshot data = task.Result;

        Debug.Log("Success " + data.ChildrenCount);

        foreach (var user in data.Children)
        {
            string name = user.Child("Nickname").Value.ToString();
            int record = int.Parse(user.Child("Record").Value.ToString());
            userRecordsDictionary.Add(new UserData(name, record));
        }

        userRecordsDictionary.Reverse();

        OnGetUsersRecords?.Invoke(userRecordsDictionary);
    }

    private IEnumerator GetUser(int number)
    {
        //var task = databaseReference.Child("Users").OrderByChild("Record").LimitToFirst(number).GetValueAsync();
        var task = databaseReference.Child("Users").OrderByChild("Record").LimitToLast(number).GetValueAsync();

        float timeOut = 5f;
        float startTime = Time.time;

        yield return new WaitUntil(() => task.IsCompleted || (Time.time - startTime) > timeOut);

        Debug.Log("END");

        if (task.IsFaulted || task.IsCanceled || !task.IsCompleted)
        {
            Debug.Log("Error display user");
            OnErrorGetUserFromPlace?.Invoke();
            yield break;
        }

        DataSnapshot data = task.Result;

        foreach (var user in data.Children)
        {
            string name = user.Child("Nickname").Value.ToString();
            int record = int.Parse(user.Child("Record").Value.ToString());
            OnGetUserFromPlace?.Invoke(new UserData(name, record));
        }

        //OnGetUserFromPlace?.Invoke(new UserData(
        //    data.Child("Nickname").Value.ToString(),
        //    data.Child("Record").Value.ToString(),
        //    data.Child("Avatar").Value.ToString()));
    }

    #endregion
}

public class UserData
{
    public string Nickname;
    public int Record;

    public UserData(string nickname, int record)
    {
        Nickname = nickname;
        Record = record;
    }
}
