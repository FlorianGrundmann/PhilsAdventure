using UnityEngine;
using System.Collections;

public class InputManager  {


    private bool rightPressed;
    private bool leftPressed;
    private bool jumpPressed;
    private bool magicPressed;
    private bool menuPressed;

    public bool RightPressed
    {
        get
        {

            return rightPressed;
        }
        private set
        {
            rightPressed = value;
        }
    }

    public bool LeftPressed
    {
        get
        {
            return leftPressed;
        }

        private set
        {
            leftPressed = value;
        }
    }

    public bool MenuPressed
    {
        get
        {
            return menuPressed;
        }

        private set
        {
            menuPressed = value;
        }
    }

    public bool MagicPressed
    {
        get
        {
            return magicPressed;
        }

        private set
        {
            magicPressed = value;
        }
    }

    public bool JumpPressed
    {
        get
        {
            return jumpPressed;
        }

        private set
        {
            jumpPressed = value;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        SetValuesToFalse();
        CheckHorizontalInput();
        CheckJumpInput();
        CheckMagicInput();
    }

    private void CheckMagicInput()
    {
        if (Input.GetButtonDown("Magic"))
            MagicPressed = true;
    }

    private void CheckJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
            JumpPressed = true;
    }

    private void CheckHorizontalInput()
    {
        float horizontalAxisRaw = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontalAxisRaw.ToString());
        if (horizontalAxisRaw > 0)
            RightPressed = true;
        else
            if (horizontalAxisRaw < 0)
            LeftPressed = true;
    }

    private void SetValuesToFalse()
    {
        RightPressed = false;
        LeftPressed = false;
        MenuPressed = false;
        MagicPressed = false;
        JumpPressed = false;
    }
    
}
