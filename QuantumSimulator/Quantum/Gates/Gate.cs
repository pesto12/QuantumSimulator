using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace QuantumSimulator.Quantum.Gates {
    public abstract class Gate {
        public Matrix<Complex> transformMatrix { get; protected set; }
    }
}