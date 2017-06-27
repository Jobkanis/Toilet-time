using System;

namespace Toilet_time
{
    public class Screen
    {
        public Iterator<Fallable_Object> Fallable_Objects;
        public Iterator<Stable_Object> Stable_Objects;
        public Iterator<iObject> gui_stuff;
        public Iterator<iObject> Interacting_Objects;
        public bool islevel;

        public Screen(Iterator<Fallable_Object> fallable_objects, Iterator<Stable_Object> stable_objects, Iterator<iObject> gui_stuff, Iterator<iObject> Interacting_Objects, bool islevel)
        {
            this.Fallable_Objects = fallable_objects;
            this.Stable_Objects = stable_objects;
            this.gui_stuff = gui_stuff;
            this.Interacting_Objects = Interacting_Objects;
            this.islevel = islevel;
        }

    }

}