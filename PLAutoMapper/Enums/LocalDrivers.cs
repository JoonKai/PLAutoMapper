using PLAutoMapperLib.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAutoMapper.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum LocalDrivers
    {
        [Description("백업안함")]
        Blank,
        [Description("A:\\")]
        A,
        [Description("B:\\")]
        B,
        [Description("C:\\")]
        C,
        [Description("D:\\")]
        D,
        [Description("E:\\")]
        E,
        [Description("F:\\")]
        F,
        [Description("G:\\")]
        G,
        [Description("H:\\")]
        H,
        [Description("I:\\")]
        I,
        [Description("J:\\")]
        J,
        [Description("K:\\")]
        K,
        [Description("L:\\")]
        L,
        [Description("M:\\")]
        M,
        [Description("N:\\")]
        N,
        [Description("O:\\")]
        O,
        [Description("P:\\")]
        P,
        [Description("Q:\\")]
        Q,
        [Description("R:\\")]
        R,
        [Description("S:\\")]
        S,
        [Description("T:\\")]
        T,
        [Description("U:\\")]
        U,
        [Description("V:\\")]
        V,
        [Description("W:\\")]
        W,
        [Description("X:\\")]
        X,
        [Description("Y:\\")]
        Y,
        [Description("Z:\\")]
        Z,
    }
}
