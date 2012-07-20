using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace dataCraft
{
    public interface dcTable : dcData
    {
        int Dimensions { get; }
        int this[int x, int y, int z] { get; set; }
        int xsize { get; }
        int ysize { get; }
        int zsize { get; }
    }
    public class dcTableUsingArray : dcDataWithTrueValueBase<int[, ,]>,dcTable
    {
        int Dimension = 0;
        public dcTableUsingArray(int[, ,] table) : base(table) 
        {
            if (table.GetLength(2) == 1)
                Dimension = (table.GetLength(1) == 1) ? 1 : 2;
            Dimension = 3;
        }
        public int Dimensions
        {
            get
            {
                return Dimension;
            }
        }
        public int this[int x,int y,int z]
        {
            get
            {
                if (x < xsize && y < ysize && z < zsize)
                {
                    return value[x, y, z];
                }
                return 0;
            }
            set
            {
                if (x < xsize && y < ysize && z < zsize)
                {
                    this.value[x, y, z] = value;
                }
            }
        }
        public int xsize
        {
            get
            {
                return value.GetLength(0);
            }
        }
        public int ysize
        {
            get
            {
                return value.GetLength(1);
            }
        }
        public int zsize
        {
            get
            {
                return value.GetLength(2);
            }
        }
        public override object Clone()
        {
            int[, ,] newtable = value.Clone() as int[, ,];
            dcTableUsingArray newone = new dcTableUsingArray(newtable);
            return newone;
        }
        public override void Clear()
        {
            value = new int[xsize, ysize, zsize];
        }
        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("dcTable : [");
            b.Append(xsize);
            if (Dimensions == 3)
            {
                b.Append(",");
                b.Append(ysize);
                b.Append(",");
                b.Append(zsize);
            }
            else if (Dimensions == 2)
            {
                b.Append(",");
                b.Append(ysize);
            }
            b.AppendLine("]");
            if(Dimensions == 3)
            {
                b.AppendLine("[");
                for(int i = 0;i < zsize;i++)
                {
                    b.Append("[");
                    for (int j = 0;j < ysize;j++)
                    {
                        b.Append("[");
                        for(int k = 0;k < xsize;k++)
                        {
                            b.Append(value[k,j,i]);
                            b.Append(",");
                        }
                        b.Remove(b.Length - 1,1);
                        b.AppendLine("],");
                    }
                    b.Remove(b.Length - 1,1);
                    b.AppendLine("],");
                }
                b.Remove(b.Length - 1,1);
                b.Append("]");
            }
            else if(Dimensions == 2)
            {
                b.Append("[");
                for (int j = 0;j < ysize;j++)
                {
                    b.Append("[");
                    for(int k = 0;k < xsize;k++)
                    {
                        b.Append(value[k,j,1]);
                        b.Append(",");
                    }
                    b.Remove(b.Length - 1,1);
                    b.AppendLine("],");
                }
                b.Remove(b.Length - 1,1);
                b.Append("]");
            }
            else if(Dimensions == 1)
            {
                b.Append("[");
                for(int k = 0;k < xsize;k++)
                {
                    b.Append(value[k,1,1]);
                    b.Append(",");
                }
                b.Remove(b.Length - 1,1);
                b.Append("]");
            }
            return b.ToString();
        }
    }
    /*
    public class dcTableUsingList : dcDataWithTrueValueBase<List<List<List<short>>>> ,dcTable
    {
    }
     */
}