using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.InputMethodServices;
using Toilet_time_main;
using Microsoft.Xna.Framework.Input.Touch;


// TO DO: - Add another way of inserting input
// TO DO: - Make a switch to change between input methods
// TO DO: - Make input by buttons possible - add new list in gui_manager and make it give it to inputadapter every update

namespace Toilet_time_Android
{

    public class Input_Adapter_Android : Input_Adapter
    {
        int CurrentHeight;
        int CurrentWidth;

        public Input_Adapter_Android(int CurrentWidth, int CurrentHeight)
        {
            this.CurrentWidth = CurrentWidth;
            this.CurrentHeight = CurrentHeight;
        }

        public InputData GetInput(int type)
        {
            return checkKeyboardpijltjes();
        }


        private Point ConvertPoint(Point point)
        {
            float screenmultiplier = 2;
            float diffwith = (float)(CurrentWidth / 800);
            float diffheight = (float)(CurrentHeight / 600);

            if (diffwith < diffheight)
            {
                screenmultiplier = diffwith;
            }
            else
            {
                screenmultiplier = diffheight;
            }
            screenmultiplier = 2;
            return new Point((int)((float)(point.x / screenmultiplier)), (int)((float)(point.y / screenmultiplier)));
        }

        private enum localact { none, right, left };

        public InputData checkKeyboardpijltjes()
        {
            iOption<CharacterMovementAction> MoveAction = new None<CharacterMovementAction>();
            iOption<WalkDirectionInput> WalkDirection = new None<WalkDirectionInput>();
            iOption<CharacterActivity> CharacterActivity = new None<CharacterActivity>();
            iOption<SettingsInput> Settings = new None<SettingsInput>();
            iOption<MousePressed> MouseAction = new None<MousePressed>();

            Point Cursor = new Point(-50, -50);

            bool left = false;
            bool right = false;
            localact first = localact.none;

            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (TouchLocation touch1 in touchCollection)
            {
                Cursor = ConvertPoint(new Point((int)touch1.Position.X, (int)touch1.Position.Y));
                if (Cursor.x > 0.6 * CurrentWidth)
                {
                    if (first == localact.none)
                    {
                        first = localact.right;
                    }
                    right = true;
                }
                else if (Cursor.x < 0.4 * CurrentWidth)
                {
                    if (first == localact.none)
                    {
                        first = localact.left;
                    }

                    left = true;
                }
            }

            if (left == true && right == true)
            {
                MoveAction = new Some<CharacterMovementAction>(CharacterMovementAction.Jump);
                if (first == localact.left)
                {
                    WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Left);
                }
                else if (first == localact.right)
                {
                    WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Right);
                }

            }
            else if (left == true && right == false)
            {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Left);
            }
            else if (left == false && right == true)
            {
                WalkDirection = new Some<WalkDirectionInput>(WalkDirectionInput.Right);
            }

            MouseAction = new Some<MousePressed>(MousePressed.Left_Button);

            return new InputData(MoveAction, WalkDirection, CharacterActivity, Settings, MouseAction, Cursor, false);
        }
    }
}