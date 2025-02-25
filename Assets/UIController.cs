using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UIController : MonoBehaviour
{
    [SerializeField] private Text player1ScoreText;
    [SerializeField] private Text player2ScoreText;

    [SerializeField] private GameObject winnerObject;
    [SerializeField] private Text winnerText;

    [SerializeField] private int _player1Score;
    [SerializeField] private int _player2Score;
    
    public GameObject finishSE;

    public int Player1Score{ 
        get{return this._player1Score;}
        set{
            if(!isGameOver) this._player1Score = value;
        }
    }
    
    public int Player2Score{ 
        get{return this._player2Score;}
        set{
            if(!isGameOver) this._player2Score = value;
        }
    }

    public bool isGameOver = false;
    public bool isStart = false;

    [SerializeField] private Text startText;
    [SerializeField] private GameObject lines;
    
    void Start()
    {
        Player1Score = 0;
        Player2Score = 0;
        winnerObject.SetActive(false);

        StartCoroutine("GameStartCountdown");
    }

    void FixedUpdate()
    {
        player1ScoreText.text = Player1Score.ToString();
        player2ScoreText.text = Player2Score.ToString();

        if(Player1Score >= 3 || Player2Score >= 3){
            winnerObject.SetActive(true);

            if(Player1Score >= 3){
                winnerText.text = "PLAYER1 WIN!!";
                winnerText.color = new Color(246.0f/255.0f, 42.0f/255.0f, 46.0f/255.0f);
            }else {
                if(SceneManager.GetActiveScene().name == "BattleScene") {
                    winnerText.text = "PLAYER2 WIN!!";
                    winnerText.color = new Color(46.0f/255.0f, 146.0f/255.0f, 255.0f/255.0f);
                    }
                else {
                    winnerText.text = "Enemy WIN!!";
                    winnerText.color = new Color(168.0f/255.0f, 48.0f/255.0f, 255.0f/255.0f);
                }
            }

            if(!isGameOver){
                isGameOver = true;
                lines.SetActive(false);
                Instantiate(finishSE, Vector3.zero, Quaternion.identity);
            }

        }else{
            if(Player1Score >= 2) player1ScoreText.color = Color.yellow;
            else if(Player2Score >= 2) player2ScoreText.color = Color.yellow;
        }
    }

    IEnumerator GameStartCountdown()  {

        float localTime = 4.0f;
        while(localTime > 1.0f){
            localTime -=1.0f;
            startText.text = ((int)localTime).ToString();
            yield return new WaitForSeconds (1.0f); 
        }

        startText.text = ""; 
        isStart = true;
        yield return new WaitForSeconds (1.0f);
        startText.text = ""; 

        yield return null;  
    }


}
