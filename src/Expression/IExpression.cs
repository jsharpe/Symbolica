﻿using System.Numerics;

namespace Symbolica.Expression
{
    public interface IExpression
    {
        Bits Size { get; }
        BigInteger Integer { get; }

        IExpression GetValue(ISpace space);
        IProposition GetProposition(ISpace space);
        IExpression Add(IExpression expression);
        IExpression And(IExpression expression);
        IExpression ArithmeticShiftRight(IExpression expression);
        IExpression Equal(IExpression expression);
        IExpression FloatAdd(IExpression expression);
        IExpression FloatCeiling();
        IExpression FloatConvert(Bits size);
        IExpression FloatDivide(IExpression expression);
        IExpression FloatEqual(IExpression expression);
        IExpression FloatFloor();
        IExpression FloatGreater(IExpression expression);
        IExpression FloatGreaterOrEqual(IExpression expression);
        IExpression FloatLess(IExpression expression);
        IExpression FloatLessOrEqual(IExpression expression);
        IExpression FloatMultiply(IExpression expression);
        IExpression FloatNegate();
        IExpression FloatNotEqual(IExpression expression);
        IExpression FloatOrdered(IExpression expression);
        IExpression FloatRemainder(IExpression expression);
        IExpression FloatSubtract(IExpression expression);
        IExpression FloatToSigned(Bits size);
        IExpression FloatToUnsigned(Bits size);
        IExpression FloatUnordered(IExpression expression);
        IExpression LogicalShiftRight(IExpression expression);
        IExpression Multiply(IExpression expression);
        IExpression NotEqual(IExpression expression);
        IExpression Or(IExpression expression);
        IExpression Read(IExpression offset, Bits size);
        IExpression Select(IExpression trueValue, IExpression falseValue);
        IExpression ShiftLeft(IExpression expression);
        IExpression SignedDivide(IExpression expression);
        IExpression SignedGreater(IExpression expression);
        IExpression SignedGreaterOrEqual(IExpression expression);
        IExpression SignedLess(IExpression expression);
        IExpression SignedLessOrEqual(IExpression expression);
        IExpression SignedRemainder(IExpression expression);
        IExpression SignedToFloat(Bits size);
        IExpression SignExtend(Bits size);
        IExpression Subtract(IExpression expression);
        IExpression Truncate(Bits size);
        IExpression UnsignedDivide(IExpression expression);
        IExpression UnsignedGreater(IExpression expression);
        IExpression UnsignedGreaterOrEqual(IExpression expression);
        IExpression UnsignedLess(IExpression expression);
        IExpression UnsignedLessOrEqual(IExpression expression);
        IExpression UnsignedRemainder(IExpression expression);
        IExpression UnsignedToFloat(Bits size);
        IExpression Write(IExpression offset, IExpression value);
        IExpression Xor(IExpression expression);
        IExpression ZeroExtend(Bits size);
    }
}
