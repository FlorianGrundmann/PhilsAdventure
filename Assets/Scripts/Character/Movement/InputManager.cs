using UnityEngine;

namespace Assets.Scripts.Character.Movement
{
    class InputManager
    {
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
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool MenuPressed
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool MagicPressed
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool JumpPressed
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
