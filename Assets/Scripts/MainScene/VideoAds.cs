using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VideoAds : MonoBehaviour, IUnityAdsListener
{
    int counts;
    [SerializeField] private Button _adsButton;

    private string _gameId = "4455537"; //ваш game id

    private string _rewardedVideo = "Rewarded_Android";

    void Start()
    {
        _adsButton = GetComponent<Button>();
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);

        if (_adsButton)
            _adsButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, true);
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideo);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            _adsButton.interactable = true; //действия, если реклама доступна
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        //ошибка рекламы
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // только запустили рекламу
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) //обработка рекламы (тут определеяем вознаграждение)
    {
        if (counts > 0)
        {
            print("no");
        }
        else
        {
            int present = 50;
            int diamonds = PlayerPrefs.GetInt("Diamonds");
            int count = present + diamonds;
            if (showResult == ShowResult.Finished)
            {
                if (placementId == "Rewarded_Android")
                {
                    PlayerPrefs.SetInt("Diamonds", count);
                    counts++;
                }
                //действия, если пользователь посмотрел рекламу до конца
            }
            else if (showResult == ShowResult.Skipped)
            {
                print("skip");
            }
            else if (showResult == ShowResult.Failed)
            {
                print("Some problems");
            }
        }
    }
}
