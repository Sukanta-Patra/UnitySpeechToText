using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TextSpeech;
using UnityEngine.Android;

public class SpeechToTextHandler : MonoBehaviour
{
    //button enable disable not working
    [SerializeField] private TMP_InputField displayText;
    [SerializeField] private GameObject dynamicButtonsPanel;
    private readonly string langCode = "en-US";

    void Start()
    {
        displayText.text = "";
        SetupSpeechEngine(langCode);
        SetButtonVisibility(false);
    }

    private void SetupSpeechEngine(string _langCode)
    {
        SpeechToText.Instance.Setting(_langCode);
        SpeechToText.Instance.onPartialResultsCallback = OnPartialSpeech;
        SpeechToText.Instance.onResultCallback = OnSpeechCompletion;
    }

    private void CheckAndRequestPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            Permission.RequestUserPermission(Permission.Microphone);
    }

    public void SetButtonVisibility(bool _visibility)
    {
        Debug.Log("TEST2: Button Visible: " + _visibility);
        dynamicButtonsPanel.SetActive(_visibility);
    }

    public void StartListening()
    {
        Debug.Log("TEST3: StartListening()");
        Toast.instance.SetToast("Listening...");
        SpeechToText.Instance.StartRecording();
    }
    //
    public void StopListening()
    {
        Debug.Log("TEST3: StopListening()");
        SpeechToText.Instance.StopRecording();
#if UNITY_EDITOR
        displayText.text = "Some recorded text will be shown here in Build!";
#endif
    }

    /// <summary>
    /// OnSpeechCompletion() is called after the entire speech is recorded
    /// </summary>
    /// <param name="_text"></param>
    private void OnSpeechCompletion(string _text)
    {
        displayText.text = _text;
    }

    /// <summary>
    /// OnPartialSpeech() is called during the speech recognition process
    /// </summary>
    /// <param name="_text"></param>
    private void OnPartialSpeech(string _text)
    {
        displayText.text = _text;
    }

    public void Redo()
    {
        displayText.text = "";
    }

    public void Submit()
    {
        //TODO: Submit Code
        displayText.text = "";
        Toast.instance.SetToast("Done!");
        Debug.Log("TEST1: Submit");
    }

    


}
