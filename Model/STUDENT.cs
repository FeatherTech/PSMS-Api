using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocApi.Models
{
    public sealed class STUDENT
    {
       public string regn_no         {get;set;}
public string name            {get;set;}
public string session         {get;set;}
public string cls           {get;set;}
public string stream          {get;set;}
public string roll            {get;set;}
public string address         {get;set;}
public string phone1          {get;set;}
public string email           {get;set;}
public string gurdain_name    {get;set;}
public string phone2          {get;set;}
public string del_flag        {get;set;}
public string last_installment {get;set;} 
public string last_installment_dt {get;set;}
public string orgl_user       {get;set;}
public string orgl_stamp      {get;set;}
public string updt_user       {get;set;}
public string updt_stamp      {get;set;}
public string adm_id {get;set;}
public string adm_purpose {get;set;}
         }
}