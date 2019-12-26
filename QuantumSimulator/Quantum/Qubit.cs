using System;
using System.Collections.Generic;
using System.Numerics;
using QuantumSimulator.Enums;

namespace QuantumSimulator.Quantum {
    public class Qubit {
        private Dictionary<State, Complex> _states;

        public Qubit() {
            _states = new Dictionary<State, Complex>();
            _states.Add(State.Zero, 1);
            _states.Add(State.One, 0);
        }

        public Qubit(Complex zeroCoef, Complex oneCoef) {
            if (zeroCoef * zeroCoef + oneCoef * oneCoef != 1) {
                throw new ArgumentException("Squares of coefficients does not sum to 1!");
            }
            _states.Add(State.Zero, zeroCoef);
            _states.Add(State.One, oneCoef);
        }

        public Qubit(Complex oneCoef) {
            var zeroCoef = Complex.Sqrt(1 - oneCoef*oneCoef);
            _states.Add(State.Zero, zeroCoef);
            _states.Add(State.One, oneCoef);
        }
    }
}