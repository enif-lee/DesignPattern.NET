using System;

namespace DesignPattern.NET.Mediator.Context
{
    public class CheckBox : IDisable
    {
        public bool Checked { get; set; }
        public event Action OnClick;
        public event Action OnUnChecked;
        public event Action OnCheck;
        public bool Disable { get; set; }
    }
}