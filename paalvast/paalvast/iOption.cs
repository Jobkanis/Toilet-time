namespace paalvast
{
    public interface IOptionVisitor<T, U>
    {
        U onSome(T value);
        U onNone();
    }

    public interface iOption<T>
    {
        U Visit<U>(IOptionVisitor<T, U> visitor);
    }

    class Some<T> : iOption<T>
    {
        public T value;
        public Some(T value)
        {
            this.value = value;
        }
        public U Visit<U>(IOptionVisitor<T, U> visitor)
        {
            return visitor.onSome(this.value);
        }
    }

    class None<T> : iOption<T>
    {
        public U Visit<U>(IOptionVisitor<T, U> visitor)
        {
            return visitor.onNone();
        }
    }

}