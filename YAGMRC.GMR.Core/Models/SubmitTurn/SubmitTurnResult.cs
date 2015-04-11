using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.Models.SubmitTurn
{
    public class SubmitTurnResult
    {
        public SubmitTurnResultType ResultType { get; set; }

        public int PointsEarned { get; set; }
    }

    public enum SubmitTurnResultType
    {
        UnexpectedError,
        OK,
        NotTurn,
        DoubleSubmit
    }
}