using System;

namespace Toilet_time
{
    public class Level
    {
        public Iterator<Fallable_Object> Fallable_Objects;
        public Iterator<Stable_Object> Stable_Objects;
        public Level(Iterator<Fallable_Object> fallable_objects, Iterator<Stable_Object> stable_objects)
        {
            this.Fallable_Objects = fallable_objects;
            this.Stable_Objects = stable_objects;
        }

    }

}