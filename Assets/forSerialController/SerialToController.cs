using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialToController : MonoBehaviour
{
        public bool pressedButton1 = false;
        public bool pressedButton2 = false;
        public bool pressedButton3 = false;
        public bool pressedButton4 = false;
        public bool pressedW = false;
        public bool pressedA = false;
        public bool pressedS = false;
        public bool pressedD = false;

        public bool keyDownButton1 = false;
        public bool keyDownButton2 = false;
        public bool keyDownButton3 = false;
        public bool keyDownButton4 = false;
        public bool keyUpButton1 = false;
        public bool keyUpButton2 = false;
        public bool keyUpButton3 = false;
        public bool keyUpButton4 = false;

        public bool keyDownButtonW = false;
        public bool keyDownButtonA = false;
        public bool keyDownButtonS = false;
        public bool keyDownButtonD = false;
        public bool keyUpButtonW = false;
        public bool keyUpButtonA = false;
        public bool keyUpButtonS = false;
        public bool keyUpButtonD = false;


        [SerializeField] private SerialReceive serialrci;
        [SerializeField] private string getSerialMessage;
        
        void Awake(){
            DontDestroyOnLoad(gameObject);
            serialrci = GetComponent<SerialReceive>();
        }
        
        void Start()
        {
            //serialrci = GetComponent<SerialReceive>();
        }

        void Update()
        {
            getSerialMessage = serialrci.serialInformation;

            if(getSerialMessage != null){
                string[] mesg= getSerialMessage.Split(',');
            
                for (int i = 0; i < mesg.Length; i++)
                {
                    switch(i){
                        default://Button1
                            if(mesg[i] == "0"){
                                if(!pressedButton1){//Onへの切り替わり直後
                                    pressedButton1 = true;
                                    keyDownButton1 = true;
                                }else if(keyDownButton1){//押され続けてる場合
                                    keyDownButton1 = false;
                                }
                            }else{
                                if(pressedButton1){//Offへの切り替わり直後
                                    pressedButton1 = false;
                                    keyUpButton1 = true;
                                }else if(keyUpButton1){//押され続けていない
                                    keyUpButton1 = false;
                                }
                            }
                            break;
                        case 1://Button2
                            if(mesg[i] == "0"){
                                if(!pressedButton2){//Onへの切り替わり直後
                                    pressedButton2 = true;
                                    keyDownButton2 = true;
                                }else if(keyDownButton2){//押され続けてる場合
                                    keyDownButton2 = false;
                                }
                            }else{
                                if(pressedButton2){//Offへの切り替わり直後
                                    pressedButton2 = false;
                                    keyUpButton2 = true;
                                }else if(keyUpButton2){//押され続けていない
                                    keyUpButton2 = false;
                                }
                            }
                            break;
                        case 2://Button3
                            if(mesg[i] == "0"){
                                if(!pressedButton3){//Onへの切り替わり直後
                                    pressedButton3 = true;
                                    keyDownButton3 = true;
                                }else if(keyDownButton3){//押され続けてる場合
                                    keyDownButton3 = false;
                                }
                            }else{
                                if(pressedButton3){//Offへの切り替わり直後
                                    pressedButton3 = false;
                                    keyUpButton3 = true;
                                }else if(keyUpButton3){//押され続けていない
                                    keyUpButton3 = false;
                                }
                            }
                            break;
                        case 3://Button4
                            if(mesg[i] == "0"){
                                if(!pressedButton4){//Onへの切り替わり直後
                                    pressedButton4 = true;
                                    keyDownButton4 = true;
                                }else if(keyDownButton4){//押され続けてる場合
                                    keyDownButton4 = false;
                                }
                            }else{
                                if(pressedButton4){//Offへの切り替わり直後
                                    pressedButton4 = false;
                                    keyUpButton4 = true;
                                }else if(keyUpButton4){//押され続けていない
                                    keyUpButton4 = false;
                                }
                            }
                            break;
                        case 4://W
                            if(mesg[i] == "0"){
                                if(!pressedW){//Onへの切り替わり直後
                                    pressedW = true;
                                    keyDownButtonW = true;
                                }else if(keyDownButtonW){//押され続けてる場合
                                    keyDownButtonW = false;
                                }
                            }else{
                                if(pressedW){//Offへの切り替わり直後
                                    pressedW = false;
                                    keyUpButtonW = true;
                                }else if(keyUpButtonW){//押され続けていない
                                    keyUpButtonW = false;
                                }
                            }
                            break;
                        case 5://A
                            if(mesg[i] == "0"){
                                if(!pressedA){//Onへの切り替わり直後
                                    pressedA = true;
                                    keyDownButtonA = true;
                                }else if(keyDownButtonA){//押され続けてる場合
                                    keyDownButtonA = false;
                                }
                            }else{
                                if(pressedA){//Offへの切り替わり直後
                                    pressedA = false;
                                    keyUpButtonA = true;
                                }else if(keyUpButtonA){//押され続けていない
                                    keyUpButtonA = false;
                                }
                            }
                            break;
                        case 6://S
                            if(mesg[i] == "0"){
                                if(!pressedS){//Onへの切り替わり直後
                                    pressedS = true;
                                    keyDownButtonS = true;
                                }else if(keyDownButtonS){//押され続けてる場合
                                    keyDownButtonS = false;
                                }
                            }else{
                                if(pressedS){//Offへの切り替わり直後
                                    pressedS = false;
                                    keyUpButtonS = true;
                                }else if(keyUpButtonS){//押され続けていない
                                    keyUpButtonS = false;
                                }
                            }
                            break;
                        case 7://D
                            if(mesg[i] == "0"){
                                if(!pressedD){//Onへの切り替わり直後
                                    pressedD = true;
                                    keyDownButtonD = true;
                                }else if(keyDownButtonD){//押され続けてる場合
                                    keyDownButtonD = false;
                                }
                            }else{
                                if(pressedD){//Offへの切り替わり直後
                                    pressedD = false;
                                    keyUpButtonD = true;
                                }else if(keyUpButtonD){//押され続けていない
                                    keyUpButtonD = false;
                                }
                            }
                            break;

                    }
                }

            }

        }
}
