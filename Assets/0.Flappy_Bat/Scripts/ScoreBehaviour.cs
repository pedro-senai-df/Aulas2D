using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreBehaviour : MonoBehaviour
{
    public int currentScore = 0;
    public TMP_Text scoreTxt;

    [Space]

    public GameObject finalScreen;
    public TMP_Text finalTxt;

    public static ScoreBehaviour Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        finalScreen.SetActive(false);
        scoreTxt.gameObject.SetActive(true);

        UpdateUI();
        BatBehaviour.Instance.onDeath += ShowFinalScreen;
    }



    public void AddScore()
    {
        currentScore++;
        UpdateUI();
    }


    private void UpdateUI()
    {
        scoreTxt.text = currentScore.ToString();
    }

    private void ShowFinalScreen()
    {
        int maxScore = Mathf.Max(PlayerPrefs.GetInt("score", 0), currentScore);
        PlayerPrefs.SetInt("score", maxScore);

        scoreTxt.gameObject.SetActive(false);
        finalTxt.text = string.Format(finalTxt.text, currentScore.ToString(), maxScore.ToString());
        finalScreen.SetActive(true);
    }



    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
