using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBG : MonoBehaviour
{
    public GameObject detectClicks, settings, sound, info, 
        shop, allCubes, whichCube, fullShop, background, diamonds;
    void OnEnable()
    {
        detectClicks.SetActive(false);
        settings.SetActive(false);
        sound.SetActive(false);
        info.SetActive(false);
        shop.SetActive(false);
        diamonds.SetActive(true);
        whichCube.SetActive(!whichCube.activeSelf);
        fullShop.SetActive(!fullShop.activeSelf);
        allCubes.SetActive(true);
        background.GetComponent<Animation>().Play("Background");
        Ads.ShowAdsVideo();
    }
    void OnDisable()
    {
        detectClicks.SetActive(true);
        settings.SetActive(true);
        sound.SetActive(true);
        info.SetActive(true);
        shop.SetActive(true);
        diamonds.SetActive(false);
        whichCube.SetActive(true);
        fullShop.SetActive(true);
        allCubes.SetActive(false);
    }

}
