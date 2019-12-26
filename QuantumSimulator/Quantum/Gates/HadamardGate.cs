using MathNet.Numerics.LinearAlgebra;
using System.Numerics;

namespace QuantumSimulator.Quantum.Gates {
    public class HadamardGate : Gate {
        public HadamardGate() {
            this.transformMatrix = Matrix<Complex>.Build.Sparse(2,2,0);
            Complex c = 1/Complex.Sqrt(2);

            transformMatrix[0,0] = c;
            transformMatrix[0,1] = c;
            transformMatrix[1,0] = c;
            transformMatrix[1,1] = -c;
        }
    }
}