using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDiamond : MonoBehaviour
{
    public GameObject shopBG, detectClicks, settings, sound, info,
        shop, shopButton;

    void OnEnable()
    {
        shopBG.SetActive(!shopBG.activeSelf);
        detectClicks.SetActive(false);
        settings.SetActive(false);
        sound.SetActive(false);
        info.SetActive(false);
        shop.SetActive(false);
        shopButton.SetActive(false);
    }
    void OnDisable()
    {
        shopBG.SetActive(true);
    }
}
