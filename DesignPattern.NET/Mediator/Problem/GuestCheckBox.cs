using DesignPattern.NET.Mediator.Context;

namespace DesignPattern.NET.Mediator.Problem
{
    public class GuestCheckBox
    {
        private readonly Button _login;
        private readonly TextInput _username;
        private readonly TextInput _passwsord;

        public GuestCheckBox(Button login, TextInput username, TextInput passwsord)
        {
            _login = login;
            _username = username;
            _passwsord = passwsord;
        }


        void OnChanged(bool check)
        {
            if (check)
            {
                _login.Disable = true;
                _username.Disable = true;
                _passwsord.Disable = true;
            }
        }
    }
}