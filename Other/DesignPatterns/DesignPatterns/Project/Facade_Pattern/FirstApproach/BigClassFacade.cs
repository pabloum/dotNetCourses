namespace Facade_Pattern
{
    public class BigClassFacade
    {
        public BigClass bigClass { get; set; }
        public void IncrementByValue(int value)
        {
            bigClass.SetValue(value);
            bigClass.IncrementI();
            bigClass.IncrementI();
            bigClass.IncrementI();
        }

        public void DecrementByValue(int value)
        {
            bigClass.DecrementI();
        }
    }
}