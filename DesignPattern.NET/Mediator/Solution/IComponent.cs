using DesignPattern.NET.Mediator.Context;

namespace DesignPattern.NET.Mediator.Solution
{
    interface IComponent : IDisable
    {
        IMediator Mediator { get; set; }
    }
}