using DesignPattern.NET.Mediator.Context;

namespace DesignPattern.NET.Mediator.Solution
{
    class UsernameInput : TextInput, IComponent
    {
        public IMediator Mediator { get; set; }

        public UsernameInput()
        {
            OnChange += () => Mediator?.UpdateChanges();
        }
    }
}