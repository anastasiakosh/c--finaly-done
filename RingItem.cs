namespace RingLibrary
{
    public class RingItem<T>
    {
        public T Value { get; set; }
        public RingItem<T>? Next { get; set; }
        public RingItem<T>? Prev { get; set; }

        public RingItem(T value)
        {
            Value = value;
        }
    }
}
