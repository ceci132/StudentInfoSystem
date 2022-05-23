using System;

namespace UserLogin
{
    public class LoginValidation
    {
        public static String username { get; private set; }
        private String password;
        private String errorMessage;
        private ActionOnError actionOnError;

        public delegate void ActionOnError(string errorMsg);
        public static UserRoles currentUserRole { get; private set; }
        public LoginValidation(String name, String password, ActionOnError action)
        {
            username = name;
            this.password = password;
            actionOnError = action;
        }
        public bool ValidateUserInput(ref User user)
        {
            bool emptyUserName;
            emptyUserName = username.Equals(String.Empty);
            if (emptyUserName == true)
            {
                errorMessage = "Not provided username";
                actionOnError(errorMessage);
                return false;
            }
            bool emptyPassword;
            emptyPassword = password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                errorMessage = "Not provided password";
                actionOnError(errorMessage);
                return false;
            }
            if (password.Length < 5)
            {
                errorMessage = "Password is too short. Please enter at least 5 characters.";
                actionOnError(errorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);
            if (user != null)
            {
                currentUserRole = (UserRoles)user.role;
                Logger.LogActivity("Successful login");
                return true;
            } else
            {
                errorMessage = "Invalid username or password";
                actionOnError(errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
        }
    }
}
