using System;

namespace DesignPattern.NET.Mediator.Context
{
    public class TextInput : IDisable
    {
        public string Value { get; set; }
        public event Action OnChange;
        public bool Disable { get; set; }
    }
}