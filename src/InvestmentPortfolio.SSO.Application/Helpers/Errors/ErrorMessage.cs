using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InvestmentPortfolio.SSO.Application.Helpers.Errors
{
    public class ErrorMessage
    {
        #region [PROPS]

        public string Code { get; set; }
        public string Message { get; set; }

        #endregion [PROPS]

        #region [CONSTRUCTORS]

        public ErrorMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }

        #endregion [CONSTRUCTORS]

        #region [MESSAGES]

        public static readonly ErrorMessage GENERIC_ERROR = new("001", "An internal error has occurred.");
        public static readonly ErrorMessage DB_CONNECTION_PROBLEMS = new("002", "Database connection problems.");
        
        public static readonly ErrorMessage FIELD_REQUIRED = new("401", "This field {0} is required.");
        public static readonly ErrorMessage PASSWORD_SHORTED = new("402", "Password must have at least 8 characters.");
        public static readonly ErrorMessage PASSWORD_SPECIAL_CHARACTER_MISSING = new("403", "Password must contain at least one special character");
        public static readonly ErrorMessage PASSWORD_NUMBER_MISSING = new("404", "Password must contain at least one number");
        public static readonly ErrorMessage PASSWORD_UPPERCASE_MISSING = new("405", "Password must contain at least one uppercase letter");
        public static readonly ErrorMessage INVALID_EMAIL = new("406", "Invalid email address");

        #endregion [MESSAGES]

        #region [METODS]

        private static readonly Dictionary<string, ErrorMessage> ErrorMessagesByCode;

        static ErrorMessage()
        {
            ErrorMessagesByCode = typeof(ErrorMessage)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => field.FieldType == typeof(ErrorMessage))
                .Select(field => (ErrorMessage)field.GetValue(null)!)
                .ToDictionary(error => error.Code);
        }

        public static ErrorMessage GetErrorMessageByCode(string code)
        {
            if (ErrorMessagesByCode.TryGetValue(code, out var errorMessage))
            {
                return errorMessage;
            }

            throw new Exception();
        }

        public string FormatMessage(string arg)
        {
            return string.Format(Message, arg);
        }

        #endregion [METODS]
    }
}
