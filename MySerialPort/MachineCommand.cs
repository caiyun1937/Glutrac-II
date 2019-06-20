using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySerialPort
{
    class MachineCommand
    {
        private String inputCommand;
        private String commondName;
        private String outputCommand;

        private bool isRight;


        public string CommondName { get => commondName; set => commondName = value; }

        public string InputCommand { get => inputCommand; set => inputCommand = value; }
        public string OutputCommand { get => outputCommand; set => outputCommand = value; }


        public bool IsRight { get => isRight; set => isRight = value; }
       

        public MachineCommand()
        {

        }
        public MachineCommand(String input, String output)
        {
            this.inputCommand = input;
            this.outputCommand = output;
        }
    }


    public class MouseFlag
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]

        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        public static void MouseLefDownEvent(int dx, int dy, uint data)
        {
            mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
        }

    }
}
