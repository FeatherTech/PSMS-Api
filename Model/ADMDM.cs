using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocApi.Models
{
    public sealed class ADMDM
    {

        public ADMDM()
        {
            this.student = new STUDENT();
            this.studentpayment = new List<STUDENT_PAYMENT>();
        }
        public STUDENT student { get; set; }
        public List<STUDENT_PAYMENT> studentpayment { get; set; }
    }
}