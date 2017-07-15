using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.Utility
{
    public enum AnswerType
    {
        [DefaultValue("Text")]
        Text = 1,
        [DefaultValue("Image")]
        Image = 2,
        [DefaultValue("Audio")]
        Audio = 3
    }

    public enum SchoolCollegeType
    {
        [DefaultValue("SCHOOL")]
        School = 1,
        [DefaultValue("COLLEGE")]
        College = 2,
        [DefaultValue("TUITION")]
        Tution = 3
    }

    public enum UserAccountStatus
    {
        [DefaultValue("OPEN")]
        [Description("OPEN")]
        Open = 1,
        [DefaultValue("SUSPENDED")]
        [Description("Your acccount is suspended")]
        Suspended = 2,
        [DefaultValue("EXPIRED")]
        [Description("Your acccount is expired")]
        Expired = 3
    }

    public enum QuestionStatus
    {
        [DefaultValue("SUBMITTED")]
        Submitted = 1,
        [DefaultValue("NOT SUBMITTED")]
        NotSubmitted = 2,
        [DefaultValue("SKIPPED")]
        Skipped = 3
    }

    public enum ExamResultStatus
    {
        [DefaultValue("PASS")]
        Pass = 1,
        [DefaultValue("FAIL")]
        Fail = 2
    }
}
