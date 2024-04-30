using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    [SerializeField] TMP_InputField idInputField;
    [SerializeField] TMP_InputField pwInputField;

    [SerializeField] Button loginButton;
    [SerializeField] Button signUpButton;


    private void Awake()
    {
        loginButton.onClick.AddListener(Login);
        signUpButton.onClick.AddListener(SignUp);
    }

    private void Login()
    {
        string id = idInputField.text;
        string pass = pwInputField.text;

        FirebaseManager.Auth.SignInWithEmailAndPasswordAsync(id, pass).ContinueWithOnMainThread(task =>
        {
            if ( task.IsCanceled )
            {
                FirebaseManager.Instance.ShowInfo("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if ( task.IsFaulted )
            {
                FirebaseManager.Instance.ShowInfo($"SignInWithEmailAndPasswordAsync encountered an error: {task.Exception.Message}");
                return;
            }

            Firebase.Auth.AuthResult result = task.Result;
            Debug.Log($"User signed in successfully: {result.User.DisplayName} ({result.User.UserId})");
            //FirebaseManager.Instance.SetActivePanel(FirebaseManager.Panel.Main);
        });
    }

    private void SignUp()
    {

    }
}