using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioButton : MonoBehaviour
{
    private AudioScript audioScript;
    public Action OnClick;

    private void Start()
    {
         audioScript = Context.AudioScript();
    }

    public void Run()
    {

        InvokeSound();
        InvokeAction();
    }

    private void InvokeSound()
    {
        if (audioScript != null)
        {
            audioScript.PlayButtonClickSound();
        }        
    }

    public virtual void InvokeAction()
    {
        if (OnClick != null)
        {
            OnClick.Invoke();
        }
    }
}