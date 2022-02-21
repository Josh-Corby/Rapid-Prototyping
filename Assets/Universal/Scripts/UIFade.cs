using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFade : GameBehaviour
{
    public CanvasGroup fadePanel;

    void Start()
    {
        fadePanel.alpha = 1;
        FadeOutCanvas(fadePanel);
    }

}
