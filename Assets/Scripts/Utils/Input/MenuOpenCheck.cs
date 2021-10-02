using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpenCheck
{
    private const string MENU_AXIS = "Menu";

    private float menuLastFrame = 0;


    public bool Check(){
        if(Mathf.Approximately(Input.GetAxisRaw(MENU_AXIS), 1) && Mathf.Approximately(menuLastFrame, 0) ){
            return true;
        }
        Update();
        return false;
    }

    public void Update(){
        menuLastFrame = Input.GetAxisRaw(MENU_AXIS);
    }
    

}
