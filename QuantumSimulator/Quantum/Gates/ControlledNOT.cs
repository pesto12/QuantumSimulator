using MathNet.Numerics.LinearAlgebra;
using System.Numerics;

namespace QuantumSimulator.Quantum.Gates {
    public class ControlledNOT : Gate {
        public ControlledNOT() {
            this.transformMatrix = Matrix<Complex>.Build.Sparse(4, 4, 0);

            transformMatrix[0, 0] = 1;
            transformMatrix[1, 1] = 1;
            transformMatrix[2, 3] = 1;
            transformMatrix[3, 2] = 1;
        }
    }
}