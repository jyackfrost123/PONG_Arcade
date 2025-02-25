using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour
{
    public float addSpeed = 0.02f;
    public float moveX = 0.1f;
    public float moveY = 0.1f;

    private float baseMoveX = 0.1f;
    private float baseMoveY = 0.1f;


    private UIController ui;

    public GameObject reflectSE;
    public GameObject failSE;

    void Start(){
        if(GameObject.Find("Canvas").GetComponent<UIController>() != null){
            ui = GameObject.Find("Canvas").GetComponent<UIController>();
        }

        baseMoveX = moveX;
        baseMoveY = moveY;
    }

    void FixedUpdate()
    {
        if(ui != null){
            if(ui.isStart) transform.Translate(moveX, moveY, 0.0f);
        }else{//ui == nullの時
            transform.Translate(moveX, moveY, 0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //UnityEngine.Debug.Log("Hit");
        if (col.gameObject.tag == "Reflect"){//反射
            moveY = -moveY;

            //加速Y
            if(moveY > 0) moveY += addSpeed/ 2.0f;
            else moveY -= addSpeed/ 2.0f;
            
            if(ui != null){
                if(ui.isGameOver == false) Instantiate(reflectSE, Vector3.zero, Quaternion.identity);
            }else{
                Instantiate(reflectSE, Vector3.zero, Quaternion.identity);
            }

        }else if(col.gameObject.tag == "Player"){//プレイヤー反射
            moveX = -moveX;

            //加速X
            if(moveX > 0) moveX += addSpeed;
            else moveX -= addSpeed;
            
            if(ui != null){
                if(ui.isGameOver == false) Instantiate(reflectSE, Vector3.zero, Quaternion.identity);
            }else{
                Instantiate(reflectSE, Vector3.zero, Quaternion.identity);
            }

        }else if(col.gameObject.tag == "DeathZone1"){
            ReStart();
            if(ui != null)ui.Player2Score++;
        }else if(col.gameObject.tag == "DeathZone2"){
            ReStart();
            if(ui != null)ui.Player1Score++;
        }
    }

    void ReStart(){
        if(ui != null){
            if(ui.isGameOver == false) Instantiate(failSE, Vector3.zero, Quaternion.identity);
        }else{
            Instantiate(failSE, Vector3.zero, Quaternion.identity);
        }

        this.transform.position = new Vector3(0,Random.Range(-3.0f, 5.0f),transform.position.z);//適当な高さで再生成

        moveX = baseMoveX;
        moveY = baseMoveY;

        moveX = -moveX;//逆側へのサーブ

        //加速度を速める
        /*
        if(moveX > 0) moveX += addSpeed;
        else moveX -= addSpeed;

        if(moveY > 0) moveY += addSpeed;
        else moveY -= addSpeed;
        */

    }
    
}
