using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MindboxShapes
{
    public interface IConsoleInteractions
    {
        BaseShape SetFromConsole(TextReader textReader, TextWriter textWriter);
        void ReportToConsole(TextWriter textWriter);
    }
}
