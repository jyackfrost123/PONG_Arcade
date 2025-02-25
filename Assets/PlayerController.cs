using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private SerialToController stc;
    [SerializeField] private UIController ui;
    public float speed;
    //public int testScore;

    public float maxPadY = 5.0f;
    public float minPadY = -3.0f;

    private parametorController para;
    private Vector3 firstPos; 

    void Start()
    {
        stc = GameObject.Find("SerialReceiver").GetComponent<SerialToController>();

        para = GameObject.Find("FadeManager").GetComponent<parametorController>();
        
        if(GameObject.Find("Canvas").GetComponent<UIController>() != null){
            ui = GameObject.Find("Canvas").GetComponent<UIController>();
        }

        firstPos = this.transform.position;
        Debug.Log(para.IsSmartPhone);
    }

    void Update()
    {
        if(para.IsSmartPhone){
            //Debug.Log("Check");
            
            //マウス座標の取得
            Vector3 mousePos = Input.mousePosition;
            //スクリーン座標をワールド座標に変換
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
            //ワールド座標を自身の座標に設定
            //this.transform.position = new Vector3(firstPos.x, worldPos.y, firstPos.z);

            //目標ポイントと比べて移動
            if(this.transform.position.y < worldPos.y){

                transform.Translate( Vector3.up * speed * 0.7f);//上に行く

            }else if(this.transform.position.y > worldPos.y){

                transform.Translate( Vector3.down * speed * 0.7f);//下に行く

            }

            //上下の移動制限処理
            if(transform.position.y > maxPadY){
                this.transform.position = new Vector3(this.transform.position.x, maxPadY, this.transform.position.z );
            }

            if(transform.position.y < minPadY){
                this.transform.position = new Vector3(this.transform.position.x, minPadY, this.transform.position.z );
            }
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)||stc.pressedD){
            
            /*if(ui != null){
                if(ui.isGameOver == false) transform.Translate( Vector3.up * speed);//上に行く
            }else{//ui == null つまり、練習モードの場合
                transform.Translate( Vector3.up * speed);//上に行く
            }*/

            transform.Translate( Vector3.up * speed);//上に行く
            
            if(transform.position.y > maxPadY){
                this.transform.position = new Vector3(this.transform.position.x, maxPadY, this.transform.position.z );
            }
        }
        
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || stc.pressedA){
            
            /*if(ui != null){
                if(ui.isGameOver == false)  transform.Translate( Vector3.down * speed);//下に行く
            }else{//ui == null つまり、練習モードの場合
                transform.Translate( Vector3.down * speed);//下に行く
            }*/
            
            transform.Translate( Vector3.down * speed);//下に行く
            

            if(transform.position.y < minPadY){
                this.transform.position = new Vector3(this.transform.position.x, minPadY, this.transform.position.z );
            }
        }

        //if(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyDown(KeyCode.Z) || stc.keyDownButton1) testScore++;
        //if(stc.keyUpButton1) testScore--;
    }
}
