using UnityEngine;
using System.Collections;

public class InputChecker  {

    public static bool RightPressed
    {
        get
        {
            float horizontalAxisRaw = Input.GetAxisRaw("Horizontal");
            return (horizontalAxisRaw > 0);
        }
    }

    public static bool LeftPressed
    {
        get
        { 
            float horizontalAxisRaw = Input.GetAxisRaw("Horizontal");
            return (horizontalAxisRaw < 0);
        }
    }

    public static bool CancelPressed
    {
        get
        {
            return Input.GetButtonDown("Cancel");
        }
    }

    public static bool MagicPressed
    {
        get
        {
            return Input.GetButton("Magic");
        }
    }

    public static bool JumpPressed
    {
        get
        {
            return Input.GetButtonDown("Jump");
        }
    }
    
}
