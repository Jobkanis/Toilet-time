using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Toilet_time_main;

// TO DO: - Add another way of inserting input
// TO DO: - Make a switch to change between input methods
// TO DO: - Make input by buttons possible - add new list in gui_manager and make it give it to inputadapter every update

namespace Toilet_time_Android
{

    public class Input_Adapter_Android: Input_Adapter
    {


        public Input_Adapter_Android()
        {
        }

        public InputData GetInput(int type)
        {
            return checkKeyboardpijltjes();
        }

        public InputData checkKeyboardpijltjes()
        {
            iOption<CharacterMovementAction> MoveAction = new None<CharacterMovementAction>();
            iOption<WalkDirectionInput> WalkDirection = new None<WalkDirectionInput>();
            iOption<CharacterActivity> CharacterActivity = new None<CharacterActivity>();
            iOption<SettingsInput> Settings = new None<SettingsInput>();
            iOption<MousePressed> MouseAction = new None<MousePressed>();

            Point cursor = new Point(-1, -1);

            return new InputData(MoveAction, WalkDirection, CharacterActivity, Settings, MouseAction, cursor, false);
        }

    }
}