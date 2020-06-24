using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Model
{
    public enum EmployeeType
    {
        HRSupervisor = 1,
        RegularSupervisor = 2,
        HREmployee = 3,
        RegularEmployee = 4
    }

    public enum ItemStatus
    {
        Pending,
        Approved,
        Denied,
        NoLongerRequired
    }

    public enum EmploymentStatus
    {
        Active = 1,
        Terminated = 2,
        Retired = 3
    }

    public enum Performance
    {
        [Description("Bellow Expectation")]
        BellowExpectation,
        [Description("Meets Expectation")]
        MeetExpectation,
        [Description("Exceeds Expectation")]
        ExceedsExpetation

    }

    public enum POStatus
    {
        Pending,
        UnderReview,
        Closed
    }

    public static class EnumObject
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

    }

}


