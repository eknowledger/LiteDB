﻿using System.IO;

namespace LiteDB.Shell.Commands
{
    internal class Run : ConsoleCommand
    {
        public override bool IsCommand(StringScanner s)
        {
            return s.Scan(@"run\s+").Length > 0;
        }

        public override void Execute(ref LiteDatabase db, StringScanner s, Display display, InputCommand input)
        {
            var filename = s.Scan(@".+").Trim();

            foreach (var line in File.ReadAllLines(filename))
            {
                input.Queue.Enqueue(line);
            }
        }
    }
}