using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace HelloDLL {

    static class Constants {
        public const string dllPath = @"C:\Users\Charles\Documents\GitHub\HardesBlackJack\Console_Cards_Windows\Debug\BlackJackLogic.dll";
        public const string newInPath = @"C:\Users\Charles\Documents\GitHub\HardesBlackJack\Console_Cards_Windows\HelloDLL\HelloDLL\bin\Debug\newIn.txt";
    }

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [DllImport(Constants.dllPath)]
        public static extern int Display7MyDLL();

        [DllImport(Constants.dllPath)]
        public static extern int Display8MyDLL();

        [DllImport(Constants.dllPath)]
        public static extern int runBlackjack();

        [DllImport(Constants.dllPath)]
        public static extern int readTest();
        
        [STAThread]
        static void Main() {

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

            int output;
            byte temp = 4;

            using (FileStream
                F = new FileStream(Constants.newInPath, FileMode.Create)) {

                output = Display7MyDLL();
                output = Display8MyDLL();

                //output -= 5;


                //write temp var to "newIn.txt"
                F.WriteByte(temp);

                //set seek to the beginning of the file
                F.Seek(0, SeekOrigin.Begin);

                //make sure the file has been written to and can be read from
                output = F.ReadByte();

                //call the DLL function readTest to make sure it can also read the file 
                output = readTest();


                //runBlackjack();



                F.Close();
            }
        }
    }
}
