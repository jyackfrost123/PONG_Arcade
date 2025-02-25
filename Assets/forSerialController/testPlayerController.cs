using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerController : MonoBehaviour
{
    //キー入力を受け取るSerialToControllerを追加
    [SerializeField] private SerialToController stc;

    public float speed;
    public int testScore;

    void Start()
    {
        //Sceneの中にあるSerialToControllerを探す
        stc = GameObject.Find("SerialReceiver").GetComponent<SerialToController>();
    }

    void Update()
    {
        //ボタン1キーの入力を検知したい場合は、stc.pressedButton1で利用できる(押されているか否かがboolで返ってくる)
        if(Input.GetKey(KeyCode.Z) || stc.pressedButton1){
            transform.Translate( Vector3.up * speed);
        }
        
        //ボタン1,2,3,4,と4方向(W,A,S,D)も同様で、それぞれstc.press?で入力の有無を返すBool   
        if(Input.GetKey(KeyCode.X) || stc.pressedButton2){
            transform.Translate( Vector3.down * speed);
        }

        //ボタン1,2,3,4はstc.keyDownButton?(押された瞬間)についても取得できる(返り値はbool)
        if(Input.GetKeyDown(KeyCode.Z) || stc.keyDownButton1){
            testScore++;
        }

        //同様にstc.keyUpButton?(離した瞬間)についても取得できる(返り値はbool)
        if(Input.GetKeyUp(KeyCode.Z) || stc.keyUpButton1){
            testScore--;
        }
    }
}
