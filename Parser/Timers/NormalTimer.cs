﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Parser.Timers
{
    internal class NormalTimer : ITimer
    {
        private AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        public void Release()
        {
            _autoResetEvent.Set();
        }

        public bool Wait(int timeout)
        {
            return _autoResetEvent.WaitOne(timeout);
        }
    }
}
