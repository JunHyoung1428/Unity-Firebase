using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirebaseManager.DB
            .GetReference("UserData").Child("PJH")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if(task.IsFaulted)
                {
                    return;
                }
                if(task.IsCanceled)
                {

                    return;
                }

                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    string json = snapshot.GetRawJsonValue();
                    Debug.Log(json);
                    UserData userData= JsonUtility.FromJson<UserData>(json);

                    Debug.Log(userData.nickName);
                    Debug.Log(userData.level);
                    Debug.Log(userData.type);
                    return;
                }
                else
                {
                    UserData userData = new UserData();
                }
            });
          
    }

    
}
