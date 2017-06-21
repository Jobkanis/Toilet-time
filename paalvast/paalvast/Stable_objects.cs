using System;

namespace paalvast
{
    abstract class Fallabe_Object : iObject
    {
        public abstract void Draw();

        public abstract void Update();


        public void Fall()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Stable_Object : iObject
    {
        public abstract void Draw();
        public abstract void Update();
        
        
    }


    class Main_Character : Fallabe_Object
    {
        public void Walk_left() { }
        public void Walk_right() { }
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {

        }


    }

    class Platform : Stable_Object
    {
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}