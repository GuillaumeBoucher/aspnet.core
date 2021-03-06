﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LiteDB
{
    internal class ExpressionOperators
    {
        /// <summary>
        /// Add two number values. If any side are string, concat left+right as string. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> ADD(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                // if any side are string, concat
                if (value.First.IsString || value.Second.IsString)
                {
                    yield return value.First.RawValue?.ToString() + value.Second.RawValue?.ToString();
                }
                else if (!value.First.IsNumber || !value.Second.IsNumber)
                {
                    continue;
                }
                else
                {
                    yield return value.First + value.Second;
                }
            }
        }

        /// <summary>
        /// Minus two number values. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> MINUS(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                if (!value.First.IsNumber || !value.Second.IsNumber) continue;

                yield return value.First - value.Second;
            }
        }

        /// <summary>
        /// Multiply two number values. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> MULTIPLY(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                if (!value.First.IsNumber || !value.Second.IsNumber) continue;

                yield return value.First * value.Second;
            }
        }

        /// <summary>
        /// Divide two number values. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> DIVIDE(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                if (!value.First.IsNumber || !value.Second.IsNumber) continue;

                yield return value.First / value.Second;
            }
        }

        /// <summary>
        /// Mod two number values. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> MOD(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                if (!value.First.IsNumber || !value.Second.IsNumber) continue;

                yield return value.First % value.Second;
            }
        }

        /// <summary>
        /// Test if left and right are same value. Returns true or false. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> EQ(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                yield return value.First == value.Second;
            }
        }

        /// <summary>
        /// Test if left and right are not same value. Returns true or false. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> NEQ(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                yield return value.First != value.Second;
            }
        }

        /// <summary>
        /// Test if left is greater than right value. Returns true or false. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> GT(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                yield return value.First > value.Second;
            }
        }

        /// <summary>
        /// Test if left is greater or equals than right value. Returns true or false. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> GTE(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                yield return value.First >= value.Second;
            }
        }

        /// <summary>
        /// Test if left is less than right value. Returns true or false. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> LT(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                yield return value.First < value.Second;
            }
        }

        /// <summary>
        /// Test if left is less or equals than right value. Returns true or false. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> LTE(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                yield return value.First <= value.Second;
            }
        }

        /// <summary>
        /// Test left AND right value. Returns true or false. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> AND(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                yield return value.First && value.Second;
            }
        }

        /// <summary>
        /// Test left OR right value. Returns true or false. Support multiples values
        /// </summary>
        public static IEnumerable<BsonValue> OR(IEnumerable<BsonValue> left, IEnumerable<BsonValue> right)
        {
            foreach (var value in left.ZipValues(right))
            {
                yield return value.First || value.Second;
            }
        }
    }
}
