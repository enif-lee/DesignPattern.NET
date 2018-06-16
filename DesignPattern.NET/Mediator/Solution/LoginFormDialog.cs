using DesignPattern.NET.Mediator.Context;

namespace DesignPattern.NET.Mediator.Solution
{
    interface IMediator
    {
        void UpdateChanges();
    }

    interface IComponent : IDisable
    {
        IMediator Mediator { get; set; }
    }

class LoginFormDialog : IDialog, IMediator
{
    private CheckBox IsGuest { get; }
    private TextInput Username { get; }
    private TextInput Password { get; }
    private Button Login { get; }
    private Button Cancel { get; }

    public LoginFormDialog()
    {
        IsGuest = new GuestCheckBox();
        Username = new UsernameInput {Mediator = this};
        Password = new PasswordInput {Mediator = this};
        Login = new LoginButton();
        Cancel = new Button();
    }

    public void UpdateChanges()
    {
        Username.Disable = !IsGuest.Checked;
        Password.Disable = !IsGuest.Checked && !string.IsNullOrEmpty(Username.Value);
        Login.Disable = !string.IsNullOrEmpty(Username.Value) && !string.IsNullOrEmpty(Password.Value);
    }
}

    class GuestCheckBox : CheckBox, IComponent
    {
        public IMediator Mediator { get; set; }

        public GuestCheckBox()
        {
            OnClick += () => Mediator?.UpdateChanges();
        }
    }

    class UsernameInput : TextInput, IComponent
    {
        public IMediator Mediator { get; set; }

        public UsernameInput()
        {
            OnChange += () => Mediator?.UpdateChanges();
        }
    }

    class PasswordInput : TextInput, IComponent
    {
        public IMediator Mediator { get; set; }

        public PasswordInput()
        {
            OnChange += () => Mediator?.UpdateChanges();
        }
    }

    class LoginButton : Button
    {
    }
}