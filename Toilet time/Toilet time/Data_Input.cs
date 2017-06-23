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
        public iOption<Activity> Activity;
        public iOption<SettingsInput> Settings;

        public Input(iOption<CharacterMovementAction> MoveAction, iOption<WalkDirectionInput> Walk, iOption<Activity> Activity, iOption<SettingsInput> Settings)
        {
            this.MoveAction = MoveAction;
            this.Walk = Walk;
            this.Settings = Settings;
            this.Activity = Activity;
        }

    }
}