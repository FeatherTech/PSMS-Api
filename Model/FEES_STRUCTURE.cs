using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocApi.Models
{
    public sealed class FEES_STRUCTURE
    {
       public string session     {get;set;}
public string cls       {get;set;}
public string stream      {get;set;}
public string type        {get;set;}
public string installment {get;set;}
public string head        {get;set;}
public string amount      {get;set;}
public int? serial      {get;set;}
public string del_flag    {get;set;}
public string orgl_user   {get;set;}
public string orgl_stamp  {get;set;}
public string updt_user   {get;set;}
public string updt_stamp  {get;set;}
    }
}