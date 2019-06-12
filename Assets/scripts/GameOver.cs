using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject scoreBoard;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI bestScore;
    public GameObject[] banners;
    [HideInInspector]
    public bool rewardVid;

    private int designInd;
    bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        //AdMobManager._AdMobInstance.loadRewardVideo();
        if (gameOver.activeSelf)
        gameOver.SetActive(false);

        Time.timeScale = 1f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        gameEnded = false;
    }

    public void EnableGameOverCanva()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            currentScore.text = playerStats.instance.colorScore.ToString();
            //scoreBoard.SetActive(false);
            bestScore.text = PlayerPrefs.GetInt("BestColorScore", 0).ToString();

            if (LevelDesigner.instance != null)
                designInd = LevelDesigner.ind;

            if (banners.Length!= 0)
                AssignBanner();
        }
        
            
       
    }

    public void Restart()
    {
        //gameOver.SetActive(false);
        
        
        gameManager.instance.FadeToLevel(SceneManager.GetActiveScene().buildIndex,designInd);
      

    }

    public void Home()
    {
       
        gameManager.instance.FadeToLevel(0);
    }

    public void ContinueWithAd()
    {
        rewardVid = true;
        AdMobManager._AdMobInstance.showRewardVideo();
        //rewardEvent();
    }

    public void rewardEvent()
    {

        gameManager.instance.RewardVidPlayed(playerStats.instance.colorScore);
        gameManager.instance.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
       
    }

    void AssignBanner()
    {
        int ind;
        
        ind=Random.Range(0, 5);
        //Debug.Log(ind);
        banners[ind].SetActive(true);

    }

    public void OpenAdGame(string url)
    {
        Application.OpenURL(url);
    }
}
