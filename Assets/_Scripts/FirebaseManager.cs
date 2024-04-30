using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;

public class FirebaseManager : MonoBehaviour
{
    private static FirebaseManager instance;
    private static FirebaseManager Instance {  get { return instance; } }


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
                // app = Firebase.FirebaseApp.DefaultInstance;

                Debug.Log("FireBase Check Success");
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
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

}
