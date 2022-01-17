namespace Other.MatchThreeGame.Assets.Scripts
{
    public class Optional<T>
    {
        public T Value;
        public bool IsEmpty;

        public static Optional<object> Empty()
        {
            return new Optional<object>();
        }

        public static Optional<T> Of(T v)
        {
            return new Optional<T>();
        }

        public Optional(T value)
        {
            this.Value = value;
            IsEmpty = false;
        }

        public Optional()
        {
            IsEmpty = true;
        }
    } 
}