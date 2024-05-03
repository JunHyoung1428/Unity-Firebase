using Firebase.Extensions;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VerifyPanel : MonoBehaviour
{
    [SerializeField] PanelController panelController;

    [SerializeField] Button logoutButton;
    [SerializeField] Button sendButton;
    [SerializeField] TMP_Text sendButtonText;

    [SerializeField] int sendMailCooltime;

    private void Awake()
    {
        logoutButton.onClick.AddListener(Logout);
        sendButton.onClick.AddListener(SendVerifyMail);
    }

    private void OnEnable()
    {
        if ( FirebaseManager.Auth == null )
            return;

        verifyCheckRoutine = StartCoroutine(VerifyCheckRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    Coroutine verifyCheckRoutine;
    IEnumerator VerifyCheckRoutine()
    {
        while ( true )
        {
            yield return new WaitForSeconds(3f);

            //���� ������ ������ ���ε�, ���ϸ� ���� �ȵǾ�����
            FirebaseManager.Auth.CurrentUser.ReloadAsync().ContinueWithOnMainThread(task =>
            {
                if ( task.IsCanceled )
                {
                    panelController.ShowInfo("ReloadAsync Canceled");
                    return;
                }
                else if ( task.IsFaulted )
                {
                    panelController.ShowInfo($"ReloadAsync failed : {task.Exception.Message}");
                }

                // ���ε� ���������� �Ϸ�
                if ( FirebaseManager.Auth.CurrentUser.IsEmailVerified )
                {
                    panelController.SetActivePanel(PanelController.Panel.Main);
                }
            });
        }
    }

    private void Logout()
    {
        FirebaseManager.Auth.SignOut();
        panelController.SetActivePanel(PanelController.Panel.Login);
    }

    private void SendVerifyMail()
    {
        FirebaseManager.Auth.CurrentUser.SendEmailVerificationAsync().ContinueWithOnMainThread(task =>
        {
            if ( task.IsCanceled )
            {
                panelController.ShowInfo("SendEmailVerificationAsync canceled");
                return;
            }
            else if ( task.IsFaulted )
            {
                panelController.ShowInfo("SendEmailVerificationAsync faulted");
                return;
            }
        });
    }
}
