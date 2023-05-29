using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAutoMapperLib.PMapExport
{
    public class PMapExportPacket
    {
        public ePMapExportCommands Command { get; set; }
        public string[] Args { get; set; }
        public PMapExportPacket()
        {
            Command = ePMapExportCommands.None;
        }

        public bool Parse(string packet)
        {
            string[] source = packet.Split('|');
            ePMapExportCommands result;
            if (source.Length == 0 || !Enum.TryParse<ePMapExportCommands>(source[0], out result))
                return false;
            Console.WriteLine(result.ToString());
            this.Command = result;
            if (source.Length > 1)
                this.Args = ((IEnumerable<string>)source).Skip<string>(1).ToArray<string>();
            return true;
        }

        public byte[] ToBytes() => Encoding.UTF8.GetBytes(this.ToString() + "\r\n");

        public override string ToString()
        {
            string sdummy1 = this.Command.ToString();
            foreach (string sdummy2 in this.Args)
            {
                sdummy1 = sdummy1 + "|" + sdummy2;
            }
            return sdummy1;
        }
    }
}
