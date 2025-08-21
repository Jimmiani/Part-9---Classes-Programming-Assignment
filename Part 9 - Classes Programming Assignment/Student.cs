using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_9___Classes_Programming_Assignment
{
    internal class Student
    {
        private static Random generator = new Random();
        private string _firstName;
        private string _lastName;
        private int _studentNumber;
        private string _email;
        private int _fNameEmail, _lNameEmail;

        public Student(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _studentNumber = generator.Next(0, 1000) + 555000;
            GenerateEmail();
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; GenerateEmail(); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; GenerateEmail(); }
        }

        public int StudentNumber
        {
            get { return _studentNumber; }
        }

        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }

        public void ResetStudentNumber(int oldNum)
        {
            _studentNumber = generator.Next(0, 1000) + 555000;
            while (_studentNumber == oldNum)
            {
                _studentNumber = generator.Next(0, 1000) + 555000;
            }
            GenerateEmail();
        }
        public string Email
        {
            get { return _email; }
        }

        private void GenerateEmail()
        {
            for (int i = 0; i <= _firstName.Length; i++)
            {
                _fNameEmail = i;
                if (_fNameEmail >= 3)
                {
                    break;
                }
            }
            for (int i = 0; i <= _lastName.Length; i++)
            {
                _lNameEmail = i;
                if (_lNameEmail >= 3)
                {
                    break;
                }
            }
            _email = _firstName.Substring(0, _fNameEmail) + _lastName.Substring(0, _lNameEmail) + _studentNumber.ToString().Substring(_studentNumber.ToString().Length - 3, 3) + "@ICS4U.com";
        }
    }
}
