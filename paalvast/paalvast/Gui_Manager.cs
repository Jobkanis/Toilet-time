using System;

namespace paalvast
{
    class Gui_Manager
    {
        Iterator<Fallable_Object> Fallable_Objects;
        Iterator<Stable_Object> Stable_Objects;
        Level Current_Level;
        int level;
        Factory_Level levelFactory;
        public Gui_Manager()
        {
            this.levelFactory = new Factory_Level();
            this.level = 1;
            Create_Level();
        }

        public iOption<Collision> Check_Collision(iObject Object)
        {
            return new Some<Collision>(new Collision());
        }

        public Main_Character GetMain_Character()
        {
            return new Main_Character();
        }

        public void Input_Handler()
        {

        }

        public void Create_Level()
        {
            Reset_Level();
            Current_Level = levelFactory.Draw_Level(level);
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
            Fallable_Objects.Reset();
            if (Fallable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Draw(); });
            }

            Stable_Objects.Reset();
            if (Stable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Draw(); });
            }
        }

        public void Update()
        {
            Fallable_Objects.Reset();
            if (Fallable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                Fallable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(); });
            }

            Stable_Objects.Reset();
            if (Stable_Objects.GetNext().Visit(() => false, unusedvalue => true))
            {
                Stable_Objects.GetCurrent().Visit(() => { }, item => { item.Update(); });
            }

        }
    }
}