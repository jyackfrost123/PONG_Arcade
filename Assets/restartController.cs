using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartController : MonoBehaviour
{
    private bool ischanging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.L) && ischanging == false){
            ischanging = true;
            FadeManager.Instance.LoadScene ("Title", 0.5f);
        }
    }
}
