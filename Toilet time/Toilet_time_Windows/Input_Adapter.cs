using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using Toilet_time_main;

// TO DO: - Add another way of inserting input
// TO DO: - Make a switch to change between input methods
// TO DO: - Make input by buttons possible - add new list in gui_manager and make it give it to inputadapter every update

namespace Toilet_time_Windows
{

    public class Input_Adapter_Windows: Input_Adapter // for windows
    {
        Toilet_time_main.Point current_cursor = new Toilet_time_main.Point(0, 0);
        bool GamepadOnline = false;

        public Input_Adapter_Windows()
        {
        }

        public InputData GetInput(int type)
        {
            // checks if gamepad is online
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            GamepadOnline = gamePadState.IsConnected;
            //
            switch (type)
            {
                //choose correct input type
                case 1:
                    return checkKeyboardpijltjes();
                    //break;
                case 2:
                    return checkKeyboardaswd();
                //break;
                case 3:
                    return checkGamePad();
                    //break;
                default:
                    return checkKeyboardpijltjes();
                    //break;
                
            }
            
        }



        public InputData checkKeyboardpijltjes() // check input by keyboardpijltjes
        {
            iOption<CharacterMovementAction> MoveAction = new None<CharacterMovementAction>();
            iOption<WalkDirectionInput> WalkDirection = new None<WalkDirectionInput>();
            iOption<CharacterActivity> CharacterActivity = new None<CharacterActivity>();
            iOption<SettingsInput> Settings = new None<SettingsInput>();
            iOption<MousePressed> MouseAction = new None<MousePressed>();

            Toilet_time_main.Point cursor = new Toilet_time_main.Point(-1, -1);
            current_cursor = cursor;
            KeyboardState keyboard_state = Keyboard.GetState();

            var mouse_state = Mouse.GetState();
            cursor = new Toilet_time_main.Point(mouse_state.X, mouse_state.Y);

            if (mouse_state.LeftButton == ButtonState.Pressed) {
                MouseAction = new Some<MousePressed>(MousePressed.Left_Button); }

            if (keyboard_state.IsKeyDown(Keys.Up)) {
                MoveAction = new Some<CharacterMovementAction>(CharacterMovementAction.Jump); }

            if (keyboard_state.IsKeyDown(Keys.Left)) {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Left); }

            if (keyboard_state.IsKeyDown(Keys.Right)) {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Right); }

            if (keyboard_state.IsKeyDown(Keys.Right) && keyboard_state.IsKeyDown(Keys.Left)) {
                WalkDirection = new None<WalkDirectionInput>(); }

            if (keyboard_state.IsKeyDown(Keys.E)) {
                CharacterActivity = new Some<CharacterActivity>(Toilet_time_main.CharacterActivity.Action); }

            return new InputData(MoveAction, WalkDirection, CharacterActivity, Settings, MouseAction, cursor, GamepadOnline);
        }


        public InputData checkKeyboardaswd() // check input aswd
        {
            iOption<CharacterMovementAction> MoveAction = new None<CharacterMovementAction>();
            iOption<WalkDirectionInput> WalkDirection = new None<WalkDirectionInput>();
            iOption<CharacterActivity> CharacterActivity = new None<CharacterActivity>();
            iOption<SettingsInput> Settings = new None<SettingsInput>();
            iOption<MousePressed> MouseAction = new None<MousePressed>();
            Toilet_time_main.Point cursor = new Toilet_time_main.Point(-1, -1);

            KeyboardState keyboard_state = Keyboard.GetState();

            var mouse_state = Mouse.GetState();
            cursor = new Toilet_time_main.Point(mouse_state.X, mouse_state.Y);
            current_cursor = cursor;

            if (mouse_state.LeftButton == ButtonState.Pressed) {
                MouseAction = new Some<MousePressed>(MousePressed.Left_Button); }

            
            if (keyboard_state.IsKeyDown(Keys.W)){
                MoveAction = new Some<CharacterMovementAction>(CharacterMovementAction.Jump); }

            if (keyboard_state.IsKeyDown(Keys.A)) {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Left); }

            if (keyboard_state.IsKeyDown(Keys.D)) { 
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Right); }

            if (keyboard_state.IsKeyDown(Keys.A) && keyboard_state.IsKeyDown(Keys.D)){
                WalkDirection = new None<WalkDirectionInput>(); }

            if (keyboard_state.IsKeyDown(Keys.E)) {
                CharacterActivity = new Some<CharacterActivity>(Toilet_time_main.CharacterActivity.Action); }

            return new InputData(MoveAction, WalkDirection, CharacterActivity, Settings, MouseAction, cursor, GamepadOnline);
        }



        public InputData checkGamePad() // check input by gamepad
        {
            iOption<CharacterMovementAction> MoveAction = new None<CharacterMovementAction>();
            iOption<WalkDirectionInput> WalkDirection = new None<WalkDirectionInput>();
            iOption<CharacterActivity> CharacterActivity = new None<CharacterActivity>();
            iOption<SettingsInput> Settings = new None<SettingsInput>();
            iOption<MousePressed> MouseAction = new None<MousePressed>();
          
            float Mousesensitivity = 8f;
            Toilet_time_main.Point ReturnCursor = current_cursor;

            KeyboardState keyboard_state = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if (gamePadState.IsConnected)
            {
                // then it is connected, and we can do stuff here

                //Walk
                if (gamePadState.ThumbSticks.Left.X < -0.1){
                    WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Left);}
                else if (gamePadState.ThumbSticks.Left.X > 0.1){
                    WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Right);}

                // Move cursor
                if (gamePadState.ThumbSticks.Right.X < -0.1) {
                    ReturnCursor.x = ReturnCursor.x - (int)(-1 * gamePadState.ThumbSticks.Right.X * Mousesensitivity); }
                else if (gamePadState.ThumbSticks.Right.X > -0.1) {
                    ReturnCursor.x = ReturnCursor.x + (int)(gamePadState.ThumbSticks.Right.X * Mousesensitivity); }
                if (gamePadState.ThumbSticks.Right.Y < -0.1) {
                     ReturnCursor.y = ReturnCursor.y + (int)(-1 * gamePadState.ThumbSticks.Right.Y * Mousesensitivity); }
                else if (gamePadState.ThumbSticks.Right.Y > -0.1) {
                    ReturnCursor.y = ReturnCursor.y - (int)(gamePadState.ThumbSticks.Right.Y * Mousesensitivity); }


                if (gamePadState.Buttons.A == ButtonState.Pressed)
                {
                    MouseAction = new Some<MousePressed>(MousePressed.Left_Button);
                    MoveAction = new Some<CharacterMovementAction>(CharacterMovementAction.Jump);
                } 

                if (gamePadState.Buttons.B == ButtonState.Pressed)
                {
                    CharacterActivity = new Some<CharacterActivity>(Toilet_time_main.CharacterActivity.Action); 
                }

                Toilet_time_main.Point cursor = ReturnCursor;
                return new InputData(MoveAction, WalkDirection, CharacterActivity, Settings, MouseAction, cursor, GamepadOnline);
            }
            else
            {
                return checkKeyboardpijltjes(); // returns input of checkkeyboardpijltjes when controller disconnects
            }
            //return new Input();
        }
    }  
}