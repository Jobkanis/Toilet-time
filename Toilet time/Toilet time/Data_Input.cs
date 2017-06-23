using System;

namespace Toilet_time
{
    public enum CharacterMovementAction{Jump}

    public enum WalkDirectionInput { Left,Right }

    public enum Activity {Action}

    public enum SettingsInput {Exit}

    public class Input
    {
        public iOption<CharacterMovementAction> MoveAction;
        public iOption<WalkDirectionInput> Walk;
        public iOption<Activity> Settings;
        public iOption<SettingsInput> Activity;

        public Input(iOption<CharacterMovementAction> MoveAction, iOption<WalkDirectionInput> Walk, iOption<Activity> Settings, iOption<SettingsInput> Activity)
        {
            this.MoveAction = MoveAction;
            this.Walk = Walk;
            this.Settings = Settings;
            this.Activity = Activity;
        }

    }
}