using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image image;

    void Start()
    {
        image.canvasRenderer.SetAlpha(1.0f); 
        FadeIn_();
    }

    
    void FadeIn_()
    {
        image.CrossFadeAlpha(0, 2, false);
    }
}
