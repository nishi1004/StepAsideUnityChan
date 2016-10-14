using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private int startPos = -160;
    private int goalPos=120;
    private int range = 50;//アイテムを生成する距離
    private float posRange = 3.4f;
    private float distance = 0; //距離カウント用
    private float prev;

    // Use this for initialization
    void Start() {
        for (int i = startPos; i <= startPos + range; i += 15)
        {
            ItemGenerate(i);
        }
        prev = transform.position.z;
    }


    // Update is called once per frame
    void Update()
    {

        distance += transform.position.z - prev;
        if (transform.position.z < goalPos - range)
        {
            //ユニティちゃんが一定距離進むごとにアイテムを生成
            if (distance > 15)
            {
                ItemGenerate(transform.position.z + range);
                distance = 0;
            }
        }
        prev = transform.position.z;
    }

    void ItemGenerate(float zPos)
    {
        int num = Random.Range(0, 10);
        if (num <= 1)
        {
            for (float j = -1f; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab) as GameObject;
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, zPos);
            }
        }
        else
        {
            for (int j = -1; j < 2; j++)
            {
                int item = Random.Range(1, 11);
                int offsetZ = Random.Range(-5, 6);
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, zPos+ offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab) as GameObject;
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, zPos + offsetZ);

                }
            }
        }
    }


}
