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

        public Gui_Manager(DrawVisitor drawvisitor)
        {
            this.Drawvisitor = drawvisitor;
            this.levelFactory = new Factory_Level();

            this.level = 1;
            Create_Level();
        }

        public Collision Check_Collision(iObject Object)
        {
            return new Collision(new None<iObject>(), new None<iObject>(), new None<iObject>(), new None<iObject>());
        }

        public Main_Character GetMain_Character()
        {
            throw new Exception();
        }

        public void Input_Handler()
        {

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
                Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(dt); });
            }

            Stable_Objects.Reset();
            while (Stable_Objects.GetNext().Visit(() => false, _ => true))
            {
                Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(dt); });
            }
            

        }
    }
}