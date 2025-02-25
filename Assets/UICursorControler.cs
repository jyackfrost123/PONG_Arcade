using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursorControler : MonoBehaviour
{
    [SerializeField] private SerialToController stc;
    [SerializeField] RectTransform rect;
    [SerializeField] private int cursorNum = 0;

    public GameObject[] uiButtonObjects;
    private Button[] uiButtons;
    private RectTransform[] buttonsRect;

    public GameObject choiceSE;

    private parametorController para;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        Debug.Log(uiButtonObjects.Length);

        uiButtons = new Button[uiButtonObjects.Length];
        buttonsRect = new RectTransform[uiButtonObjects.Length];

        for(int i = 0; i < uiButtonObjects.Length; i++){
            Debug.Log(i);
            uiButtons[i] = uiButtonObjects[i].GetComponent<Button>();
            buttonsRect[i] = uiButtonObjects[i].GetComponent<RectTransform>();
        }
        
        stc = GameObject.Find("SerialReceiver").GetComponent<SerialToController>();

        para = GameObject.Find("FadeManager").GetComponent<parametorController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //カーソル位置の制御
        rect.localPosition = buttonsRect[cursorNum].localPosition;

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)||stc.keyDownButton1 || stc.pressedD){//うえボタン
            cursorNum--;
            Instantiate(choiceSE, new Vector3(0,0,0), Quaternion.identity);
            if(cursorNum < 0) cursorNum = uiButtons.Length - 1;
        }else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || stc.keyDownButton3 || stc.pressedA){//したボタン
            cursorNum++;
            Instantiate(choiceSE, new Vector3(0,0,0), Quaternion.identity);
            if(cursorNum >  uiButtons.Length - 1) cursorNum = 0;
        }else if(Input.GetKeyDown(KeyCode.X) || stc.keyDownButton2){//決定ボタン
            uiButtons[cursorNum].onClick.Invoke();
        }
    }
}
