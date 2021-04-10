using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    //UnityちゃんとDeleteCubeとの距離
    private float difference;

    //DeleteCubeを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;

    //前方向の速度
    private float velocityZ = 16f;

    // Start is called before the first frame update
    void Start()
    {
          //Unityちゃんのオブジェクトを取得
          this.unitychan = GameObject.Find ("unitychan");

          //UnityちゃんとDeleteCubeの位置(z座標)の差を求める
          this.difference = unitychan.transform.position.z - this.transform.position.z;

          //Rigidbodyコンポーネントを取得
          this.myRigidbody = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
          //DeleteCubeに速度を与える
          this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);

          //Unityちゃんの位置に合わせてDeleteCubeの位置を移動
          this.transform.position = new Vector3 (0, this.transform.position.y, this.unitychan.transform.position.z-difference);   
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {
          //オブジェクトに衝突した場合
          if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
          {
                //接触したオブジェクトを破棄
                Destroy (other.gameObject);
          }
    }
}
