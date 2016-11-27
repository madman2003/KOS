﻿using System;
using kOS.Safe.Utilities;

namespace kOS.Safe.Exceptions
{
    /// <summary>
    /// Indicates that KOS attempted to turn a string into a number but the
    /// string was not in a recognized number format.
    /// </summary>
    public class KOSNumberParseException: KOSException
    {
        private const string TERSE_MSG_FMT = "{0} is not in a recognized number format.";

        public override string VerboseMessage { get{ return BuildVerboseMessage(); } }

        public override string HelpURL { get{ return "";} }

        private string attemptedString;
        
        public KOSNumberParseException(string attemptedString)
            : base(string.Format(TERSE_MSG_FMT, attemptedString))
        {
            this.attemptedString = attemptedString;
        }

        private string BuildVerboseMessage()
        {
            const string VERBOSE_TEXT = "kOS attempted to convert the string:\n"+
                "  \"{0}\"\n"+
                "into a Scalar number, but the format of the string isn't\n"+
                "recognizable as a number.\n"+
                "The recognizable format is:\n"+
                "  (optional sign), then\n"+
                "  (mandatory digits), then\n"+
                "  (optional decimal dot, then optional digits), then\n"+
                "  (optional letter 'e', then optional sign, then digits)\n";

            return String.Format(VERBOSE_TEXT, attemptedString);
        }
    }
}

