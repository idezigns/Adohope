using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.Models
{
    public class AccountLogin
    {
        #region Constructors

        public AccountLogin(string value)
        {
            if (!IsInCorrectFormat(value))
                throw new ArgumentException();

            RawValue = value;
            Load(RawValue);
        }

        #endregion

        #region Properties

        public bool IsEmail { get; protected set; }
        public bool IsPhoneNumber { get; protected set; }

        public string Email { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string RawValue { get; protected set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return string.Format("{0}:{1}",
                IsEmail ? "E" : "P"
                , IsEmail ? Email : PhoneNumber);
        }

        private void Load(string rawValue)
        {
            IsEmail = IsPhoneNumber = false;
            PhoneNumber = string.Empty;
            Email = string.Empty;

            char firstChar = char.ToLower(rawValue[0]);
            if (firstChar == 'p')
            {
                IsPhoneNumber = true;
                PhoneNumber = rawValue.Substring(2);
            }
            else if (firstChar == 'e')
            {
                IsEmail = true;
                Email = rawValue.Substring(2);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private bool IsInCorrectFormat(string value)
        {
            string startWith = value.Substring(0, 2).ToLower();
            return (startWith == "p:" || startWith == "e:");
        }

        #endregion

    }
}
