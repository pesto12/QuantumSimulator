using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using QuantumSimulator.Enums;
using QuantumSimulator.Quantum.Gates;

namespace QuantumSimulator.Quantum {
    public class Register {
        public int Size { get; protected set; }
        private Vector<Complex> _states;

        public Register(int size) {
            Size = size;
            _states = DenseVector.Build.Sparse((int) Math.Pow(2, size), 0);
            _states[0] = 1;
        }

        public void set_states(IEnumerable<Complex> states) {
            //todo : add check
            _states = DenseVector.OfArray(states.ToArray());
        }

        public void ApplyGate(Gate gate, IEnumerable<int> qubitIndexes) {
            //todo: add check

            var localStates = DenseVector.Build.Sparse((int)Math.Pow(2,  qubitIndexes.Count()), 0);
            var involvedStates = new List<KeyValuePair<int, int>>();
            for (var localState = 0; localState < localStates.Count(); localState++) {
                var probability = 0.0;
                for (var state = 0; state < _states.Count(); state++) {
                    bool stateContains = true;
                    for (int qubitIndex = 0; qubitIndex < qubitIndexes.Count(); qubitIndex++) {
                        if (getQubit(state, qubitIndexes.ElementAt(qubitIndex)) != getQubit(localState, qubitIndex)) {
                            stateContains = false;
                        }
                    }
                    if (stateContains) {
                        probability += Math.Pow(Complex.Abs(_states[state]), 2);
                        involvedStates.Add(new KeyValuePair<int, int>(state, localState));
                    }
                }
                localStates[localState] = Complex.Sqrt(probability);
            }

            foreach (var elem in involvedStates) {
                if(localStates[elem.Value] != new Complex(0,0))
                    _states[elem.Key] = (_states[elem.Key] * _states[elem.Key]) / (localStates[elem.Value] * localStates[elem.Value]);
            }

            var newLocalStates = (gate.transformMatrix * localStates.ToColumnMatrix()).Column(0);

            foreach (var elem in involvedStates) {
                _states[elem.Key] = (_states[elem.Key] * _states[elem.Key]) * (newLocalStates[elem.Value] * newLocalStates[elem.Value]);
            }

        }

        private State getQubit(int state, int position) {
            if ((state & (1 << position)) != 0) {
                return State.One;
            } else {
                return State.Zero;
            }
        }
    }
}