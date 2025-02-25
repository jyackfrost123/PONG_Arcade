using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parametorController : MonoBehaviour
{
    [SerializeField] private bool isSmartPhone = false;
    [SerializeField] private bool notFirst = false;
    
    public bool NotFirst{
        set{this.notFirst = value;}
        get{ return this.notFirst;}
    }

    public bool IsSmartPhone{
        set{this.isSmartPhone = value;}
        get{ return this.isSmartPhone;}
    }

}
