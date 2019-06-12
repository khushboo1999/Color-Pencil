using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdMobManager : MonoBehaviour
{
    public static AdMobManager _AdMobInstance;
    public string bannerAdId, interstitialAdId, rewardVideoAdId;
    public bool isDebug;
    public bool isOnTop;
    private static RewardBasedVideoAd rewardBasedVideo;
    private static BannerView bannerView;
    private static InterstitialAd interstitial;
    private GameOver gameOver;
    // Use this for initialization

    void Awake()
    {
        if (_AdMobInstance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            _AdMobInstance = this;
        }
    }


    void Start()
    {
        loadRewardVideo();
        showBannerAd();
        loadInterstitial();
    }

    // Update is called once per frame

    void OnGUI()
    {
        if (isDebug)
        {
            if (GUI.Button(new Rect(20, 0, 100, 60), "Load Full"))
            {
                loadInterstitial();
            }
            if (GUI.Button(new Rect(20, 80, 100, 60), "Load Video"))
            {
                loadRewardVideo();
            }
            if (GUI.Button(new Rect(20, 160, 100, 60), "Show Banner"))
            {
                showBannerAd();
            }
            if (GUI.Button(new Rect(200, 0, 100, 60), "Show Full"))
            {
                showInterstitial();
            }
            if (GUI.Button(new Rect(200, 80, 100, 60), "Show Video"))
            {
                showRewardVideo();
            }
            if (GUI.Button(new Rect(200, 160, 100, 60), "Hide Banner"))
            {
                hideBannerAd();
            }


        }
    }

    void onInterstitialEvent(object sender, System.EventArgs args)
    {
        print("OnAdLoaded event received.");
        // Handle the ad loaded event.
        
    }

    void onBannerEvent(string eventName, string msg)
    {

    }

    void onRewardedVideoEvent(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;

        if (gameOver == null)
            gameOver = FindObjectOfType<GameOver>();

        if (gameOver != null)
        {
            gameOver.rewardEvent();
            Debug.Log("loading..");
        }
        print("User rewarded with: " + amount.ToString() + " " + type);
    }


    public void showBannerAd()
    {
        if (isOnTop)
        {
            bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Top);
            AdRequest request = new AdRequest.Builder().Build();
            // Load the banner with the request.
            bannerView.LoadAd(request);
        }
        else
        {
            bannerView = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Bottom);
            AdRequest request = new AdRequest.Builder().Build();
            // Load the banner with the request.
            bannerView.LoadAd(request);
        }
        // Create an empty ad request.

    }


    public void loadInterstitial()
    {
        interstitial = new InterstitialAd(interstitialAdId);
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void showInterstitial()
    {

        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            interstitial.OnAdOpening += onInterstitialEvent;
        }
        else
        {
            loadInterstitial();
            
        }
    }

    public void loadRewardVideo()
    {
        rewardBasedVideo = RewardBasedVideoAd.Instance;
       
        AdRequest request = new AdRequest.Builder().Build();
        rewardBasedVideo.LoadAd(request, rewardVideoAdId);
    }

    public void showRewardVideo()
    {
        
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            
            rewardBasedVideo.OnAdRewarded += onRewardedVideoEvent;
        }
        else
        {
            
            loadRewardVideo();
        }
    }

    public void hideBannerAd()
    {
        bannerView.Hide();
    }


}
