using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanControl
{
    class GPIBCmd
    {
        public int ibsta, iberr, ibcnt, ibcntl;

        public void GPIBWrite(int nGPIBAddr, string sCmd)
        {           
            GPIB.ibwrt(nGPIBAddr, sCmd, sCmd.Length);
            GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
            if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
            {
                throw new Exception("Error in writing the string command to the GPIB instrument (" + sCmd + ")");
            }
        }

        public string GPIBRead(int nGPIBAddr)
        {
            StringBuilder strRead = new StringBuilder(100);
            GPIB.ibrd(nGPIBAddr, strRead, 100);
            GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
            if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
            {
                throw new Exception("Error in reading the response string from the GPIB instrument");
            }
            return strRead.ToString();
        }

        public short getAddress(ushort deviceNum, string deviceName)
        {
            ushort[] result = new ushort[30];
            ushort[] instruments = new ushort[31];
            int num_listeners;
            ushort i, k;

            //Reset the GPIB interface card by sending an interface clear command (SendIFC)
            GPIB.SendIFC(deviceNum);
            GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
            if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
            {
                throw new Exception("SendIFC Fail");
            }

            for (k = 0; k < 30; k++)
            {
                instruments[k] = (ushort)(k + 1);
            }
            instruments[30] = GPIB.NOADDR;

            //Find the listeners (instruments) on the GPIB bus using the FindLstn() command
            GPIB.FindLstn(0, instruments, result, 31);
            GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
            if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
            {
                throw new Exception("FindLstn fail");
            }

            num_listeners = ibcnt;

            for (i = 0; i < num_listeners; i++)
            {
                int dev = gpibIni(deviceNum, result[i]);
                GPIBWrite(dev, "*IDN?");

                string read = GPIBRead(dev);

                if (read.Contains(deviceName) == true)
                {
                    return (short)result[i];
                }
            }
            return -1;
        }

        private int gpibIni(ushort deviceNum, ushort gpibNum)
        {
            int dev = GPIB.ibdev(deviceNum, gpibNum, 0, (int)GPIB.gpib_timeout.T10s, 1, 0);
            GPIB.gpib_get_globals(out ibsta, out iberr, out ibcnt, out ibcntl);
            if ((ibsta & (int)GPIB.ibsta_bits.ERR) != 0)
            {
                throw new Exception("Error in initializing the GPIB instrument.");
            }

            return dev;
        }

        public int GetDevNo(ushort deviceNum, ushort gpibNum)
        {
            return gpibIni(deviceNum, gpibNum);
        }
    }
}
