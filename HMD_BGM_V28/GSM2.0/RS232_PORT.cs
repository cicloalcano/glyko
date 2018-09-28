using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;


namespace GSM2._0
{
    class RS232_PORT
    {

        byte[] COMMAND_ZERO = new byte[1] { 0x00 };
        byte[] COMMAND_FIVE = new byte[1] { 0x55 };
        byte[] Buffer_Receive_one = new byte[10];
        byte[] Buffer_Receive_two = new byte[2];

        public string return_string;
        public string check_Port(string port_name)
        {

            int k = 0;
            return_string = "";
            //SerialPort serialPort1 = alu_tp.main_1.serialPort1;

            if (OpenPort(port_name) == true)
            {
                k = 0;
                try
                {
                    alu_tp.main_1.serialPort1.Write(COMMAND_ZERO, 0, 1);
                    System.Threading.Thread.Sleep(60);
                    alu_tp.main_1.serialPort1.Read(Buffer_Receive_one, 0, 1);
                    //   System.Threading.Thread.Sleep(20);
                    System.Threading.Thread.Sleep(60);
                    k++;
                    if (k < 51 && Buffer_Receive_one[0] == 0)
                    { return_string = port_name; }
                    else
                    { return return_string; }
                }
                catch
                {
                }

            }
            else
            {
                //    MainModule.set_MessageBox("xxxxxxxxxx!!", 2800);  
                alu_tp.main_1.serialPort1 = null;
            }

            return return_string;

        }
        public string scan_Port()
        {

            int k = 0;
            return_string = "";
            //   bool runin = true;
            foreach (string sercom_str in System.IO.Ports.SerialPort.GetPortNames())
            {

                string return_string1 = sercom_str;
                SerialPort serialPort1 = new SerialPort();
                try
                {
                    if (serialPort1.IsOpen)
                        serialPort1.Close();
                    else
                        serialPort1.PortName = return_string1;

                    serialPort1.Open();
                    alu_tp.main_1.serialPort1.DtrEnable = true;
                    alu_tp.main_1.serialPort1.RtsEnable = true;
                    alu_tp.main_1.serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                  
                    /////////////////////////
                    //serialPort1.ReadTimeout = 50;//100ms
                    //serialPort1.WriteTimeout = 50;//100ms
                    serialPort1.ReadTimeout = 65;//100ms
                    serialPort1.WriteTimeout = 65;//100ms


                    do
                    {
                        //send 0
                        serialPort1.Write(COMMAND_ZERO, 0, 1);
                        //delay
                        //System.Threading.Thread.Sleep(20);
                        System.Threading.Thread.Sleep(60);
                        serialPort1.Read(Buffer_Receive_one, 0, 1);
                        System.Threading.Thread.Sleep(60);
                        k++;
                        if (k < 51)
                            return_string = sercom_str;
                    } while (Buffer_Receive_one[0] != 0);

                    serialPort1.Close();
                }
                catch
                {
                    serialPort1.Close();
                }
                serialPort1.Dispose();
            }
            return return_string;

        }
        private bool OpenPort(string port_name)
        {
            //    SerialPort serialPort1 = alu_tp.main_1.serialPort1;

            try
            {
                if (alu_tp.main_1.serialPort1.IsOpen)
                {
                    alu_tp.main_1.serialPort1.Close();
                    System.Threading.Thread.Sleep(60);
                }

                else
                { }
                alu_tp.main_1.serialPort1.Open();
                alu_tp.main_1.serialPort1.DtrEnable = true;
                alu_tp.main_1.serialPort1.RtsEnable = true;
                alu_tp.main_1.serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                //   alu_tp.main_1.serialPort1.ReadTimeout = 50;//100ms
                // alu_tp.main_1.serialPort1.WriteTimeout = 50;//100ms
                alu_tp.main_1.serialPort1.ReadTimeout = 65;//100ms
                alu_tp.main_1.serialPort1.WriteTimeout = 65;//100ms
                //   System.Threading.Thread.Sleep(50);
                System.Threading.Thread.Sleep(60);
                alu_tp.main_1.serialPort1.Write(COMMAND_ZERO, 0, 1);
                System.Threading.Thread.Sleep(250);
                return true;
            }
            catch
            {
                alu_tp.main_1.serialPort1.Close();
                return false;
            }
        }


    }
}
