using DesignPattern.NET.Mediator.Context;

namespace DesignPattern.NET.Mediator.Solution
{
    class GuestCheckBox : CheckBox, IComponent
    {
        public IMediator Mediator { get; set; }

        public GuestCheckBox()
        {
            OnClick += () => Mediator?.UpdateChanges();
        }
    }
}