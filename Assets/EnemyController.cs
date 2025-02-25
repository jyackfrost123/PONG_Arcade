using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private GameObject cube;
    [SerializeField]private float speed=0.1f;
    [SerializeField]private float speedRate=1.5f;

    [SerializeField]private float lossTime = 1.0f;

    private UIController ui;
    private float ballY = 0.0f;

    int countCycle = 0;
    float reSpeed = 0.0f;

    private Vector3 baseScale;
    private int oldScore = 0;

    
    public float maxPadY = 5.0f;
    public float minPadY = -3.0f;

    public bool isEasy = false;


    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        reSpeed = UnityEngine.Random.Range(0, speedRate) * speed;
        baseScale = this.transform.localScale;
    }

    void FixedUpdate()
    {
        countCycle++;
        if(countCycle > 180 ){//180フレームごとに再抽選して動かす？
            countCycle = 0;

            if( UnityEngine.Random.Range(0, 2) == 1) {
                StartCoroutine("DelayCoroutine");
            }else reSpeed = UnityEngine.Random.Range(1.0f, speedRate) * speed;
        }

        if(ui.isGameOver == false && ui.isStart == true){
            ballY = cube.transform.position.y;

            if(!isEasy){
                if(this.transform.position.y >= ballY) transform.Translate(0, -reSpeed, 0);
                else transform.Translate(0, reSpeed, 0);
            }else{
                if(this.transform.position.y >= ballY + (cube.transform.localScale.y / 2.0f) * UnityEngine.Random.Range(-1, 1)) transform.Translate(0, -reSpeed, 0);
                else transform.Translate(0, reSpeed, 0);
            }
            /*if(this.transform.position.y >= ballY) transform.Translate(0, -reSpeed, 0);
            else transform.Translate(0, reSpeed, 0);*/

            /*if(transform.position.y < minPadY){
                this.transform.position = new Vector3(this.transform.position.x, minPadY, this.transform.position.z );
            }

            if(transform.position.y > maxPadY){
                this.transform.position = new Vector3(this.transform.position.x, maxPadY, this.transform.position.z );
            }*/

            /*if(oldScore != ui.Player2Score){
                //this.transform.localScale = new Vector3(baseScale.x, baseScale.y - (0.04f * ui.Player2Score), baseScale.z);
                oldScore = ui.Player2Score;
            }*/
        }
    }

    // 一定時間後に処理を呼び出すコルーチン
    private IEnumerator DelayCoroutine()
    {
        reSpeed = 0;
        float seconds = UnityEngine.Random.Range(0, lossTime);
        yield return new WaitForSeconds(seconds);
        reSpeed = UnityEngine.Random.Range(1.0f, speedRate) * speed;
        yield return null;
    }
}
