using System;

namespace Toilet_time
{
    public enum CharacterMovementAction {Jump}

    public enum WalkDirectionInput { Left,Right }

    public enum CharacterActivity {Action}

    public enum SettingsInput {Exit}


    public class InputData
    {
        public iOption<CharacterMovementAction> MoveAction;
        public iOption<WalkDirectionInput> Walk;
        public iOption<CharacterActivity> CharacterActivity;
        public iOption<SettingsInput> Settings;
        public Point cursor;

        

        public InputData(iOption<CharacterMovementAction> MoveAction, iOption<WalkDirectionInput> Walk, iOption<CharacterActivity> CharacterActivity, iOption<SettingsInput> Settings, Point cursor)
        {
            this.MoveAction = MoveAction;
            this.Walk = Walk;
            this.Settings = Settings;
            this.CharacterActivity = CharacterActivity;
            this.cursor = cursor;
        }



    }
}