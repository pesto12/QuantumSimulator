using System;
using System.Collections.Generic;
using QuantumSimulator.Quantum;
using QuantumSimulator.Quantum.Gates;
using Xunit;

namespace QuantumSimulatorTest {
    public class UnitTest1 {
        [Fact]
        public void Test1() {
            var register = new Register(1);
            register.ApplyGate(new HadamardGate(), new List<int> { 0 });
        }
    }
}