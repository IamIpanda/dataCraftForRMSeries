using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace dataCraft
{
	public class dcSymbol : dcData
	{
		static Dictionary<string,dcSymbol> Symbols = new Dictionary<string,dcSymbol>();
        static public dcSymbol allocate(String Value)
        {
            if (Symbols.ContainsKey(Value))
            {
                return Symbols[Value];
            }
            else
            {
                return new dcSymbol(Value);
            }
        }
        static public Dictionary<string, dcSymbol> all_symbols()
        {
            return Symbols;
        }
        dcSymbol(String value)
        {
            this.value = value;
            Symbols.Add(value, this);
        }
		string value;
        public override string ToString()
        {
            return ":" + value;
        }
		public string Value
		{
            get { return value; }
		}
		public object Clone()
		{
			return this;
		}
		public void Clear(){} // 什么都不做
	}
}