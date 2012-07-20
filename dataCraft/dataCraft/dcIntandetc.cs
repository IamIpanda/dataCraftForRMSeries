using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace dataCraft
{
    public class dcInt : dcDataWithTrueValueBase<long>
    {
        public dcInt(long i): base(i) { }
        public override void Clear()
        {
            value = 0;
        }
        public override object Clone()
        {
            return new dcInt(value);
        }
    }
    // 结构不佳 准备重构
    public class dcBool : dcDataWithTrueValueBase<bool>
    {
        public dcBool(bool b): base(b) { }
        public override void Clear()
        {
            value = false;
        }
        public override object Clone()
        {
            return this;
        }
        public override bool Equals(object obj)
        {
            if (obj is dcBool)
            {
                return value.Equals((obj as dcBool).Value);
            }
            if ((bool)obj)
                return value ? true : false;
            else
                return value ? false : true;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
    public class dcRegexp : dcDataWithTrueValueBase<Regex>
    {
        public dcRegexp(Regex r) : base(r) { }
        public override void Clear()
        {
            value = new Regex("");
        }
        public override object Clone()
        {
            return new dcRegexp(new Regex(value.ToString(), value.Options));
        }
    }
	public class dcFloat : dcDataWithTrueValueBase<double>
	{        
        public dcFloat(double i) : base(i) { }
        public override void Clear()
		{
			value = 0.0;
		}
        public override object Clone()
        {
            return new dcFloat(value);    
        }
	}
	public class dcRect : dcDataWithTrueValueBase<Rectangle>
	{
        public dcRect(Rectangle r) : base(r) { }
        public override void Clear()
		{
			value = new Rectangle();
		}
        public override object Clone()
        {
            return new dcRect(new Rectangle(value.X, value.Y, value.Width, Value.Height));
        }
	}
	public class dcColor : dcDataWithTrueValueBase<Color>
	{
        public dcColor(Color c) : base(c) { }
        public override void Clear()
		{
			value = Color.FromArgb(0,0,0,0);
		}
        public override object Clone()
        {
            return new dcColor(Color.FromArgb(value.A, value.R, value.G, value.B));
        }
	}
	public class dcString : dcDataWithTrueValueBase<string>
	{
        public dcString(String s) : base(s) { }
        public override void Clear()
		{
			value = "";
		}
        public override object Clone()
        {
            return new dcString(value.Clone() as string);
        }
	}
	public class dcArray : dcDataWithTrueValueBase<List<dcData>>
	{
        public dcArray(List<dcData> l) : base(l) { }
        public override void Clear()
		{
			value.Clear();
		}
        public override object Clone()
        {
            List<dcData> newone = new List<dcData>();
            foreach (dcData data in value)
            {
                newone.Add(data.Clone() as dcData);
            }
            return newone;
        }
        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("dcArray [");
            b.Append(value.Count);
            b.Append("]");
            if (value.Count == 0)
                return b.ToString();
            b.AppendLine();
            b.Append("[");
            foreach (dcData data in value)
            {
                b.Append(data.ToString());
                b.Append(",");
            }
            b.Remove(b.Length - 1, 1);
            b.Append("]");
            return b.ToString();
        }
	}
	public class dcHash : dcDataWithTrueValueBase<Dictionary<dcData,dcData>>
	{
        public dcHash(Dictionary<dcData, dcData> d) : base(d) { }
        public override void Clear()
		{
			value.Clear();
		}
        public override object Clone()
        {
            Dictionary<dcData, dcData> newone = new Dictionary<dcData, dcData>();
            foreach (dcData data in value.Keys)
            {
                newone.Add(data.Clone() as dcData,value[data].Clone() as dcData);
            }
            return newone;
        }
        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("dcHash [");
            b.Append(value.Count);
            b.Append("]");
            if (value.Count == 0)
                return b.ToString();
            b.AppendLine();
            b.Append("{");
            foreach (dcData data in value.Keys)
            {
                b.Append(data.ToString());
                b.Append(" => ");
                b.Append(value[data].ToString());
                b.Append(",");
            }
            b.Remove(b.Length - 1, 1);
            b.Append("}");
            return b.ToString();
        }
	}
    public abstract class dcTable 
    {
        abstract int Dimensions { get; }
        abstract short this[int x, int y, int z] { get; set; }
    }

}