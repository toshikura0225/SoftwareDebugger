using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public interface IDigitalOutput<TPinType>
	{
		TPinType PinName { get; set; }

		void SetDirection(bool direction);
		void SetLevel(bool level);

	}
}