using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Toast : MonoBehaviour
{
    public static Toast instance;
    [SerializeField] private TextMeshProUGUI toastText;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(gameObject);
        StopToast();
    }
    public void StopToast()
    {
        gameObject.SetActive(false);
    }

    public void SetToast(string _text)
    {
        gameObject.SetActive(true);
        toastText.text = _text;
        animator.Play("ToastAnimation");
    }


}
