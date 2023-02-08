namespace UniversityApp.Middleware.Validation
{
    public static class RegisterValidation
    {
        public static bool CheckUser(string nickname)
        {           
                if (nickname.Length <= 15 && nickname.Length >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }           
            
        }

        public static bool CheckName(string nameUsers)
        {
            bool a = true;
            foreach (char item in nameUsers)
            {
                if (item < 65 || item > 90)
                {
                    if (item < 97 || item > 122)
                    {
                        a = false;
                    }
                }
            }
            return a;
        }

        public static bool CheckPhone(string phoneNumber)
        {
            var t= int.TryParse(phoneNumber, out int ChekedPhone) &&
                           phoneNumber.Length == 9 &&
                           phoneNumber[0] == '0';
            return t;
        }

    }
}
