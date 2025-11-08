namespace RingLibrary
{
    public interface IRing<T>
    {
        void Add(T item);
        T Read();         
        T Remove();       
        void Next();      
        void Prev();      
        int Count { get; }
    }
}
