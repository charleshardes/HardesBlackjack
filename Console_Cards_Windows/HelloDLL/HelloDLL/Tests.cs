using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using HelloDLL;

namespace Dlltest {

    class Constants {
        
        public const string dllPath = @"..\..\..\..\Debug\DLLtest.dll";
    }


    //-----------------------------------TEST STRUCTS------------------------------------------

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct testStruct {
        public int five;
        public int seven;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct charStruct {
        public byte a;
        public byte b;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct stringStruct {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public char[] str1;

        //[MarshalAs(UnmanagedType.LPStr)]
        public IntPtr str2;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct structInStruct {
        public IntPtr rts;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct structArray {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public IntPtr[] rts;
    };

    static class Program {

        [DllImport(Constants.dllPath)]
        public static extern void testTheTestStruct1();

        [DllImport(Constants.dllPath)]
        public static extern int testTheTestStruct2();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int testTheTestStruct3(testStruct ts);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern testStruct testTheTestStruct4();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheTestStruct5(ref testStruct ts);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr testTheTestStruct6(ref testStruct ts);



        //---------------------------charStruct test calls---------------------------------------------



        [DllImport(Constants.dllPath)]
        public static extern void testTheCharStruct1();

        [DllImport(Constants.dllPath)]
        public static extern char testTheCharStruct2();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheCharStruct3(charStruct cs);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern charStruct testTheCharStruct4();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheCharStruct5(ref charStruct ts);





        //------------------------------stringStruct test calls--------------------------------------




        [DllImport(Constants.dllPath)]
        public static extern void testTheStringStruct1();

        [DllImport(Constants.dllPath)]
        public static extern IntPtr testTheStringStruct2();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStringStruct3(stringStruct ss);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern stringStruct testTheStringStruct4();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStringStruct5(ref stringStruct ss);



        //------------------------------------structInStruct Tests-----------------------------------------------

        [DllImport(Constants.dllPath)]
        public static extern void testTheStructInStruct1();

        [DllImport(Constants.dllPath)]
        public static extern int testTheStructInStruct2();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStructInStruct3(structInStruct sis);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern structInStruct testTheStructInStruct4();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStructInStruct5(ref structInStruct sis);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr testTheStructInStruct6(ref structInStruct sis);



        //-----------------------------------------structArray Tests-------------------------


        [DllImport(Constants.dllPath)]
        public static extern void testTheStructArr1();

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int testTheStructArr3(structArray sa);

        [DllImport(Constants.dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void testTheStructArr5(ref structArray sa);




        //-------------------TESTING testStruct----------------------------------------//

        public static void RunAllTests() {

            testTheTestStruct1();

            int val = testTheTestStruct2();

            testStruct ts;
            ts.five = 5;
            ts.seven = 7;

            testTheTestStruct3(ts);

            testStruct ts2 = testTheTestStruct4();

            testTheTestStruct5(ref ts2);

            IntPtr ptr = testTheTestStruct6(ref ts2);
            testStruct ts3 = (testStruct)Marshal.PtrToStructure(ptr, typeof(testStruct));

            //----------------------------TESTING charStruct--------------------------------------//

            testTheCharStruct1();

            char aChar = testTheCharStruct2();

            charStruct cs;
            cs.a = (byte)'a';
            cs.b = (byte)'b';

            testTheCharStruct3(cs);

            charStruct cs2 = testTheCharStruct4();

            testTheCharStruct5(ref cs2);


            //----------------------------TESTING stringStruct--------------------------------------//

            testTheStringStruct1();

            IntPtr anIntPtr = testTheStringStruct2();


            string aStr1 = Marshal.PtrToStringAnsi(anIntPtr);

            stringStruct ss;
            string toArr = "abcde";
            ss.str1 = toArr.ToCharArray(0, 5);

            string toArr2 = "defgh";
            ss.str2 = Marshal.StringToHGlobalAnsi(toArr2);

            testTheStringStruct3(ss);

            //stringStruct ss2 = testTheStringStruct4();

            testTheStringStruct5(ref ss);
            string strOut1 = new string(ss.str1);
            string strOut2 = Marshal.PtrToStringAnsi(ss.str2);

            //--------------------------------TESTING STRUCT IN STRUCT------------------------------------------

            testTheStructInStruct1();

            int five = testTheStructInStruct2();

            structInStruct sis1, sis3, sis4;
            testStruct ts4, ts5;

            ts4.five = 5;
            ts4.seven = 7;

            IntPtr ip = Marshal.AllocHGlobal(Marshal.SizeOf(ts4));
            Marshal.StructureToPtr(ts4, ip, false);

            sis1.rts = ip;
            sis3.rts = ip;

            testTheStructInStruct3(sis1);



            //sis2 = testTheStructInStruct4();



            testTheStructInStruct5(ref sis3);



            IntPtr ip2 = Marshal.AllocHGlobal(Marshal.SizeOf(sis3));

            ip2 = testTheStructInStruct6(ref sis3);

            sis4 = (structInStruct)Marshal.PtrToStructure(ip2, typeof(structInStruct));

            ts5 = (testStruct)Marshal.PtrToStructure(sis4.rts, typeof(testStruct));

            Marshal.FreeHGlobal(ip);
            //Marshal.FreeHGlobal(ip2);



            //------------------------Testing structArray-----------------------------------


            testTheStructArr1();

            structArray sa;
            IntPtr[] tsa = new IntPtr[5];
            testStruct[] TS = new testStruct[5];
            testStruct[] TS2 = new testStruct[5];
            sa.rts = tsa;

            for (int i = 0; i < 5; i++) {

                TS[i].five = 5 + i;
                TS[i].seven = 7 + i;

                sa.rts[i] = Marshal.AllocHGlobal(Marshal.SizeOf(TS[i]));
                Marshal.StructureToPtr(TS[i], sa.rts[i], false);
            }

            five = testTheStructArr3(sa);



            //IntPtr SA = Marshal.AllocHGlobal(Marshal.SizeOf(sa));
            //Marshal.StructureToPtr(sa, SA, false);

            testTheStructArr5(ref sa);

            for (int i = 0; i < 5; i++) {
                TS2[i] = (testStruct)Marshal.PtrToStructure(sa.rts[i], typeof(testStruct));
            }


            //---------------------Cleanup-------------------------------------------
            for (int i = 0; i < 5; i++) {
                Marshal.FreeHGlobal(sa.rts[i]);
            }
        }//end RunAllTests()
    }//end class Program
}//end DLLtests namesapace
