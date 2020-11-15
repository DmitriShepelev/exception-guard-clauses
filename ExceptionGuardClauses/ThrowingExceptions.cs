using System;
using System.Globalization;

namespace ExceptionGuardClauses
{
    public static class ThrowingExceptions
    {
        public static int ConvertHexCharToInteger(char c)
        {
            if (int.TryParse($"{c}", NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int result))
            {
                return result;
            }

            throw new ArgumentException("c is not a hex char.");
        }

        public static char GetLastCharacter(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException($"{nameof(str)} is null.");
            }

            return str[^1];
        }

        public static string GenerateUserCode(string code, int day)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException($"{nameof(code)} is null.");
            }

            if (code.Length != 4)
            {
                throw new ArgumentException($"{nameof(code)} has {code.Length} chars.");
            }

            if (day <= 0 || day >= 100)
            {
                throw new ArgumentOutOfRangeException($"{nameof(day)} should be greater than zero and less than 100");
            }

            return code + day.ToString(CultureInfo.InvariantCulture);
        }

        public static string GenerateGreeting(string hello, string[] addressee, int index)
        {
            if (string.IsNullOrEmpty(hello))
            {
                throw new ArgumentNullException($"{nameof(hello)} is null.");
            }

            if (addressee is null)
            {
                throw new ArgumentNullException($"{nameof(addressee)} is null.");
            }

            if (addressee.Length == 0)
            {
                throw new ArgumentException($"array is empty");
            }

            if (index < 0 || index >= addressee.Length)
            {
                throw new ArgumentOutOfRangeException($"{index} is out of range");
            }

            return $"{hello}, {addressee[index]}!";
        }

        public static string GetArrayValue(int[] indexArray, int indexArrayPosition, string[] valueArray)
        {
            if (indexArray is null)
            {
                throw new ArgumentNullException($"{nameof(indexArray)} is null");
            }

            if (indexArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(indexArray)} is empty.");
            }

            if (valueArray is null)
            {
                throw new ArgumentNullException($"{nameof(valueArray)} is null");
            }

            if (valueArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(valueArray)} is empty.");
            }

            if (indexArrayPosition < 0 || indexArrayPosition >= indexArray.Length)
            {
#pragma warning disable S112 // General exceptions should never be thrown
#pragma warning disable CA2201 // Do not raise reserved exception types
                throw new IndexOutOfRangeException($"{nameof(indexArrayPosition)} is out of range.");
#pragma warning restore CA2201 // Do not raise reserved exception types
#pragma warning restore S112 // General exceptions should never be thrown
            }

            int position = indexArray[indexArrayPosition];

            if (position < 0 || position >= valueArray.Length)
            {
#pragma warning disable CA2201 // Do not raise reserved exception types
#pragma warning disable S112 // General exceptions should never be thrown
                throw new IndexOutOfRangeException("position is out of range.");
#pragma warning restore S112 // General exceptions should never be thrown
#pragma warning restore CA2201 // Do not raise reserved exception types
            }

            return valueArray[position];
        }
    }
}
