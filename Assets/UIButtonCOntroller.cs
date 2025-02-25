using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonCOntroller : MonoBehaviour
{

    [SerializeField] public GameObject buttonSE;
    parametorController para;



    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("FadeManager") != null){
             para = GameObject.Find("FadeManager").GetComponent<parametorController>(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        
    /// <summary>
    /// ゲームスタート、リスタート(フェードあり)
    /// </summary>
    public void ReStart(){
        //FadeManager.Instance.LoadScene ("GameScene", 0.5f);
        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);

        if(para != null && para.NotFirst == false){
            FadeManager.Instance.LoadScene ("GameScene", 0.5f);
            para.NotFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameScene", 0.5f);
        } 

    }

    /// <summary>
    /// 即リスタート(フェードなし)
    /// </summary>
    public void BattleFastReStart(){
        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);
        SceneManager.LoadScene("BattleScene");
    }

    /// <summary>
    /// ゲームスタート、リスタート(フェードあり)
    /// </summary>
    public void BattleReStart(){

        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);

        if(para != null && para.NotFirst == false){
            FadeManager.Instance.LoadScene ("BattleScene", 0.5f);
            para.NotFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("BattleScene", 0.5f);
        } 

    }

    /// <summary>
    /// 即リスタート(フェードなし)
    /// </summary>
    public void FastReStart(){
         SceneManager.LoadScene("GameScene");
    }


    /// <summary>
    /// 即リスタート(フェードなし)
    /// </summary>
    public void diffFastReStart(){
        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);
        SceneManager.LoadScene("GameSceneDiff");
    }

    /// <summary>
    /// ゲームスタート、リスタート(フェードあり)
    /// </summary>
    public void diffReStart(){

        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);

        if(para != null && para.NotFirst == false){
            FadeManager.Instance.LoadScene ("GameSceneDiff", 0.5f);
            para.NotFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameSceneDiff", 0.5f);
        } 

    }

        /// <summary>
    /// 即リスタート(フェードなし)
    /// </summary>
    public void easyFastReStart(){
        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);
        SceneManager.LoadScene("GameSceneEasy");
    }

    /// <summary>
    /// ゲームスタート、リスタート(フェードあり)
    /// </summary>
    public void easyReStart(){

        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);

        if(para != null && para.NotFirst == false){
            FadeManager.Instance.LoadScene ("GameSceneEasy", 0.5f);
            para.NotFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameSceneEasy", 0.5f);
        } 

    }
    

    /// <summary>
    /// チュートリアル遷移
    /// </summary>
    public void goTutorial(){
        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);
        FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
        if(para != null)para.NotFirst = true;
    }

    /// <summary>
    /// タイトル遷移
    /// </summary>
    public void goTitle(){
        if (buttonSE != null) Instantiate(buttonSE, new Vector3(0, 0, 0), Quaternion.identity);
        FadeManager.Instance.LoadScene ("Title", 0.5f);
    }



}
