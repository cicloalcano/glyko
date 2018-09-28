using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Windows.Forms;
namespace GSM2._0
{
    public class usb
    {
        public static IntPtr deviceNotificationHandle;
        //private String hidUsage;
        //   public String hidUsage;
        public static Boolean FindTheHid()
        {
        //  IntPtr deviceNotificationHandle;
            Boolean deviceFound = false;
            String[] devicePathName = new String[128];
            Guid hidGuid = Guid.Empty;
            Int32 memberIndex = 0;
            Int32 myProductID = 0;
            Int32 myVendorID = 0;
            Boolean success = false;
            String hidUsage;
         
            try
            {
                alu_tp.main_1.myDeviceDetected = false;
                GetVendorAndProductIDsFromTextBoxes(ref myVendorID, ref myProductID);
                Hid.HidD_GetHidGuid(ref hidGuid);
                deviceFound = alu_tp.main_1.MyDeviceManagement.FindDeviceFromGuid(hidGuid, ref devicePathName);

                if (deviceFound)
                {
                    memberIndex = 0;

                    do
                    {
                       alu_tp.main_1.hidHandle = FileIO.CreateFile(devicePathName[memberIndex], 0, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                        if (!alu_tp.main_1.hidHandle.IsInvalid)
                        {
                            //  The returned handle is valid, 
                            //  so find out if this is the device we're looking for.

                            //  Set the Size property of DeviceAttributes to the number of bytes in the structure.

                            alu_tp.main_1.MyHid.DeviceAttributes.Size = Marshal.SizeOf(alu_tp.main_1.MyHid.DeviceAttributes);

                            success = Hid.HidD_GetAttributes(alu_tp.main_1.hidHandle, ref alu_tp.main_1.MyHid.DeviceAttributes);

                            if (success)
                            {
                                //  Find out if the device matches the one we're looking for.
                                if ((alu_tp.main_1.MyHid.DeviceAttributes.VendorID == myVendorID) && (alu_tp.main_1.MyHid.DeviceAttributes.ProductID == myProductID))
                                {
                                    alu_tp.main_1.myDeviceDetected = true;
                                    //  Save the DevicePathName for OnDeviceChange().
                                    alu_tp.main_1.myDevicePathName = devicePathName[memberIndex];
                                }
                                else
                                {
                                    //  It's not a match, so close the handle.
                                    alu_tp.main_1.myDeviceDetected = false;
                                    alu_tp.main_1.hidHandle.Close();
                                }
                            }
                            else
                            {
                                alu_tp.main_1.myDeviceDetected = false;
                                alu_tp.main_1.hidHandle.Close();
                            }
                        }

                        //  Keep looking until we find the device or there are no devices left to examine.

                        memberIndex = memberIndex + 1;
                    }
                    while (!((alu_tp.main_1.myDeviceDetected || (memberIndex == devicePathName.Length))));
                }

                if (alu_tp.main_1.myDeviceDetected)
                {
                    success = alu_tp.main_1.MyDeviceManagement.RegisterForDeviceNotifications(alu_tp.main_1.myDevicePathName, alu_tp.main_1.FrmMy.Handle, hidGuid, ref deviceNotificationHandle);
                    alu_tp.main_1.MyHid.Capabilities = alu_tp.main_1.MyHid.GetDeviceCapabilities(alu_tp.main_1.hidHandle);

                    if (success)
                    {
                        //  Find out if the device is a system mouse or keyboard.

                        hidUsage = alu_tp.main_1.MyHid.GetHidUsage(alu_tp.main_1.MyHid.Capabilities);


                        GetInputReportBufferSize();

                        alu_tp.main_1.readHandle = FileIO.CreateFile(alu_tp.main_1.myDevicePathName, FileIO.GENERIC_READ, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, FileIO.FILE_FLAG_OVERLAPPED, 0);


                        if (alu_tp.main_1.readHandle.IsInvalid)
                        {
                          //  exclusiveAccess = true;
                        }
                        else
                        {
                            alu_tp.main_1.writeHandle = FileIO.CreateFile(alu_tp.main_1.myDevicePathName, FileIO.GENERIC_WRITE, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);
                            alu_tp.main_1.MyHid.FlushQueue(alu_tp.main_1.readHandle);
                        }
                    }
                }
                else
                {
                }
                return alu_tp.main_1.myDeviceDetected;
            }
            catch (Exception ex)
            {
                //  DisplayException(this.Name, ex);
                throw;
            }
        }
          public static void GetVendorAndProductIDsFromTextBoxes(ref Int32 myVendorID, ref Int32 myProductID)
        {
            try
            {
                myVendorID = Int32.Parse(alu_tp.main_1.MyV_ID, NumberStyles.AllowHexSpecifier);
                myProductID = Int32.Parse(alu_tp.main_1.MyP_ID, NumberStyles.AllowHexSpecifier);
            }
            catch (Exception ex)
            {
                //    DisplayException(this.Name, ex);
                throw;
            }
        }
            public static void GetInputReportBufferSize()
        {
            Int32 numberOfInputBuffers = 0;
            Boolean success;

            try
            {
                success = alu_tp.main_1.MyHid.GetNumberOfInputBuffers(alu_tp.main_1.hidHandle, ref numberOfInputBuffers);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void write_usb(byte[] buf)
        {
            byte[] outFeatureReportBuffer = new byte[buf.Length + 1];
            try
            {
                Hid.OutFeatureReport myOutFeatureReport = new Hid.OutFeatureReport();
                if ((alu_tp.main_1.MyHid.Capabilities.FeatureReportByteLength > 0))
                {
                    outFeatureReportBuffer = new Byte[alu_tp.main_1.MyHid.Capabilities.FeatureReportByteLength];
                    outFeatureReportBuffer[0] = 0;
                    outFeatureReportBuffer[1] = buf[0];

                    if (Information.UBound(buf, 1) > 1)
                    {
                        outFeatureReportBuffer[2] = buf[1];
                        outFeatureReportBuffer[3] = buf[2];
                    }
                    if (buf.Length == 4)
                    {
                        outFeatureReportBuffer[4] = buf[3];
                    }
                    if (buf.Length == 6)
                    {
                        outFeatureReportBuffer[4] = buf[3];
                        outFeatureReportBuffer[5] = buf[4];
                        outFeatureReportBuffer[6] = buf[5];
                    }
                    if (buf.Length == 9)
                    {
                        outFeatureReportBuffer[4] = buf[3];
                        outFeatureReportBuffer[5] = buf[4];
                        outFeatureReportBuffer[6] = buf[5];
                        outFeatureReportBuffer[7] = buf[6];
                        outFeatureReportBuffer[8] = buf[7];
                        outFeatureReportBuffer[9] = buf[8];
                    }
                    myOutFeatureReport.Write(outFeatureReportBuffer, alu_tp.main_1.hidHandle);
                }
            }
            catch (Exception ex)
            {
                //      DisplayException(this.Name, ex);
                //  throw;
            }        
        }

        public static byte[] read_usb()
        {
            Byte[] inFeatureReportBuffer = null;
            Boolean success = false;
            try
            {
                Hid.InFeatureReport myInFeatureReport = new Hid.InFeatureReport();
                inFeatureReportBuffer = null;
                inFeatureReportBuffer = new Byte[alu_tp.main_1.MyHid.Capabilities.FeatureReportByteLength];
                myInFeatureReport.Read(alu_tp.main_1.hidHandle, alu_tp.main_1.readHandle, alu_tp.main_1.writeHandle, ref alu_tp.main_1.myDeviceDetected, ref inFeatureReportBuffer, ref success);
                int jj = 0;
                int len_1 = 0;
                if (inFeatureReportBuffer[3] == 0x00 && inFeatureReportBuffer[1] == 0x00 && inFeatureReportBuffer[2] == 0x00) len_1 = 1;
                if (inFeatureReportBuffer[1] == 0x54 && inFeatureReportBuffer[2] == 0xF1 && inFeatureReportBuffer[3] == 0x00) len_1 = 2;
                if (inFeatureReportBuffer[2] == 0x5c && inFeatureReportBuffer[3] == 0xbb) len_1 = 3;
                if (inFeatureReportBuffer[3] == 0xaa && inFeatureReportBuffer[4] == 0x00) len_1 = 3;
                if (inFeatureReportBuffer[3] == 0xa9 && inFeatureReportBuffer[4] == 0x00) len_1 = 3;
                if (inFeatureReportBuffer[3] == 0x5a && inFeatureReportBuffer[4] == 0xaa && inFeatureReportBuffer[5] == 0x00) len_1 = 4;
                if (inFeatureReportBuffer[10] == 0x00 && (inFeatureReportBuffer[9] != 0x00 || inFeatureReportBuffer[8] != 0x00)) len_1 = 9;
                //if (inFeatureReportBuffer[12] == 0x00 && (inFeatureReportBuffer[9] != 0x00 || inFeatureReportBuffer[8] != 0x00)) len_1 = 9;
                if (inFeatureReportBuffer[1] == 0xa8 && inFeatureReportBuffer[2] == 0x02 && (inFeatureReportBuffer[14] != 0x00 || inFeatureReportBuffer[15] != 0x00 || inFeatureReportBuffer[16] != 0x00 || inFeatureReportBuffer[17] != 0x00 || inFeatureReportBuffer[10] != 0x00)) len_1 = 17;
                if (inFeatureReportBuffer[1] == 0xa8 && inFeatureReportBuffer[2] == 0x03 && inFeatureReportBuffer[3] != 0x00 && (inFeatureReportBuffer[15] != 0x00 || inFeatureReportBuffer[16] != 0x00 || inFeatureReportBuffer[12] != 0x00 || inFeatureReportBuffer[13] != 0x00 || inFeatureReportBuffer[9] != 0x00)) len_1 = 18;         

                Byte[] inFe_1 = new Byte[len_1];
                for (jj = 0; jj < len_1; jj++)
                {
                    inFe_1[jj] = inFeatureReportBuffer[jj+1];
                }
                return inFe_1;
              }
            catch (Exception ex)
            {
                //      DisplayException(this.Name, ex);
                //  throw;
                return inFeatureReportBuffer;
            }
        }
        public static void OnDeviceChange(Message m)
        {
            try
            {
                if ((m.WParam.ToInt32() == DeviceManagement.DBT_DEVICEARRIVAL))
                {
                    if (alu_tp.main_1.MyDeviceManagement.DeviceNameMatch(m, alu_tp.main_1.myDevicePathName))
                    {
                        if (alu_tp.main_1.myDeviceDetected == false)
                        {
                            MainModule.set_MessageBox("usb_online", 1500);
                            alu_tp.main_1.myDeviceDetected = true;
                        }
                      //  alu_tp.main_1.bWarnedUSB = true;
                      
                    }

                }
                else if ((m.WParam.ToInt32() == DeviceManagement.DBT_DEVICEREMOVECOMPLETE))
                {
                    if (alu_tp.main_1.MyDeviceManagement.DeviceNameMatch(m, alu_tp.main_1.myDevicePathName))
                    {
                        if (alu_tp.main_1.myDeviceDetected == true)
                        {
                            MainModule.set_MessageBox("usb_quit", 1500);
                            //  alu_tp.main_1.FrmMy.myDeviceDetected = false;
                            alu_tp.main_1.myDeviceDetected = false;
                        }
                     //   alu_tp.main_1.bWarnedUSB = false;
                   


                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
