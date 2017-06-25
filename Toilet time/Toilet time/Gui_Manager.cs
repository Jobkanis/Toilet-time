using System;

namespace Toilet_time
{
    public class Gui_Manager
    {
        Iterator<Fallable_Object> Fallable_Objects;
        Iterator<Stable_Object> Stable_Objects;
        Level Current_Level;
        int level;
        Factory_Level levelFactory;
        DrawVisitor Drawvisitor;
        Input_Adapter inputadapter;
        float walkspeed = 300;

        public Gui_Manager(DrawVisitor drawvisitor)
        {
            this.Drawvisitor = drawvisitor;
            this.levelFactory = new Factory_Level();
            this.inputadapter = new Input_Adapter();
            this.level = 1;
            Create_Level();
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

                                                                   if (         x_pos < item.position.x + item.size.x + 2  &&      x_pos + x_size + 2> item.position.x)
                                                                    {
                                                                        if (    y_pos + y_size + 2 > item.position.y        &&      y_pos < item.position.y + item.size.y + 2)
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

        public void Create_Level()
        {
            Reset_Level();
            Current_Level = levelFactory.Create_Level(level);
            this.Fallable_Objects = Current_Level.Fallable_Objects;
            this.Stable_Objects = Current_Level.Stable_Objects;
        }

        private void Reset_Level()
        {
            this.Fallable_Objects = null;
            this.Stable_Objects = null;
        }


        public void Draw()
        {
            Drawvisitor.spriteBatch.Begin();

            Fallable_Objects.Reset();
             while (Fallable_Objects.GetNext().Visit(() => false, unusedvalue => true))
             {
                 Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Draw(Drawvisitor); });
             }
            
            Stable_Objects.Reset();
            while (Stable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Draw(Drawvisitor); });
            }

            Drawvisitor.spriteBatch.End();
        }

        // Update

        // small walk check
        float localwalkcalculation = 0;
        public bool CheckIfMove(float dt, WalkDirectionInput way)
        {
            Fallable_Object main = GetMain_Character() ;
            bool moveable = false;


            if (way == WalkDirectionInput.Right)
            {
                localwalkcalculation += walkspeed * dt;
                moveable = Check_Collision(main, main.position.x + 1, main.position.y, main.size.x, main.size.y);
            }

            if (way == WalkDirectionInput.Left)
            {
                localwalkcalculation -= walkspeed * dt;
                moveable = Check_Collision(main, main.position.x - 1, main.position.y, main.size.x, main.size.y);
            }
            if (moveable ){
                if (localwalkcalculation > 1.0f || localwalkcalculation < 1.0)
                {
                    localwalkcalculation = 0;
                    return true;
                }
            }

            return false;
        }
        //


        public void Update(float dt)
        {
            // walk
            bool walk = false;
            WalkDirectionInput walkdirection = WalkDirectionInput.Right;
            bool CanMove = CheckIfMove(dt, walkdirection); // Checks if allowed to move character
            InputData input = inputadapter.GetInput();
            if (input.Walk.Visit(() => false, _ => true))
            {
                walk = true;
                walkdirection = input.Walk.Visit<WalkDirectionInput>(() => { throw new Exception("walkdirection failed"); },  item => { return item; });
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


            Fallable_Objects.Reset();
            while (Fallable_Objects.GetNext().Visit(() => false, _ => true))
            {
                Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(dt, this); });

                if (walk && CanMove == true)
                {
                    Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Move(dt, this, walkdirection); });
                }
            }


            Stable_Objects.Reset();
            while (Stable_Objects.GetNext().Visit(() => false, _ => true))
            {
                Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(dt, this); });

                if (walk && CanMove == true)
                {
                    Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Move(dt, this, walkdirection); });
                }
            }
        }
    }
}