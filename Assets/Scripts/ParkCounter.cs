using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ParkCounter : MonoBehaviour
{
    private TextMeshProUGUI _parkCountText;

    public UIController uiController;

    public int parkCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 駐車ポイントを数える
        //parkCount = GameObject.FindGameObjectsWithTag("ParkTarget").Length;
        // 駐車数
        _parkCountText = GetComponent<TextMeshProUGUI>();
        _parkCountText.text = "残り駐車数：" + parkCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // 駐車ポイントを数える
        parkCount = GameObject.FindGameObjectsWithTag("ParkTarget").Length;
        // 駐車数
        _parkCountText.text = "残り駐車数：" + parkCount.ToString();
        // 駐車がすべて完了した場合、ゲームクリア
        if (parkCount == 0)
        {
            // ゲームクリア
            uiController.ActiveGameClear();
        }
    }
}
