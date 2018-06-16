using System;

namespace DesignPattern.NET.Mediator.Context
{
    public class Button : IDisable
    {
        public event Action OnClick;
        public bool Disable { get; set; }
    }
}