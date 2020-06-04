namespace Restaurant
{
    internal interface IPriceList
    {
        void RemoveDish(string name);
        string Format();
    }
}