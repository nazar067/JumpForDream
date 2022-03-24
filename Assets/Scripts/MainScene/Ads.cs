using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    [SerializeField] private bool _testMode = false;
    private string _gameId = "4455537";

    private string _video = "Interstitial_Android";
    private string _rewardedVideo = "Rewarded_Android";
    private string _banner = "Banner_Android";
    void Start()
    {
        Advertisement.Initialize(_gameId);
        #region Banner
        StartCoroutine((string)ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        #endregion
    }
    public static void ShowAdsVideo()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Advertisment not ready");
        }
    }
    IEnumerable ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(_banner);
    }
}