using System;

namespace Toilet_time
{
    enum CharacterMovementAction{Jump}

    enum WalkDirectionInput { Left,Right }

    enum Activity {Action}

    enum SettingsInput {Exit}

    class Input
    {
        public iOption<CharacterMovementAction> MoveAction() 
        {
            throw new NotImplementedException();
        }

        public iOption<WalkDirectionInput> Walk()
        {
            throw new NotImplementedException();
        }

        public iOption<Activity> Settings()
        {
            throw new NotImplementedException();
        }

        public iOption<SettingsInput> Activity()
        {
            throw new NotImplementedException();
        }


    }
}