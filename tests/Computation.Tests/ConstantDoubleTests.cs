﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Z3;
using Symbolica.Expression;
using Xunit;

namespace Symbolica.Computation
{
    public class ConstantDoubleTests
    {
        private static readonly Context Context = new();

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatAdd(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatAdd(constantRight).GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicLeft.FloatAdd(symbolicRight).GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(UnaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatCeiling(
            ConstantDouble constantExpression,
            SymbolicFloat symbolicExpression)
        {
            var constant = constantExpression.FloatCeiling().GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicExpression.FloatCeiling().GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(FloatConvertTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatConvert(Bits size,
            ConstantDouble constantExpression,
            SymbolicFloat symbolicExpression)
        {
            var constant = constantExpression.FloatConvert(size).GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicExpression.FloatConvert(size).GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatDivide(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatDivide(constantRight).GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicLeft.FloatDivide(symbolicRight).GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatEqual(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatEqual(constantRight).GetInteger(Context);
            var symbolic = symbolicLeft.FloatEqual(symbolicRight).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(UnaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatFloor(
            ConstantDouble constantExpression,
            SymbolicFloat symbolicExpression)
        {
            var constant = constantExpression.FloatFloor().GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicExpression.FloatFloor().GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatGreater(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatGreater(constantRight).GetInteger(Context);
            var symbolic = symbolicLeft.FloatGreater(symbolicRight).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatGreaterOrEqual(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatGreaterOrEqual(constantRight).GetInteger(Context);
            var symbolic = symbolicLeft.FloatGreaterOrEqual(symbolicRight).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatLess(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatLess(constantRight).GetInteger(Context);
            var symbolic = symbolicLeft.FloatLess(symbolicRight).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatLessOrEqual(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatLessOrEqual(constantRight).GetInteger(Context);
            var symbolic = symbolicLeft.FloatLessOrEqual(symbolicRight).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatMultiply(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatMultiply(constantRight).GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicLeft.FloatMultiply(symbolicRight).GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(UnaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatNegate(
            ConstantDouble constantExpression,
            SymbolicFloat symbolicExpression)
        {
            var constant = constantExpression.FloatNegate().GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicExpression.FloatNegate().GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatNotEqual(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatNotEqual(constantRight).GetInteger(Context);
            var symbolic = symbolicLeft.FloatNotEqual(symbolicRight).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatOrdered(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatOrdered(constantRight).GetInteger(Context);
            var symbolic = symbolicLeft.FloatOrdered(symbolicRight).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatRemainder(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatRemainder(constantRight).GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicLeft.FloatRemainder(symbolicRight).GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatSubtract(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatSubtract(constantRight).GetDoubleNanNormalizedInteger(Context);
            var symbolic = symbolicLeft.FloatSubtract(symbolicRight).GetDoubleNanNormalizedInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(FloatToSignedTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatToSigned(Bits size,
            ConstantDouble constantExpression,
            SymbolicFloat symbolicExpression)
        {
            var constant = constantExpression.FloatToSigned(size).GetInteger(Context);
            var symbolic = symbolicExpression.FloatToSigned(size).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(FloatToUnsignedTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatToUnsigned(Bits size,
            ConstantDouble constantExpression,
            SymbolicFloat symbolicExpression)
        {
            var constant = constantExpression.FloatToUnsigned(size).GetInteger(Context);
            var symbolic = symbolicExpression.FloatToUnsigned(size).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        [Theory]
        [ClassData(typeof(BinaryTestData))]
        private void ShouldCreateEquivalentConstantAndSymbolicValuesForFloatUnordered(
            ConstantDouble constantLeft, ConstantDouble constantRight,
            SymbolicFloat symbolicLeft, SymbolicFloat symbolicRight)
        {
            var constant = constantLeft.FloatUnordered(constantRight).GetInteger(Context);
            var symbolic = symbolicLeft.FloatUnordered(symbolicRight).GetInteger(Context);

            constant.Should().Be(symbolic);
        }

        private sealed class UnaryTestData : TheoryData<
            ConstantDouble,
            SymbolicFloat>
        {
            public UnaryTestData()
            {
                foreach (var value in Values())
                    Add(new ConstantDouble(value),
                        new SymbolicFloat((Bits) 64U, c => c.MkFP(value, c.MkFPSort64())));
            }

            private static IEnumerable<double> Values()
            {
                yield return 0d;
                yield return double.Epsilon;
                yield return double.NaN;
                yield return double.NegativeInfinity;
                yield return double.MinValue;
                yield return double.MaxValue;
                yield return double.PositiveInfinity;

                foreach (var i in Enumerable.Range(-10, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }

                foreach (var i in Enumerable.Range(1, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }
            }
        }

        private sealed class BinaryTestData : TheoryData<
            ConstantDouble, ConstantDouble,
            SymbolicFloat, SymbolicFloat>
        {
            public BinaryTestData()
            {
                foreach (var left in Values())
                foreach (var right in Values())
                    Add(new ConstantDouble(left),
                        new ConstantDouble(right),
                        new SymbolicFloat((Bits) 64U, c => c.MkFP(left, c.MkFPSort64())),
                        new SymbolicFloat((Bits) 64U, c => c.MkFP(right, c.MkFPSort64())));
            }

            private static IEnumerable<double> Values()
            {
                yield return 0d;
                yield return double.Epsilon;
                yield return double.NaN;
                yield return double.NegativeInfinity;
                yield return double.MinValue;
                yield return double.MaxValue;
                yield return double.PositiveInfinity;

                foreach (var i in Enumerable.Range(-10, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }

                foreach (var i in Enumerable.Range(1, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }
            }
        }

        private sealed class FloatConvertTestData : TheoryData<Bits,
            ConstantDouble,
            SymbolicFloat>
        {
            public FloatConvertTestData()
            {
                foreach (var size in Sizes())
                foreach (var value in Values())
                    Add(size,
                        new ConstantDouble(value),
                        new SymbolicFloat((Bits) 64U, c => c.MkFP(value, c.MkFPSort64())));
            }

            private static IEnumerable<Bits> Sizes()
            {
                yield return (Bits) 16U;
                yield return (Bits) 32U;
                yield return (Bits) 64U;
                yield return (Bits) 80U;
                yield return (Bits) 128U;
            }

            private static IEnumerable<double> Values()
            {
                yield return 0d;
                yield return double.Epsilon;
                yield return double.NaN;
                yield return double.NegativeInfinity;
                yield return double.MinValue;
                yield return double.MaxValue;
                yield return double.PositiveInfinity;

                foreach (var i in Enumerable.Range(-10, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }

                foreach (var i in Enumerable.Range(1, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }
            }
        }

        private sealed class FloatToSignedTestData : TheoryData<Bits,
            ConstantDouble,
            SymbolicFloat>
        {
            public FloatToSignedTestData()
            {
                foreach (var size in Sizes())
                foreach (var value in Values())
                    Add(size,
                        new ConstantDouble(value),
                        new SymbolicFloat((Bits) 64U, c => c.MkFP(value, c.MkFPSort64())));
            }

            private static IEnumerable<Bits> Sizes()
            {
                yield return (Bits) 16U;
                yield return (Bits) 32U;
                yield return (Bits) 64U;
                yield return (Bits) 80U;
                yield return (Bits) 128U;
            }

            private static IEnumerable<double> Values()
            {
                yield return 0d;
                yield return double.Epsilon;

                foreach (var i in Enumerable.Range(-10, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }

                foreach (var i in Enumerable.Range(1, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }
            }
        }

        private sealed class FloatToUnsignedTestData : TheoryData<Bits,
            ConstantDouble,
            SymbolicFloat>
        {
            public FloatToUnsignedTestData()
            {
                foreach (var size in Sizes())
                foreach (var value in Values())
                    Add(size,
                        new ConstantDouble(value),
                        new SymbolicFloat((Bits) 64U, c => c.MkFP(value, c.MkFPSort64())));
            }

            private static IEnumerable<Bits> Sizes()
            {
                yield return (Bits) 16U;
                yield return (Bits) 32U;
                yield return (Bits) 64U;
                yield return (Bits) 80U;
                yield return (Bits) 128U;
            }

            private static IEnumerable<double> Values()
            {
                yield return 0d;
                yield return double.Epsilon;

                foreach (var i in Enumerable.Range(1, 10))
                {
                    yield return i / 3d;
                    yield return 3d / i;
                }
            }
        }
    }
}
