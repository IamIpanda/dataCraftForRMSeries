using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace dataCraft
{
	sealed public class dcNil : dcData
	{
        static private dcNil _Nil = new dcNil();

        public static dcNil Nil
        {
            get { return dcNil._Nil; }
        }
		public override string ToString() { return "dcNil"; }
		public object Clone() { return this; }
		public void Clear(){} // 什么都不做
        private dcNil() { }
	}
}