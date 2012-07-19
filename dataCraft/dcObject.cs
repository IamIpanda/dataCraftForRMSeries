using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace dataCraft
{
	public class dcObject : dcData
	{
		protected Dictionary<dcSymbol,dcData> variables = new Dictionary<dcSymbol,dcData>();
		public dcData this[string name]
		{
            get
            {
            	return get_variables(dcSymbol.allocate(name));
            }
            set 
            {
            	set_variables(dcSymbol.allocate(name),value);
            }
		}
		public Dictionary<dcSymbol,dcData> get_all_variables()
		{
            return variables;
		}
		public dcData get_variables(dcSymbol name)
		{
			if(variables.ContainsKey(name))
			{
				return variables[name];
			}
			else
			{
				return dcNil.Nil;
			}
		}
		public bool set_variables(dcSymbol name,dcData value)
		{
			if(variables.ContainsKey(name))
			{
				variables[name] = value;
				return true;
			}
			else
			{
				variables.Add(name,value);
				return false;
			}
		}
		dcSymbol trueName = dcSymbol.allocate(""); 
		public string Name
		{
			get
			{
				return trueName.Value;
			}
			set
			{
				trueName = dcSymbol.allocate(value);
			}
		}
		public dcSymbol NameInSymbol
		{
			get
			{
				return trueName;
			}
			set
			{
				trueName = value;
			}
		}
        public override String ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("dcObject : ");
            b.AppendLine(Name);
            if (variables.Count == 0)
                return b.ToString();
            b.AppendLine("<");
            foreach (dcSymbol sym in variables.Keys)
            {
                b.Append(sym.Value);
                b.Append(" = ");
                b.AppendLine(variables[sym].ToString());
            }
            b.Append(">");
            return b.ToString();
        }
        public virtual object Clone()
        {
        	dcObject newone = new dcObject();
            CloneTo(newone);
        	return newone;
        }
        protected dcObject CloneTo(dcObject dc)
        {
            dc.NameInSymbol = this.NameInSymbol;
            foreach (dcSymbol sym in variables.Keys)
            {
                dc.set_variables(sym, variables[sym].Clone() as dcData);
            }
            return dc;
        }
        public virtual void Clear()
        {
 			Name = "";
 			foreach(dcData data in variables.Values)
 			{
 				data.Clear();
 			}
        }
	}
}