using System;

namespace paalvast
{
    enum CharacterMovementAction{Jump}

    enum WalkDirectionInput { Left,Right }

    enum Activity {Action}

    enum SettingsInput {Exit}

    class Input
    {
        public Option<CharacterMovementAction> MoveAction() 
        {
            throw new NotImplementedException();
        }

        public Option<WalkDirectionInput> Walk()
        {
            throw new NotImplementedException();
        }

        public Option<Activity> Settings()
        {
            throw new NotImplementedException();
        }

        public Option<SettingsInput> Activity()
        {
            throw new NotImplementedException();
        }


    }
}