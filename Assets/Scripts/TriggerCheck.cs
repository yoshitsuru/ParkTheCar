using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerCheck : MonoBehaviour
{
    private Collider _triggerCollider;

    public CameraChanger cameraChanger;

    public Vector3 initialPosition;

    public Quaternion initialRotation;

    public Vector3 parkingPosition;

    public Quaternion parkingRotation;
    
    public GameObject parkingCarPrefab;

    private bool _isParkingFlg;

    void Start()
    {
        // 駐車フラグをfalseに設定
        _isParkingFlg = false;
        // トリガーのコライダーを取得
        _triggerCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (_isParkingFlg)
        {
            // 駐車位置に車を配置
            GameObject instance = Instantiate(parkingCarPrefab, parkingPosition, Quaternion.identity);
            instance.transform.localRotation = parkingRotation;
            _isParkingFlg = false;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        // オブジェクトのバウンディングボックスがトリガー内に完全に収まっているか確認
        if (other.bounds.Contains(_triggerCollider.bounds.min) && other.bounds.Contains(_triggerCollider.bounds.max))
        {
            // 駐車したポイントを削除
            Destroy(other.gameObject);

            // 駐車位置を取得
            parkingPosition = other.transform.position;
            parkingPosition.y = other.transform.position.y - 0.9f;
            parkingRotation = other.transform.rotation;

            // 初期位置に戻る
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            cameraChanger.SetBackCamera();

            // 駐車フラグをつける
            _isParkingFlg = true;
        }
    }
}
