﻿using System;

namespace Toilet_time
{
    public class Gui_Manager
    {
        Iterator<Fallable_Object> Fallable_Objects;
        Iterator<Stable_Object> Stable_Objects;
        Iterator<iObject> Gui_stuff;

        Screen Current_screen;
        int screen;

        public Factory_screen screenFactory;
        public DrawVisitor Drawvisitor;
        public Input_Adapter inputadapter;
        public Point Cursor;

        public int CharacterSpeed = 300;
        float localwalkspeed = 0;

        public Gui_Manager(DrawVisitor drawvisitor)
        {
            this.Drawvisitor = drawvisitor;
            this.screenFactory = new Factory_screen();
            this.inputadapter = new Input_Adapter();
            this.screen = 1;
            this.Cursor = new Point(0,0);
            Create_screen();
        }

        public bool Check_Collision(iObject Object, int x_pos, int y_pos, int x_size, int y_size)
        {
            Stable_Objects.Reset();
            bool returnbool = true;
            Stable_Objects.Reset();
            while (Stable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                // checking gravity: falling and other
                if (Stable_Objects.GetCurrent().Visit(

                                                            () => { return false; }

                                                            ,


                                                            item =>
                                                                {
                                                                    bool returnstatement = false;

                                                                   if (         x_pos < item.position.x + item.size.x      &&      x_pos + x_size > item.position.x)
                                                                    {
                                                                        if (    y_pos + y_size> item.position.y            &&      y_pos < item.position.y + item.size.y)
                                                                        {
                                                                            return true;
                                                                        }

                                                                    }

                                                                    return returnstatement;

                                                                }
                                                            )
                    )
                {
                    returnbool = false;
                }
                   
            }

            return returnbool;
        }

        public Fallable_Object GetMain_Character()
        {
            {
                Fallable_Objects.Reset();
                while (Fallable_Objects.GetNext().Visit(() => false, _ => true))
                {
                    if (Fallable_Objects.GetCurrent().Visit<bool>(() => false, item => item.IsMainCharacter))
                    {
                        return (Fallable_Objects.GetCurrent().Visit<Fallable_Object>(() => null, item => { return item; }));
                    }
                }
                return null;
            }
        }

        public void Input_Handler()
        {
            InputData input = inputadapter.GetInput();
        }

        public void Create_screen()
        {
            Reset_screen();
            Current_screen = screenFactory.Create_screen(screen);
            this.Fallable_Objects = Current_screen.Fallable_Objects;
            this.Stable_Objects = Current_screen.Stable_Objects;
            this.Gui_stuff = Current_screen.gui_stuff;
        }

        private void Reset_screen()
        {
            this.Fallable_Objects = null;
            this.Stable_Objects = null;
            this.Gui_stuff = null;
        }


        public void Draw()
        {
            Drawvisitor.spriteBatch.Begin();

            Stable_Objects.Reset();
            while (Stable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Draw(Drawvisitor); });
            }

            Fallable_Objects.Reset();
            while (Fallable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Draw(Drawvisitor); });
            }

            Gui_stuff.Reset();
            while (Gui_stuff.GetNext().Visit(() => false, unusedvalue => true))
            {
                Gui_stuff.GetCurrent().Visit(() => { }, item => { item.Draw(Drawvisitor); });
            }

            Drawvisitor.spriteBatch.End();
        }

        // Update

        // small walk check
        public bool CheckIfMove(float dt, WalkDirectionInput way, int walkspeed)
        {
            Fallable_Object main = GetMain_Character() ;
            bool moveable = false;
            int multiplyer = 1;
            if (main != null)
            {
                if (way == WalkDirectionInput.Right) { multiplyer = 1; }
                if (way == WalkDirectionInput.Left) { multiplyer = -1; }

                moveable = Check_Collision(main, main.position.x + walkspeed * multiplyer, main.position.y, main.size.x, main.size.y);
            }
            return moveable;
        }
        //


        public void Update(float dt)
        {
            Drawvisitor.spriteBatch.Begin();
            InputData input = inputadapter.GetInput();

            // cursor
            this.Cursor = input.cursor;

            // walk
            bool walk = false;
            bool CanMove = false;
            int walkspeed = 0;

            localwalkspeed += CharacterSpeed * dt;
            for (int i = (int)(localwalkspeed); i > 0; i--)
            {
                localwalkspeed = localwalkspeed - 1.0f;
                walkspeed++;
            }    
            

            WalkDirectionInput walkdirection = WalkDirectionInput.Right;
            
            if (input.Walk.Visit(() => false, _ => true))
            {
                walk = true;
                walkdirection = input.Walk.Visit<WalkDirectionInput>(() => { throw new Exception("walkdirection failed"); },  item => { return item; });

                CanMove = CheckIfMove(dt, walkdirection, walkspeed); // Checks if allowed to move character
                if (CanMove == false && walkspeed > 1)
                {
                    for (int i = walkspeed; i > 0 && CanMove == false; i--)
                    {
                        CanMove = CheckIfMove(dt, walkdirection, i); // Checks if allowed to move character
                        if (CanMove == true)
                        {
                            walkspeed = i;
                        }
                    }
                }
            }

           

            // jump
            if (input.MoveAction.Visit(() => false, _ => true))
            {
                if (input.MoveAction.Visit<CharacterMovementAction>(() => { throw new Exception("Charactermovement failed"); }, item => { return item; }) == CharacterMovementAction.Jump)
                {
                    Fallable_Object main = GetMain_Character();
                    if (main.IsMainCharacter == true)
                    {
                        main.Jump(this);
                    }
                }
            }


            // updating
            Stable_Objects.Reset();
            while (Stable_Objects.GetNext().Visit(() => false, _ => true))
            {
                Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(dt, this); });

                if (walk == true && CanMove == true)
                {
                    Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Move(dt, this, walkdirection, walkspeed); });
                }
            }

            Fallable_Objects.Reset();
            while (Fallable_Objects.GetNext().Visit(() => false, _ => true))
            {
                Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(dt, this); });

                if (walk == true && CanMove == true)
                {
                    Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Move(dt, this, walkdirection, walkspeed); });
                }
            }

            Gui_stuff.Reset();
            while (Gui_stuff.GetNext().Visit(() => false, unusedvalue => true))
            {
                Gui_stuff.GetCurrent().Visit(() => { }, item => { item.Update(dt, this); });
            }

            Drawvisitor.spriteBatch.End();
        }
    }
}