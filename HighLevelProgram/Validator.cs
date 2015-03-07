﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iRobotGUI
{
    public class Validator
    {
        public static bool Validate(String insStr)
        {
            Instruction ins;
            Stack IfStack = new Stack();
            Stack LoopStack = new Stack();
            try
            {
                ins = new Instruction(insStr);
            }
            catch (InvalidOpcodeException ex)
            {
                throw ex;
            }

            switch (ins.opcode)
            {
                case Instruction.SONG_DEF:
                    return ValidateSongDef(ins);

                case Instruction.LOOP:
                    LoopStack.Push("LOOP");
                    break;

                case Instruction.END_LOOP:
                    LoopStack.Pop();
                    break;
            }
            return false;
        }

        // In fact, if a song is generated by GUI, there should not be any invalid ins.
        // Remove this function?
        public static bool ValidateSongDef(Instruction songIns)
        {
            int songLength = songIns.paramList.Count - 1;
            if (songLength < 2 || songLength>32) return false;

            int songNo = songIns.paramList[0];
            if ((songIns.paramList[0] < 0 || songIns.paramList[0] >15))
            {
                return false;
            }

            return true;

        }

        public static bool ValidateIF()
        {

        }
    }


}
