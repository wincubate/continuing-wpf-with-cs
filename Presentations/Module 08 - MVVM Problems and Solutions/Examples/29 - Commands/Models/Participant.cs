using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace Wincubate.MvvmSolutions.Slide29
{
    public class Participant : ValidatableModelBase
    {
        [Required]
        [StringLength(10)]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _firstName;

        [Required]
        [StringLength(20)]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _lastName;

        //[Required]
        //[EmailAddress]
        public string Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _email;

        //[Required]
        //[EmailAddress]
        [CustomValidation(typeof(Participant), "IdenticalEmailValidate")]
        public string RepeatEmail
        {
            get { return _repeatEmail; }
            set
            {
                if (value != _repeatEmail)
                {
                    _repeatEmail = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _repeatEmail;

        #region Validation

        public static ValidationResult IdenticalEmailValidate(object o, ValidationContext context)
        {
            Participant p = context.ObjectInstance as Participant;
            if (string.Compare(p.Email.ToLower(), p.RepeatEmail.ToLower(), true) != 0)
            {
                return new ValidationResult(
                   "Non-identical email addresses entered",
                   new List<string> { "Email", "RepeatEmail" }
                );
            }

            return ValidationResult.Success;
        }

        #endregion
    }
}
