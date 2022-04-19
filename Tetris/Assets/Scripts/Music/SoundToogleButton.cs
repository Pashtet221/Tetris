using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToogleButton : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;

    public GameObject button;
    public Vector3 offButtonPosition;

    private Vector3 onButtonPosition;
    private Image image;



    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = onSprite;
        onButtonPosition = button.GetComponent<RectTransform>().anchoredPosition;
        ToogleButton();
    }

    public void ToogleButton()
    {
        var muted = false;

        muted = SoundManager.instance.IsBackgroundMusicMuted();


        if (muted)
        {
            image.sprite = offSprite;
            button.GetComponent<RectTransform>().anchoredPosition = offButtonPosition;
        }
        else
        {
            image.sprite = onSprite;
            button.GetComponent<RectTransform>().anchoredPosition = onButtonPosition;
        }
    }
}
