using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareDebuggerSolution
{
	public interface IDigitalOutput<TPinName>
	{
		TPinName PinName { get; set; }

		void SetDirection(bool direction);
		void SetLevel(bool level);

	}
}