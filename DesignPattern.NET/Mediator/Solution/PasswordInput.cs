using DesignPattern.NET.Mediator.Context;

namespace DesignPattern.NET.Mediator.Solution
{
    class PasswordInput : TextInput, IComponent
    {
        public IMediator Mediator { get; set; }

        public PasswordInput()
        {
            OnChange += () => Mediator?.UpdateChanges();
        }
    }
}