using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GameRecorder
    {
        StreamWriter swWriteFile;
        string strWriteFilePath = @"../../../WriteLog.txt";


        public static Dictionary<Keys, String> KeyboardRecordLogMappings = new Dictionary<Keys, String>{
                {Keys.Q, "Q"},
                 {Keys.W, "W"},
                 {Keys.A, "A"},
                 {Keys.Left,"A"},
                 {Keys.Right,"D" },
                 {Keys.Up,  "W" },
                 {Keys.Down, "X"},
                 {Keys.S,"X"},
                 {Keys.D, "D"},
                 {Keys.T,"T"},
                 
                 
                
                 {Keys.X, "X"},
                 };

        public static void Write(StreamWriter swWriteFile, string commandType)
        {



            swWriteFile.Write(commandType); //



            //Console.WriteLine("：" + WriteRows);
            //Console.ReadKey();
        }

        public static void Enter(StreamWriter swWriteFile)
        {


            swWriteFile.Write(swWriteFile.NewLine); //

        }

        public static void endRecord(StreamWriter swWriteFile)
        {
            swWriteFile.Close();
        }
    }
}
