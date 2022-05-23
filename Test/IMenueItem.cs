namespace Menues
{
    internal interface IMenueItem
    {
        string Name { get; }

        void Execute() { }
    }
}
