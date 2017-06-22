using System;

namespace paalvast
{
    class Main_Game
    {
        Iterator<Fallable_Object> Fallable_Objects;

        Iterator<Stable_Object> Stable_Objects;
        public Main_Game()
        {

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
        }

        private void Reset_Level()
        {

        }

        public void Draw()
        {

        }

        public void Update()
        {

        }
    }
}