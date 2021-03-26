using System;

namespace ECommerce.Domain.DomainHelpers
{

    public class PositiveNumber<T> where T : struct, IComparable<T>

    {
        public PositiveNumber(T value)
        {

            if (value.GetType() == typeof(int) && Convert.ToInt32(value) < 0
                || value.GetType() == typeof(double)
                && Convert.ToDouble(value) < 0
                || value.GetType() == typeof(decimal)
                && Convert.ToDecimal(value) < 0)
            {
                throw new InvalidOperationException(nameof(value) + "Should not be negative!");
            }

            Value = value;
        }

        public T Value { get; }

        public static implicit operator PositiveNumber<T>(T value) => new PositiveNumber<T>(value);
        public static implicit operator T(PositiveNumber<T> value) => value.Value;
    }
}
