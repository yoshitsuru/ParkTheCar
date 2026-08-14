using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour
{
    // 一人称視点の参照
    [SerializeField]
    private GameObject _frontCamera;

    // 三人称視点の参照
    [SerializeField]
    private GameObject _backCamera;

    private bool isFront;

    public TriggerCheck triggerCheck;

    public GameObject playerCar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // カメラの初期状態は背面モード
        _frontCamera.SetActive(false);
        _backCamera.SetActive(true);
        isFront = false;
    }

    // Update is called once per frame
    void Update()
    {
        //「E」キーが押下されると、カメラが切り替わる
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCamera();
        }
        //「R」キーが押下されると、初期位置に戻る
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 初期位置に戻る(カメラの向きも背面モードに戻す)
            playerCar.transform.position = triggerCheck.initialPosition;
            playerCar.transform.rotation = triggerCheck.initialRotation;
            SetBackCamera();
        }
    }

    /// <summary>
    /// 視点の切り替えを実行する
    /// </summary>
    [ContextMenu("SwitchCamera")]
    public void SwitchCamera()
    {
        if (isFront)
        {
            // 前面である場合、背面モードに切り替え
            SetBackCamera();
        }
        else
        {
            // 背面である場合、前面モードに切り替え
            SetFrontCamera();
        }
    }

    /// <summary>
    /// 前面視点に切り替える
    /// </summary>
    public void SetFrontCamera()
    {
        // 表示カメラを前面に切り替え
        _frontCamera.SetActive(true);
        _backCamera.SetActive(false);
        isFront = true;
    }

    /// <summary>
    /// 背面視点に切り替える
    /// </summary>
    public void SetBackCamera()
    {
        // 表示カメラを背面に切り替え
        _frontCamera.SetActive(false);
        _backCamera.SetActive(true);
        isFront = false;
    }
}
