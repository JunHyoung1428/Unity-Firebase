using Firebase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignUpPanel : MonoBehaviour
{
    [SerializeField] PanelController panelController;

    [SerializeField] TMP_InputField emailInputField;
    [SerializeField] TMP_InputField passInputField;
    [SerializeField] TMP_InputField confirmInputField;

    [SerializeField] Button cancelButton;
    [SerializeField] Button signUpButton;

    private void Awake()
    {
        cancelButton.onClick.AddListener(Cancel);
        signUpButton.onClick.AddListener(SignUp);
    }

    public void SignUp()
    {
        
    }

    public void Cancel()
    {
        
    }

    private void SetInteractable(bool interactable)
    {
        emailInputField.interactable = interactable;
        passInputField.interactable = interactable;
        confirmInputField.interactable = interactable;
        cancelButton.interactable = interactable;
        signUpButton.interactable = interactable;
    }
}
