using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_4
{
    internal class MyString
    {
        private char[] arrayChars;
        public int Length => this.arrayChars.Length;

        public MyString(string _string)
        {
            this.arrayChars = _string.ToCharArray();
        }

        public MyString(char[] arrayChars)
        {
            this.arrayChars = arrayChars;
        }

        public static explicit operator char[] (MyString myString)
        {
            char[] newCharArray = new char[myString.Length];
            Array.Copy(myString.arrayChars, newCharArray, myString.Length);
            return newCharArray;
        }

        public static explicit operator MyString(char[] arrayChars)
        {
            MyString newMyString = new MyString(arrayChars);
            return newMyString;
        }

        public static MyString operator +(MyString firstMyString, MyString secondMyString)
        {
            char[] masForConcat = new char[firstMyString.Length + secondMyString.Length];

            Array.Copy(firstMyString.arrayChars, masForConcat, firstMyString.Length);

            Array.Copy(secondMyString.arrayChars, 0, masForConcat, firstMyString.Length, secondMyString.Length);

            return new MyString(masForConcat);
        }

        public override string ToString()
        {
            return new string(this.arrayChars);
        }

        public char[] ToCharArray()
        {
            char[] arrayCharsCopy = new char[arrayChars.Length];
            Array.Copy(arrayChars, arrayCharsCopy, arrayCharsCopy.Length);
            return arrayCharsCopy;
        }

        public int IndexOf(char itemFinding)
        {
            return Array.IndexOf(arrayChars, itemFinding);
        }

        public int CompareTo(object obj)
        {
            MyString stringForEquals = obj as MyString;

            if (stringForEquals.Length < arrayChars.Length)
            {
                return -1;
            }

            if (stringForEquals.Length > arrayChars.Length)
            {
                return 1;
            }

            for (int i = 0; i < arrayChars.Length; i++)
            {
                if (arrayChars[i] > stringForEquals.arrayChars[i])
                    return 1;
                if (arrayChars[i] < stringForEquals.arrayChars[i])
                    return -1;
            }
            return 0;
        }

        public static int operator <(MyString firstMyString, MyString secondMyString)
        {
            return firstMyString.CompareTo(secondMyString);
        }

        public static int operator >(MyString firstMyString, MyString secondMyString)
        {
            return secondMyString.CompareTo(firstMyString);
        }

        public override int GetHashCode()
        {
            return arrayChars.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MyString stringForEquals = obj as MyString;
            return (stringForEquals.CompareTo(obj) == 0);
        }

        public char this[int i]
        {
            get
            {
                return arrayChars[i];
            }
            set
            {
                arrayChars[i] = value;
            }
        }
    }
}