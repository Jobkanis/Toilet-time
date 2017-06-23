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
            int count = 0;
            while (Stable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                Console.WriteLine(count);
                // checking gravity: falling and other
                if (Stable_Objects.GetCurrent().Visit(

                                                            () => { return false; }

                                                            ,


                                                            item =>
                                                                {
                                                                    if (x_pos < item.position.x + item.size.x && x_pos + x_size > item.position.x)
                                                                    {
                                                                        if (y_pos + y_size > item.position.y && y_pos < item.position.y + item.size.y)
                                                                        {
                                                                            return true;
                                                                        }

                                                                    }

                                                                    return false;

                                                                }
                                                        )
                    )
                {
                    returnbool = false;
                }

            }

            return returnbool;
        }

        public Main_Character GetMain_Character()
        {
            throw new Exception();
        }

        public void Input_Handler()
        {
            Input input = inputadapter.GetInput();
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

        public void Update(float dt)
        {
            Console.WriteLine(dt);
            Fallable_Objects.Reset();
            while (Fallable_Objects.GetNext().Visit(() => false, _ => true))
            {
                Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(dt, this); });
            }

            Stable_Objects.Reset();
            while (Stable_Objects.GetNext().Visit(() => false, _ => true))
            {
                Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(dt, this); });
            }
            

        }
    }
}