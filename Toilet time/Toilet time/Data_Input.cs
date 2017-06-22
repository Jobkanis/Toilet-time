using System;

namespace Toilet_time
{
    enum CharacterMovementAction{Jump}

    enum WalkDirectionInput { Left,Right }

    enum Activity {Action}

    enum SettingsInput {Exit}

    public class Input
    {
        iOption<CharacterMovementAction> MoveAction() 
        {
            throw new NotImplementedException();
        }

        iOption<WalkDirectionInput> Walk()
        {
            throw new NotImplementedException();
        }

        iOption<Activity> Settings()
        {
            throw new NotImplementedException();
        }

        iOption<SettingsInput> Activity()
        {
            throw new NotImplementedException();
        }


    }
}