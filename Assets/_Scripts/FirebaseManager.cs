using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase;
using Firebase.Auth;

public class FirebaseManager : MonoBehaviour
{
    private static FirebaseManager instance;
    public static FirebaseManager Instance {  get { return instance; } }

    private static FirebaseApp app;
    public static FirebaseApp App { get { return app; } }


   /******************************************************
   *                    Init Settings
   ******************************************************/

    private void Awake()
    {
        CreateInstance();
        CheckFirebaseAvailable();
    }

    private void CheckFirebaseAvailable()
    {
        //Ascync
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if ( dependencyStatus == Firebase.DependencyStatus.Available )
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;
                auth = FirebaseAuth.DefaultInstance;
                // Set a flag here to indicate whether Firebase is ready to use by your app.
                Debug.Log("FireBase Check Success");
            }
            else
            {
                // Firebase Unity SDK is not safe to use here.
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));

                app = null;
                auth = null;
            }
        });
    }

    void CreateInstance()
    {
        if(instance == null )
        {
            instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else
        {
            Destroy(gameObject);
        }
    }


    /******************************************************
    *                   Authetication
    ******************************************************/

    private static FirebaseAuth auth;
    public static FirebaseAuth Auth { get { return auth; } } 
    //실시간 데이터

    //저장소

    //앱체크



    public void ShowInfo(string str )
    {
        Debug.Log(str);
    }
}
