using System;

namespace Toilet_time_main
{
    public enum CharacterMovementAction {Jump}

    public enum WalkDirectionInput { Left,Right }

    public enum CharacterActivity {Action}

    public enum SettingsInput {Exit}

    public enum MousePressed {Left_Button}

   
    public class InputData // is returned by inputhandler
    {
        public iOption<CharacterMovementAction> MoveAction;
        public iOption<WalkDirectionInput> Walk;
        public iOption<CharacterActivity> CharacterActivity;
        public iOption<SettingsInput> Settings;
        public iOption<MousePressed> MouseButton;
        public Point cursor;
        public bool GamePadOnline;


        public InputData(iOption<CharacterMovementAction> MoveAction, iOption<WalkDirectionInput> Walk, iOption<CharacterActivity> CharacterActivity, iOption<SettingsInput> Settings, iOption<MousePressed> MouseButton, Point cursor, bool GamePadOnline)
        {
            this.MoveAction = MoveAction;
            this.Walk = Walk;
            this.Settings = Settings;
            this.CharacterActivity = CharacterActivity;
            this.cursor = cursor;
            this.MouseButton = MouseButton;
            this.GamePadOnline = GamePadOnline;
        }



    }
}