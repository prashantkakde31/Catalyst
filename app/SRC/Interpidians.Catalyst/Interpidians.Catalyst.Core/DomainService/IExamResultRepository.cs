using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpidians.Catalyst.Core.Entity;

namespace Interpidians.Catalyst.Core.DomainService
{
    public interface IExamResultRepository
    {
        ExamResult getResultByExamId(long examid);

    }
}
