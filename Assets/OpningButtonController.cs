using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpningButtonController : MonoBehaviour
{

    
    private parametorController para;
    private Vector3 firstPos; 

    private int numSmartPhone;

    [SerializeField] private GameObject viewSmartPhone;
    [SerializeField] private GameObject hide2PButton;
    
    
    void Start()
    {
        para = GameObject.Find("FadeManager").GetComponent<parametorController>();
        
        if(!para.IsSmartPhone){
            viewSmartPhone.SetActive(false);
            numSmartPhone = 0;
            hide2PButton.SetActive(true);
        }else{
            viewSmartPhone.SetActive(true);
            numSmartPhone = 10;
            hide2PButton.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }


    public void ActiveSmartPhone(){

        if(!para.IsSmartPhone){
            if(numSmartPhone < 10){
                numSmartPhone++;
            }
            if(numSmartPhone == 10){
                para.IsSmartPhone = true;
                viewSmartPhone.SetActive(true);
                hide2PButton.SetActive(false);
            }
        }else{//True
            if(numSmartPhone > 0){
                numSmartPhone--;
            }
            if(numSmartPhone == 0){
                para.IsSmartPhone = false;
                viewSmartPhone.SetActive(false);
                hide2PButton.SetActive(true);
            }
        }
        

    }
}
