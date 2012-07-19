using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace dataCraft
{
	public interface dcDataWithTrueValue<T> : dcData
	{
		T Value { get;set; }
	}
	
	abstract public class dcDataWithTrueValueBase<T> : dcDataWithTrueValue<T>
	{
		protected T value;
		public dcDataWithTrueValueBase(T t)
		{
			value = t;
		}
		public override string ToString()
		{
			return Value.ToString();
		}
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
        public abstract void Clear();
        public abstract object Clone();
	}
}