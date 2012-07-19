using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace dataCraft
{
	public interface FileCross
	{
		bool Write(dcData data);
		dcData Read();
	}
}