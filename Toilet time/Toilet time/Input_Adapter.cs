using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// TO DO: - Add another way of inserting input
// TO DO: - Make a switch to change between input methods
// TO DO: - Make input by buttons possible - add new list in gui_manager and make it give it to inputadapter every update

namespace Toilet_time
{

   public class Input_Adapter
    {
        public Input_Adapter()
        {

        }

        public InputData GetInput()
        {
            return checkKeyboard();
        }


        //

        public InputData checkKeyboard()
        {
            iOption<CharacterMovementAction> MoveAction = new None<CharacterMovementAction>();
            iOption<WalkDirectionInput> WalkDirection = new None<WalkDirectionInput>();
            iOption<Activity> Activity = new None<Activity>();
            iOption<SettingsInput> Settings = new None<SettingsInput>();
            Point cursor = new Point(-1, -1);

            KeyboardState keyboard_state = Keyboard.GetState();

            var mouse_state = Mouse.GetState();
            cursor = new Point(mouse_state.X, mouse_state.Y);


            // needs to be build out!
            
            if (keyboard_state.IsKeyDown(Keys.Up))
            {
                MoveAction = new Some<CharacterMovementAction>(CharacterMovementAction.Jump);
            }

            if (keyboard_state.IsKeyDown(Keys.Left))
            {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Left);
            }

            if (keyboard_state.IsKeyDown(Keys.Right))
            {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Right);
            }

            return new InputData(MoveAction, WalkDirection, Activity, Settings, cursor);
            //return new Input();
        }
    }  
}