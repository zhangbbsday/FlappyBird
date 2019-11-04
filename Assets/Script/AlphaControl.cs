using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaControl : MonoBehaviour
{
    public enum AlphaType 
    { 
        StartMenu = 0,
        EndMenu = 1,
        EffectDead = 2,
        EffectReGame = 3
    }

    public AlphaType alphaType;
    public float changeSpeed;
    public float changeSpeedEffect;

    private CanvasGroup canvasGroup;
    private bool canChange;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canChange = true;
    }

    void Update()
    {
        if (canChange)
            ChangeAlpha();
    }

    private void ChangeAlpha()
    {
        switch (alphaType)
        {
            case AlphaType.StartMenu:
                if (GameManager.Manager.IsStart)
                    StartMenuAlpha();
                break;
            case AlphaType.EndMenu:
                if (GameManager.Manager.IsOver)
                    EndMenuAlpha();
                break;
            case AlphaType.EffectDead:
                if (GameManager.Manager.IsOver)
                    EffectAlphaUp();
                break;
            case AlphaType.EffectReGame:
                EffectAlphaDown();
                break;
        }
    }

    public void StartChange()
    {
        canChange = true;
    }

    private void StartMenuAlpha()
    {
        if (canvasGroup.alpha <= 0)
        {
            canChange = false;
            gameObject.SetActive(false);
            return;
        }
        
        canvasGroup.alpha -= changeSpeed;
    }

    private void EndMenuAlpha()
    {
        if (canvasGroup.alpha >= 1)
        {
            canChange = false;
            return;
        }
        canvasGroup.alpha += changeSpeed;
    }

    private void EffectAlphaUp()
    {
        if (canvasGroup.alpha >= 1)
        {
            canChange = false;
            gameObject.SetActive(false);
            return;
        }

        canvasGroup.alpha += changeSpeedEffect;
    }

    private void EffectAlphaDown()
    {
        if (canvasGroup.alpha <= 0)
        {
            canChange = false;
            gameObject.SetActive(false);
            return;
        }

        canvasGroup.alpha -= changeSpeedEffect;
    }
}
