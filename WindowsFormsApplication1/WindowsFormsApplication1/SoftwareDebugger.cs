using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SoftwareDebuggerSolution {

	public class SoftwareDebugger {

		public enum ArduinoPort {

			port2,
			port3,
			port4,
			port5,
			port6,
			port7,
			//port8,
			//port9,
			//port10,
			//port11,
			//port12,
			//port13,
			portA0,
			portA1,
			portA2,
			portA3,
			//portA4,
			//portA5,

		}

		public enum TransistorPort {

			port0_0,
			port0_1,
			port0_2,
			port0_3,
			port0_4,
			port0_5,
			port0_6,
			port0_7,
			port1_0,
			port1_1,
			port1_2,
			port1_3,
			port1_4,
			port1_5,
			port1_6,
			port1_7,

		}

		public enum RegistorPort {

			port0_1,
			port0_2,
			port0_3,
			port0_4,
			port0_5,
			port0_6,
			port1_1,
			port1_2,
			port1_3,
			port1_4,
			port1_5,
			port1_6,

		}

		public enum VoltageLevel {
			High,
			Low
		}

		public enum PortDirection {
			INPUT,
			OUTPUT,
		}

		VirtualTransistorIC virtualTransistor = new VirtualTransistorIC(0x20);

		VirtualResistorIC virtualResistor_0 = new VirtualResistorIC(Arduino.PinType.pin10);
		VirtualResistorIC virtualResistor_1 = new VirtualResistorIC(Arduino.PinType.pin8);

		public SoftwareDebugger() {



		}

		public void OpenConnection(string portName) {

			Arduino.Serial.PortName = portName;
			Arduino.Serial.Open();
		}

		public void CloseConnection() {
			Arduino.Serial.Close();
		}

		public void Init() {

		}

		public void pinMode(ArduinoPort port, PortDirection direction) {

		}

		public void digitalWrite(ArduinoPort port, VoltageLevel level) {

		}

		public void analogWrite(ArduinoPort port, byte voltage) {

		}

		public void transistorWrite(TransistorPort port, VoltageLevel level) {

		}

		public void registorWrite(RegistorPort port, byte regist) {

		}

	}
}
