using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace dataCraft
{
	abstract public class dcBaseTypeEx<T> : dcObject,dcDataWithTrueValue<T>
        where T:dcData
	{
        T value;
        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
        public dcBaseTypeEx(T value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Value.ToString());
            sb.AppendLine("With:");
            sb.Append(base.ToString());
            return sb.ToString();
        }
        public override void Clear()
        {
            value.Clear();
            base.Clear();
        }
        public bool IsPure()
        {
            return (variables.Count == 0 ? true : false);
        }
        public abstract override object Clone();
        
	}

    public class dcStringEx : dcBaseTypeEx<dcString>
    {
        public dcStringEx(dcString dcs) : base(dcs) { }
        public override object Clone()
        {
            dcStringEx dcse = new dcStringEx(this.Value);
            CloneTo(dcse);
            return dcse;
        }
    }
    public class dcHashEx : dcBaseTypeEx<dcHash>
    {
        public dcHashEx(dcHash dch) : base(dch) { }
        public override object Clone()
        {
            dcHashEx dche = new dcHashEx(this.Value);
            CloneTo(dche);
            return dche;
        }
    }
    public class dcRegexpEx : dcBaseTypeEx<dcRegexp>
    {
        public dcRegexpEx(dcRegexp dcr) : base(dcr) { }
        public override object Clone()
        {
            dcRegexpEx dcre = new dcRegexpEx(this.Value);
            CloneTo(dcre);
            return dcre;
        }
    }
    public class dcArrayEx : dcBaseTypeEx<dcArray>
    {
        public dcArrayEx(dcArray dca) : base(dca) { }
        public override object Clone()
        {
            dcArrayEx dcae = new dcArrayEx(this.Value);
            CloneTo(dcae);
            return dcae;
        }
    }

}