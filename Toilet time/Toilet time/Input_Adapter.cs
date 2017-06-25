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


            KeyboardState state = Keyboard.GetState();
            Console.WriteLine(state.IsKeyDown(Keys.Space));

            // needs to be build out!!

            if (state.IsKeyDown(Keys.Space))
            {
                MoveAction = new Some<CharacterMovementAction>(CharacterMovementAction.Jump);
            }

            if (state.IsKeyDown(Keys.Left))
            {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Left);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Right);
            }

            return new InputData(MoveAction, WalkDirection, Activity, Settings);
            //return new Input();
        }
    }  
}