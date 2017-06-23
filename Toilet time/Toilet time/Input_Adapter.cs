using System;

namespace Toilet_time
{
   public class Input_Adapter
    {
        public Input_Adapter()
        {

        }

        public Input GetInput()
        {
            return checkKeyboard();
        }


        //
        public Input checkKeyboard()
        {
            iOption<CharacterMovementAction> MoveAction;
            iOption<WalkDirectionInput> Walk;
            iOption<Activity> Settings;
            iOption<SettingsInput> Activity;

            throw new Exception();
            //return new Input();
        }
    }  
}