using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    [SerializeField] private SerialToController stc;
    [SerializeField] private UIController ui;
    public float speed;
    //public int testScore;

    public float maxPadY = 5.0f;
    public float minPadY = -3.0f;

    void Start()
    {
        stc = GameObject.Find("SerialReceiver").GetComponent<SerialToController>();
        
        if(GameObject.Find("Canvas").GetComponent<UIController>() != null){
            ui = GameObject.Find("Canvas").GetComponent<UIController>();
        }
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.U) || stc.pressedButton1){
            
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
        
        if(Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.J) || stc.pressedButton3){
            
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
