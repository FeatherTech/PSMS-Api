using System;
using System.Collections.Generic;
using DocApi.Models;
using DocApi.DataLayer;


namespace DocApi.LogicLayer
{
    public class AdmissionLL
    {
       AdmissionDL _dac = new AdmissionDL(); 
       internal List<MISC_FEES> GetMiscFees(MISC_FEES adm)                                                                                                        
        {    
            return _dac.GetMiscFees(adm);                                                                                                                                               
        }
       internal List<FEES_STRUCTURE> GetFeesStructure(FEES_STRUCTURE adm)                                                                                                        
        {   
            return _dac.GetFeesStructure(adm);                                                                                                                                                
        }
      internal List<ADMISSION> GetAdmission(ADMISSION adm)
        {    
            return _dac.GetAdmission(adm);
            
        }  
    internal ADMISSION InsertAdmission(ADMISSION ad)
        {
            return _dac.InsertAdmission(ad);
            
        }  
     internal string UpdateAdmission(ADMISSION adm)
        {
           return  _dac.UpdateAdmission(adm);
        }
        internal string InsertAdmissionAndPayment(ADMDM adm)
        {
        return _dac.InsertAdmissionAndPayment(adm);
        }
        
        
    }
}