using UnityEngine;

public class CarGenerate : MonoBehaviour
{
    // 生成するオブジェクト(車)
    public GameObject carPrefab;

    // 生成するオブジェクト(駐車ポイント)
    public GameObject parkTargetPrefab;

    // 生成する車の個数
    public int carNumber;

    // 階番号
    public int floorNumber;

    // X軸位置
    public float xPosition;

    // Y軸位置
    public float yPosition;

    // Z軸位置
    public float zPosition;

    // 生成間隔
    public float space;

    // x軸間隔フラグ
    public bool xSpaceFlg;

    // z軸間隔フラグ
    public bool zSpaceFlg;

    // y軸ローテーション
    public float yRotation;

    // 生成しない番号
    public int notNumber;


    private void Start()
    {
        notNumber = Random.Range(0, carNumber);

        // 反復（繰り返し文）
        for (int i = 0; i < carNumber; i++)
        {
            // アタッチされている本体のゲームオブジェクトを取得
            GameObject carGenerate = GetComponent<GameObject>();

            // カーオブジェクトを生成しない番号
            if (i == notNumber - 1)
            {
                // x軸間隔ごとにオブジェクト生成
                if (xSpaceFlg)
                {
                    float yCarPosition =  yPosition;

                    // 階によって、駐車ポイントの位置を調整
                    if (floorNumber == 1)
                    {
                        yPosition = 1f;
                    }
                    else if(floorNumber == 2)
                    {
                        yPosition = 4.3f;
                    }
                    else if(floorNumber == 3)
                    {
                        yPosition = 7.8f;
                    }
                    xSpaceGenerate(i, parkTargetPrefab);
                    yPosition = yCarPosition;
                }

                // y軸間隔ごとにオブジェクト生成
                if (zSpaceFlg)
                {
                    float yCarPosition = yPosition;
                    // 階によって、駐車ポイントの位置を調整
                    if (floorNumber == 1)
                    {
                        yPosition = 1f;
                    }
                    else if (floorNumber == 2)
                    {
                        yPosition = 4.5f;
                    }
                    else if (floorNumber == 3)
                    {
                        yPosition = 7.8f;
                    }
                    zSpaceGenerate(i, parkTargetPrefab);
                    yPosition = yCarPosition;
                }
            }else
            {
                // x軸間隔ごとにオブジェクト生成
                if (xSpaceFlg)
                {
                    xSpaceGenerate(i, carPrefab);
                }

                // y軸間隔ごとにオブジェクト生成
                if (zSpaceFlg)
                {
                    zSpaceGenerate(i, carPrefab);
                }
            }
        }
    }

    void xSpaceGenerate(int i,GameObject generatePrefab)
    {
        GameObject instance = Instantiate(generatePrefab, new Vector3(i * space + xPosition, yPosition, zPosition), Quaternion.identity);
        instance.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

    void zSpaceGenerate(int i, GameObject generatePrefab)
    {
        GameObject instance = Instantiate(generatePrefab, new Vector3(xPosition, yPosition, i * space + zPosition), Quaternion.identity);
        instance.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}