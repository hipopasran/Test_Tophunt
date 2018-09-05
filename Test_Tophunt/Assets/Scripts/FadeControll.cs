using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControll : MonoBehaviour {

    public Image fadeImage;
    Color c;

	void OnEnable()
    {
        EventManager.Hited += HitManager;
    }

    void OnDisable()
    {
        EventManager.Hited -= HitManager;
    }

    void Start()
    {
        fadeImage = GetComponent<Image>();
        fadeImage.canvasRenderer.SetAlpha(0.0f);
    }

    void HitManager()
    {
        fadeImage.canvasRenderer.SetAlpha(1f);
        fadeImage.CrossFadeAlpha(0,1.5f,true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
    }
}
