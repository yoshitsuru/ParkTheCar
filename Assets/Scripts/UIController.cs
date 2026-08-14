using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    /// 現在アクティブなシーン
    private string _sceneName;

    // リザルト画面
    public GameObject resultCanvas;

    // リザルトテキスト
    public TextMeshProUGUI resultText;

    // チュートリアルパネル1
    public GameObject tutorealPanel1;

    // チュートリアルパネル2
    public GameObject tutorealPanel2;

    void Start(){
        /// アクティブシーンを取得
        _sceneName = SceneManager.GetActiveScene ().name;
        Time.timeScale = 1.0f;
    }

    public void OnClickRetryButton(){
	    SceneManager.LoadScene (_sceneName);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickStartTutorealButton()
    {
        SceneManager.LoadScene("TutorealScene");
    }

    public void OnClickNextTutorealButton()
    {
        tutorealPanel1.SetActive(false);
        tutorealPanel2.SetActive(true);
    }

    public void OnClickBackTutorealButton()
    {
        tutorealPanel1.SetActive(true);
        tutorealPanel2.SetActive(false);
    }

    public void OnClickEndButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ActiveGameOver()
    {
        resultCanvas.SetActive(true);
        resultText.text = "GAME OVER!";
        Time.timeScale = 0.0f;
    }
    public void ActiveGameClear()
    {
        resultCanvas.SetActive(true);
        resultText.text = "GAME CLEAR!";
        Time.timeScale = 0.0f;
    }
}
