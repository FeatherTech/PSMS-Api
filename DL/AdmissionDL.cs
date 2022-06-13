using DocApi.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using PSMSWebApi.Config;
using DocApi.DataLayer;

namespace DocApi.DataLayer
{
    internal sealed class AdmissionDL
    {
        string _statement;
            
        internal string GetMySqlHealth()
        {
            string ret = null;
            using (var connection = MySqlDbConnection.NewConnection)
            {
                _statement = string.Format("SELECT SYSDATE()  DAY");
                using (var command = MySqlDbConnection.Command(connection, _statement))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ret = "MYSQL: " + UtilityDL.CheckNull<DateTime>(reader["DAY"]);
                            }
                        }
                    }
                }
            }

            return ret;
        }
        internal List<MISC_FEES> GetMiscFees(MISC_FEES adm)                                                                                                        
        {                                                                                                                                                   
            var fees = new List<MISC_FEES>();                                                                                                          
            using (var connection = MySqlDbConnection.NewConnection)                                                                                        
            {                                                                                                                                               
                string query= " SELECT                      "                                                                                               
+ " HEAD      ,"                                                                                                                 
+ " AMOUNT    ,"                                                                                                                 
+ " DEL_FLAG  ,"                                                                                                                 
+ " ORGL_USER ,"                                                                                                                 
+ " ORGL_STAMP,"                                                                                                                 
+ " UPDT_USER ,"                                                                                                                 
+ " UPDT_STAMP"                                                                                                       
+ " FROM MISC_FEES   "                                                                                                                           
+ " WHERE DEL_FLAG   = 'N'     ";                                                                                                                            
                _statement = string.Format(query);                                                                                                                
                                                                                                                                                            
                using (var command = MySqlDbConnection.Command(connection, _statement))                                                                     
                {                                                                                                                                           
                    using (var reader = command.ExecuteReader())                                                                                            
                    {                                                                                                                                       
                        if (reader.HasRows)                                                                                                                 
                        {                                                                                                                                   
                            while (reader.Read())                                                                                                           
                            {                                                                                                                               
                                var adm2 = new MISC_FEES();                                                                                                 
                                                                                                                                                            
                                adm2.head = UtilityDL.CheckNull<string>(reader["HEAD"]);                                                             
                                adm2.amount = Convert.ToString(UtilityDL.CheckNull<Int32>(reader["AMOUNT"]));                                                                
                                adm2.del_flag = UtilityDL.CheckNull<string>(reader["DEL_FLAG"]);                                                              
                                fees.Add(adm2);                                                                                                        
                            }                                                                                                                               
                        }                                                                                                                                   
                    }                                                                                                                                       
                }                                                                                                                                           
            }                                                                                                                                               
                                                                                                                                                            
            return fees;                                                                                                                               
        }  
        internal List<FEES_STRUCTURE> GetFeesStructure(FEES_STRUCTURE adm)                                                                                                        
        {                                                                                                                                                   
            var fees = new List<FEES_STRUCTURE>();                                                                                                          
            using (var connection = MySqlDbConnection.NewConnection)                                                                                        
            {                                                                                                                                               
                string query= " SELECT                      "                                                                                               
+ " SESSION      ,"                                                                                                                 
+ " CLASS        ,"                                                                                                                 
+ " STREAM       ,"                                                                                                                 
+ " TYPE         ,"                                                                                                                 
+ " INSTALLMENT  ,"                                                                                                                 
+ " HEAD         ,"                                                                                                                 
+ " AMOUNT       ,"                                                                                                                 
+ " SERIAL       ,"                                                                                                                 
+ " DEL_FLAG     ,"                                                                                                                 
+ " ORGL_USER    ,"                                                                                                                 
+ " ORGL_STAMP   ,"                                                                                                                 
+ " UPDT_USER    ,"                                                                                                                 
+ " UPDT_STAMP   "                                                                                                                 
+ " FROM FEES_STRUCTURE   "                                                                                                                           
+ " WHERE SESSION = {0}     "                                                                                                                             
+ "   AND CLASS    = {1}     "                                                                                                                             
+ "   AND STREAM = {2} "                                                                                                                                 
+ "   AND TYPE   ={3}"     
+"    AND INSTALLMENT ={4} "                                                                                                     
+ "   AND DEL_FLAG   = 'N'     ";                                                                                                                            
                _statement = string.Format(query,                                                                                                           
                                           string.IsNullOrWhiteSpace(adm.session) ? "SESSION" : string.Concat( "'" , adm.session , "'"),     
                                           string.IsNullOrWhiteSpace(adm.cls) ? "CLASS" : string.Concat( "'" , adm.cls , "'"),                  
                                           string.IsNullOrWhiteSpace(adm.stream) ? "STREAM" : string.Concat( "'" , adm.stream , "'"),                  
                                           string.IsNullOrWhiteSpace(adm.type) ? "TYPE" : string.Concat( "'" , adm.type , "'"),  
                                           string.IsNullOrWhiteSpace(adm.installment) ? "INSTALLMENT" : string.Concat( "'" , adm.installment , "'")                    
                                          );                                                                                                                
                                                                                                                                                            
                using (var command = MySqlDbConnection.Command(connection, _statement))                                                                     
                {                                                                                                                                           
                    using (var reader = command.ExecuteReader())                                                                                            
                    {                                                                                                                                       
                        if (reader.HasRows)                                                                                                                 
                        {                                                                                                                                   
                            while (reader.Read())                                                                                                           
                            {                                                                                                                               
                                var adm2 = new FEES_STRUCTURE();                                                                                                 
                                                                                                                                                            
                                adm2.serial = UtilityDL.CheckNull<int>(reader["SERIAL"]);                                                             
                                adm2.installment = Convert.ToString(UtilityDL.CheckNull<Int32>(reader["INSTALLMENT"]));                                                                
                                adm2.session = UtilityDL.CheckNull<string>(reader["SESSION"]);                                                              
                                adm2.type = UtilityDL.CheckNull<string>(reader["TYPE"]);                                                
                                adm2.cls = Convert.ToString(UtilityDL.CheckNull<Int32>(reader["CLASS"]));                                                                  
                                adm2.head = UtilityDL.CheckNull<string>(reader["HEAD"]);                                                              
                                adm2.stream = UtilityDL.CheckNull<string>(reader["STREAM"]);                                                                
                                adm2.amount = Convert.ToString(UtilityDL.CheckNull<Int32>(reader["AMOUNT"]));                                                          
                                adm2.del_flag = UtilityDL.CheckNull<string>(reader["DEL_FLAG"]);                                                        
                                                                                                                                                            
                                fees.Add(adm2);                                                                                                        
                            }                                                                                                                               
                        }                                                                                                                                   
                    }                                                                                                                                       
                }                                                                                                                                           
            }                                                                                                                                               
                                                                                                                                                            
            return fees;                                                                                                                               
        }                                                                                                                                                   
                                                                                                                                                            

        internal List<ADMISSION> GetAdmission(ADMISSION adm)
        {
            var admission = new List<ADMISSION>();
            using (var connection = MySqlDbConnection.NewConnection)
            {
                string query= " SELECT                      "
+ " SERIAL_NO      ,            "
+ " ADM_ID 	     ,       "
+ " SESSION         ,           "
+ " ADMIN_IN_CLASS  ,           "
+ " CLASS           ,           "
+ " REGN_NO         ,           "
+ " CORE_SUBJ      ,            "
+ " GEN_SUBJ       ,            "
+ " STREAM         ,            "
+ " FIRST_NAME     ,            "
+ " LAST_NAME      ,            "
+ " MIDDLE_NAME    ,            "
+ " DOB            ,            "
+ " PHONE          ,            "
+ " EMAIL          ,            "
+ " GENDER         ,            "
+ " CATEGORY       ,            "
+ " TRIBE          ,            "
+ " MARITAL_STATUS ,            "
+ " RELIGION       ,            "
+ " NATIONALITY    ,            "
+ " BLOOD_GROUP    ,            "
+ " IDENT_MARK     ,            "
+ " PHY_CHALLENGE  ,            "
+ " FATHER_NAME    ,            "
+ " FATHER_PHONE   ,            "
+ " MOTHER_NAME    ,            "
+ " MOTHER_PHONE   ,            "
+ " GUARDIAN_NAME  ,            "
+ " GUARDIAN_PHONE ,            "
+ " GUARDIAN_ADDR  ,            "
+ " PER_ADDR       ,            "
+ " PER_CITY_TOWN  ,            "
+ " PER_DIST       ,            "
+ " PER_STATE      ,            "
+ " PER_PIN        ,            "
+ " COMU_ADDR      ,            "
+ " COMU_CITY_TOWN ,            "
+ " COMU_DIST      ,            "
+ " COMU_STATE     ,            "
+ " COMU_PIN       ,            "
+ " PAYMENT_STAT   ,            "
+ " HOSTEL_REQ ,                "
+ " FORM_CMPL_STAT,             "
+ " APPROVAL_STAT ,             "
+ " REMARKS ,                   "
+ " SUB1           ,            "
+ " SUB2           ,            "
+ " SUB3           ,            "
+ " SUB4           ,            "
+ " SUB5           ,            "
+ " SUB6           ,            "
+ " SUB7           ,            "
+ " SUB8           ,            "
+ " SUB9           ,            "
+ " SUB10          ,            "
+ " PREV_SCHOOL    ,            "
+ " PREV_BOARD     ,            "
+ " PREV_ROLL      ,            "
+ " PREV_PASSYEAR  ,            "
+ " PREV_DIV       ,            "
+ " PREV_PERCENT   ,            "
+ " PREV_CLASS     ,            "
+ " GUARDIAN_REL   ,            "
+ " FATHER_QUAL    ,            "
+ " FATHER_OCU     ,            "
+ " FATHER_DES     ,            "
+ " MOTHER_QUAL    ,            "
+ " MOTHER_OCU     ,            "
+ " MOTHER_DES     ,            "
+ " PER_LOC        ,            "
+ " PER_WARD       ,            "
+ " PER_PO         ,            "
+ " COMU_LOC       ,            "
+ " COMU_WARD      ,            "
+ " COMU_PO        ,            "
+ " PER_COMU_SAME  ,            "
+ " YEAR                        "
+ " FROM ADMISSION              "
+ " WHERE SERIAL_NO = {0}     "
+ "   AND ADM_ID    = {1}     "
+ "   AND FIRST_NAME  {2} "
+ "   AND CLASS     = {3}     "
+ "   AND IFNULL(REGN_NO,'@')   =IFNULL({4},'@') "
+ "   AND DEL_FLG   = 'N'     ";
_statement = string.Format(query,                                                                                                            
                                                   adm.serial_no.HasValue ? Convert.ToString(adm.serial_no.Value) : "SERIAL_NO",                                     
                                                   string.IsNullOrWhiteSpace(adm.adm_id) ? "ADM_ID" : string.Concat( "'" , adm.adm_id , "'"),                        
                                                   string.IsNullOrWhiteSpace(adm.first_name) ? " = FIRST_NAME" : string.Concat( " like '%" , adm.first_name , "%'"), 
                                                   string.IsNullOrWhiteSpace(adm.cls) ? "CLASS" : string.Concat( "'" , adm.cls , "'"),                          
                                                   string.IsNullOrWhiteSpace(adm.regn_no) ? "REGN_NO" : string.Concat( "'" , adm.regn_no , "'")                      
                                                  );                                                                                                                 
         

                using (var command = MySqlDbConnection.Command(connection, _statement))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var adm2 = new ADMISSION();

                               adm2.serial_no      = UtilityDL.CheckNull<int>(reader["SERIAL_NO"]);
     adm2.adm_id         = UtilityDL.CheckNull<string>(reader["ADM_ID"]);
     adm2.session        = UtilityDL.CheckNull<string>(reader["SESSION"]);
     adm2.admin_in_class = UtilityDL.CheckNull<string>(reader["ADMIN_IN_CLASS"]);
     adm2.cls          = UtilityDL.CheckNull<string>(reader["CLASS"]);
     adm2.regn_no        = UtilityDL.CheckNull<string>(reader["REGN_NO"]);
     adm2.stream         = UtilityDL.CheckNull<string>(reader["STREAM"]);
     adm2.core_subj      = UtilityDL.CheckNull<string>(reader["CORE_SUBJ"]);
     adm2.gen_subj       = UtilityDL.CheckNull<string>(reader["GEN_SUBJ"]);
     adm2.first_name     = UtilityDL.CheckNull<string>(reader["FIRST_NAME"]);
     adm2.last_name      = UtilityDL.CheckNull<string>(reader["LAST_NAME"]);
     adm2.middle_name    = UtilityDL.CheckNull<string>(reader["MIDDLE_NAME"]);
     if (reader["DOB"] == DBNull.Value)
     { adm2.dob = null; }
     else
     { adm2.dob = UtilityDL.CheckNull<DateTime>(reader["DOB"]); }

     adm2.phone            = UtilityDL.CheckNull<string>(reader["PHONE"]);
     adm2.email            = UtilityDL.CheckNull<string>(reader["EMAIL"]);
     adm2.gender            = UtilityDL.CheckNull<string>(reader["GENDER"]);
     adm2.category         = UtilityDL.CheckNull<string>(reader["CATEGORY"]);
     adm2.tribe            = UtilityDL.CheckNull<string>(reader["TRIBE"]);
     adm2.marital_status   = UtilityDL.CheckNull<string>(reader["MARITAL_STATUS"]);
     adm2.religion         = UtilityDL.CheckNull<string>(reader["RELIGION"]);
     adm2.nationality      = UtilityDL.CheckNull<string>(reader["NATIONALITY"]);
     adm2.blood_group      = UtilityDL.CheckNull<string>(reader["BLOOD_GROUP"]);
     adm2.ident_mark       = UtilityDL.CheckNull<string>(reader["IDENT_MARK"]);
     adm2.phy_challenge    = UtilityDL.CheckNull<string>(reader["PHY_CHALLENGE"]);
     adm2.father_name      = UtilityDL.CheckNull<string>(reader["FATHER_NAME"]);
     adm2.father_phone     = UtilityDL.CheckNull<string>(reader["FATHER_PHONE"]);
     adm2.mother_name      = UtilityDL.CheckNull<string>(reader["MOTHER_NAME"]);
     adm2.mother_phone     = UtilityDL.CheckNull<string>(reader["MOTHER_PHONE"]);
     adm2.guardian_name    = UtilityDL.CheckNull<string>(reader["GUARDIAN_NAME"]);
     adm2.guardian_phone   = UtilityDL.CheckNull<string>(reader["GUARDIAN_PHONE"]);
     adm2.guardian_addr    = UtilityDL.CheckNull<string>(reader["GUARDIAN_ADDR"]);
     adm2.per_addr         = UtilityDL.CheckNull<string>(reader["PER_ADDR"]);
     adm2.per_city_town    = UtilityDL.CheckNull<string>(reader["PER_CITY_TOWN"]);
     adm2.per_dist         = UtilityDL.CheckNull<string>(reader["PER_DIST"]);
     adm2.per_state        = UtilityDL.CheckNull<string>(reader["PER_STATE"]);
     adm2.per_pin          = UtilityDL.CheckNull<string>(reader["PER_PIN"]);
     adm2.comu_addr        = UtilityDL.CheckNull<string>(reader["COMU_ADDR"]);
     adm2.comu_city_town   = UtilityDL.CheckNull<string>(reader["COMU_CITY_TOWN"]);
     adm2.comu_dist        = UtilityDL.CheckNull<string>(reader["COMU_DIST"]);
     adm2.comu_state       = UtilityDL.CheckNull<string>(reader["COMU_STATE"]);
     adm2.comu_pin         = UtilityDL.CheckNull<string>(reader["COMU_PIN"]);
     adm2.payment_stat     = UtilityDL.CheckNull<string>(reader["PAYMENT_STAT"]);
     adm2.hostel_req       = UtilityDL.CheckNull<string>(reader["HOSTEL_REQ"]);
     adm2.form_cmpl_stat   = UtilityDL.CheckNull<string>(reader["FORM_CMPL_STAT"]);
     adm2.approval_stat    = UtilityDL.CheckNull<string>(reader["APPROVAL_STAT"]);
     adm2.remarks          = UtilityDL.CheckNull<string>(reader["REMARKS"]);
     adm2.sub1             =UtilityDL.CheckNull<string>(reader["SUB1"]);
     adm2.sub2           =UtilityDL.CheckNull<string>(reader["SUB2"]);
     adm2.sub3           =UtilityDL.CheckNull<string>(reader["SUB3"]);
     adm2.sub4           =UtilityDL.CheckNull<string>(reader["SUB4"]);
     adm2.sub5           =UtilityDL.CheckNull<string>(reader["SUB5"]);
     adm2.sub6           =UtilityDL.CheckNull<string>(reader["SUB6"]);
     adm2.sub7           =UtilityDL.CheckNull<string>(reader["SUB7"]);
     adm2.sub8           =UtilityDL.CheckNull<string>(reader["SUB8"]);
     adm2.sub9           =UtilityDL.CheckNull<string>(reader["SUB9"]);
     adm2.sub10          =UtilityDL.CheckNull<string>(reader["SUB10"]);
     adm2.prev_school    =UtilityDL.CheckNull<string>(reader["PREV_SCHOOL"]);
     adm2.prev_board     =UtilityDL.CheckNull<string>(reader["PREV_BOARD"]);
     adm2.prev_roll      =UtilityDL.CheckNull<string>(reader["PREV_ROLL"]);
     adm2.prev_passyear  =UtilityDL.CheckNull<string>(reader["PREV_PASSYEAR"]);
     adm2.prev_div       =UtilityDL.CheckNull<string>(reader["PREV_DIV"]);
     adm2.prev_percent   =UtilityDL.CheckNull<string>(reader["PREV_PERCENT"]);
     adm2.prev_class     =UtilityDL.CheckNull<string>(reader["PREV_CLASS"]);
     adm2.guardian_rel   =UtilityDL.CheckNull<string>(reader["GUARDIAN_REL"]);
     adm2.father_qual    =UtilityDL.CheckNull<string>(reader["FATHER_QUAL"]);
     adm2.father_ocu     =UtilityDL.CheckNull<string>(reader["FATHER_OCU"]);
     adm2.father_des     =UtilityDL.CheckNull<string>(reader["FATHER_DES"]);
     adm2.mother_qual    =UtilityDL.CheckNull<string>(reader["MOTHER_QUAL"]);
     adm2.mother_ocu     =UtilityDL.CheckNull<string>(reader["MOTHER_OCU"]);
     adm2.mother_des     =UtilityDL.CheckNull<string>(reader["MOTHER_DES"]);
     adm2.per_loc        =UtilityDL.CheckNull<string>(reader["PER_LOC"]);
     adm2.per_ward       =UtilityDL.CheckNull<string>(reader["PER_WARD"]);
     adm2.per_po         =UtilityDL.CheckNull<string>(reader["PER_PO"]);
     adm2.comu_loc       =UtilityDL.CheckNull<string>(reader["COMU_LOC"]);
     adm2.comu_ward      =UtilityDL.CheckNull<string>(reader["COMU_WARD"]);
     adm2.comu_po        =UtilityDL.CheckNull<string>(reader["COMU_PO"]);
     adm2.per_comu_same  =UtilityDL.CheckNull<string>(reader["PER_COMU_SAME"]);
     adm2.year           =UtilityDL.CheckNull<string>(reader["YEAR"]);
      
                                admission.Add(adm2);
                            }
                        }
                    }
                }
            }

            return admission;
        }

        internal ADMISSION InsertAdmission(ADMISSION ad)
        {
            
            using (var connection = MySqlDbConnection.NewConnection)
            {
                _statement = "INSERT_ADMISSION";

                using (var command = MySqlDbConnection.Command(connection, _statement))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new MySqlParameter("P_SESSION", ad.session ));
                    command.Parameters.Add(new MySqlParameter("P_ADMIN_IN_CLASS", ad.admin_in_class));
                    command.Parameters.Add(new MySqlParameter("P_CLASS", ad.cls));
                    command.Parameters.Add(new MySqlParameter("P_REGN_NO", ad.regn_no ));                    
                    command.Parameters.Add(new MySqlParameter("P_STREAM", ad.stream ));
                    command.Parameters.Add(new MySqlParameter("P_CORE_SUBJ", ad.core_subj));
                    command.Parameters.Add(new MySqlParameter("P_GEN_SUBJ", ad.gen_subj));
                    command.Parameters.Add(new MySqlParameter("P_FIRST_NAME", ad.first_name ));
                    command.Parameters.Add(new MySqlParameter("P_LAST_NAME", ad.last_name ));
                    command.Parameters.Add(new MySqlParameter("P_MIDDLE_NAME", ad.middle_name ));
                    command.Parameters.Add(new MySqlParameter("P_DOB", ad.dob ));
                    command.Parameters.Add(new MySqlParameter("P_PHONE", ad.phone ));
                    command.Parameters.Add(new MySqlParameter("P_EMAIL", ad.email));
                    command.Parameters.Add(new MySqlParameter("P_GENDER", ad.gender ));
                    command.Parameters.Add(new MySqlParameter("P_CATEGORY", ad.category ));
                    command.Parameters.Add(new MySqlParameter("P_TRIBE", ad.tribe));
                    command.Parameters.Add(new MySqlParameter("P_MARITAL_STATUS", ad.marital_status  ));
                    command.Parameters.Add(new MySqlParameter("P_RELIGION", ad.religion  ));
                    command.Parameters.Add(new MySqlParameter("P_NATIONALITY", ad.nationality  ));
                    command.Parameters.Add(new MySqlParameter("P_BLOOD_GROUP", ad.blood_group  ));
                    command.Parameters.Add(new MySqlParameter("P_IDENT_MARK", ad.ident_mark  ));
                    command.Parameters.Add(new MySqlParameter("P_PHY_CHALLENGE", ad.phy_challenge  ));  
                    command.Parameters.Add(new MySqlParameter("P_FATHER_NAME", ad.father_name ));       
                    command.Parameters.Add(new MySqlParameter("P_FATHER_PHONE", ad.father_phone  ));    
                    command.Parameters.Add(new MySqlParameter("P_MOTHER_NAME", ad.mother_name  ));      
                    command.Parameters.Add(new MySqlParameter("P_MOTHER_PHONE", ad.mother_phone  ));    
                    command.Parameters.Add(new MySqlParameter("P_GUARDIAN_NAME", ad.guardian_name  ));  
                    command.Parameters.Add(new MySqlParameter("P_GUARDIAN_PHONE", ad.guardian_phone  ));
                    command.Parameters.Add(new MySqlParameter("P_GUARDIAN_ADDR", ad.guardian_addr  ));  
                    command.Parameters.Add(new MySqlParameter("P_PER_ADDR", ad.per_addr  ));            
                    command.Parameters.Add(new MySqlParameter("P_PER_CITY_TOWN", ad.per_city_town  ));  
                    command.Parameters.Add(new MySqlParameter("P_PER_DIST", ad.per_dist  ));            
                    command.Parameters.Add(new MySqlParameter("P_PER_STATE", ad.per_state  ));          
                    command.Parameters.Add(new MySqlParameter("P_PER_PIN", ad.per_pin  ));
                    command.Parameters.Add(new MySqlParameter("P_COMU_ADDR", ad.comu_addr  ));
                    command.Parameters.Add(new MySqlParameter("P_COMU_CITY_TOWN", ad.comu_city_town  ));
                    command.Parameters.Add(new MySqlParameter("P_COMU_DIST", ad.comu_dist));       
                    command.Parameters.Add(new MySqlParameter("P_COMU_STATE", ad.comu_state  ));   
                    command.Parameters.Add(new MySqlParameter("P_COMU_PIN", ad.comu_pin  ));       
                    command.Parameters.Add(new MySqlParameter("P_PAYMENT_STAT", ad.payment_stat  ));
                    command.Parameters.Add(new MySqlParameter("P_HOSTEL_REQ", ad.hostel_req));     
                    command.Parameters.Add(new MySqlParameter("P_FORM_CMPL_STAT", ad.form_cmpl_stat));
                    command.Parameters.Add(new MySqlParameter("P_APPROVAL_STAT", ad.approval_stat  ));
                    command.Parameters.Add(new MySqlParameter("P_REMARKS", ad.remarks));
                    command.Parameters.Add(new MySqlParameter("P_SUB1", ad.sub1 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB2", ad.sub2 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB3", ad.sub3 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB4", ad.sub4 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB5", ad.sub5 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB6", ad.sub6 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB7", ad.sub7 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB8", ad.sub8 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB9", ad.sub9 ));  
                    command.Parameters.Add(new MySqlParameter("P_SUB10", ad.sub10 ));
                    command.Parameters.Add(new MySqlParameter("P_PREV_SCHOOL", ad.prev_school ));
                    command.Parameters.Add(new MySqlParameter("P_PREV_BOARD", ad.prev_board ));  
                    command.Parameters.Add(new MySqlParameter("P_PREV_ROLL", ad.prev_roll ));    
                    command.Parameters.Add(new MySqlParameter("P_PREV_PASSYEAR", ad.prev_passyear ));
                    command.Parameters.Add(new MySqlParameter("P_PREV_DIV", ad.prev_div ));       
                    command.Parameters.Add(new MySqlParameter("P_PREV_PERCENT", ad.prev_percent ));
                    command.Parameters.Add(new MySqlParameter("P_PREV_CLASS", ad.prev_class ));   
                    command.Parameters.Add(new MySqlParameter("P_GUARDIAN_REL", ad.guardian_rel ));
                    command.Parameters.Add(new MySqlParameter("P_FATHER_QUAL", ad.father_qual )); 
                    command.Parameters.Add(new MySqlParameter("P_FATHER_OCU", ad.father_ocu ));   
                    command.Parameters.Add(new MySqlParameter("P_FATHER_DES", ad.father_des ));   
                    command.Parameters.Add(new MySqlParameter("P_MOTHER_QUAL", ad.mother_qual )); 
                    command.Parameters.Add(new MySqlParameter("P_MOTHER_OCU", ad.mother_ocu ));   
                    command.Parameters.Add(new MySqlParameter("P_MOTHER_DES", ad.mother_des ));   
                    command.Parameters.Add(new MySqlParameter("P_PER_LOC", ad.per_loc ));    
                    command.Parameters.Add(new MySqlParameter("P_PER_WARD", ad.per_ward ));  
                    command.Parameters.Add(new MySqlParameter("P_PER_PO", ad.per_po ));      
                    command.Parameters.Add(new MySqlParameter("P_COMU_LOC", ad.comu_loc ));  
                    command.Parameters.Add(new MySqlParameter("P_COMU_WARD", ad.comu_ward ));
                    command.Parameters.Add(new MySqlParameter("P_COMU_PO", ad.comu_po ));    
                    command.Parameters.Add(new MySqlParameter("P_PER_COMU_SAME", ad.per_comu_same ));
                    command.Parameters.Add(new MySqlParameter("P_YEAR", ad.year ));
                    command.Parameters.Add(new MySqlParameter("P_ORGL_USER", ad.orgl_user));
                    command.Parameters.Add(new MySqlParameter("P_ADM_ID", MySqlDbType.String));
                    command.Parameters.Add(new MySqlParameter("P_SERIAL_NO", MySqlDbType.Int32));
                    command.Parameters["P_ADM_ID"].Direction = ParameterDirection.Output;
                    command.Parameters["P_SERIAL_NO"].Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    var p_amd_id    = Convert.ToString(command.Parameters["P_ADM_ID"].Value);
                    var p_serial_no = Convert.ToString(command.Parameters["P_SERIAL_NO"].Value);                

                    ADMISSION adm = new ADMISSION();
                    adm.adm_id = Convert.ToString(p_amd_id);
                    adm.serial_no = Convert.ToInt32(p_serial_no);
                    
                   // return Convert.ToString(p_amd_id);
                    return adm;
                }
            }
        }

        internal string UpdateAdmission(ADMISSION adm)
        {
            using (var connection = MySqlDbConnection.NewConnection)
            {
                string query="   UPDATE ADMISSION          "
     + "   SET STREAM         = {0} ,"
     + "   FIRST_NAME     = {1} ,    "
     + "   LAST_NAME      = {2} ,    "
     + "   MIDDLE_NAME    = {3} ,    "
     + "   DOB            = {4} ,    "
     + "   PHONE          = {5} ,    "
     + "   EMAIL          = {6} ,    "
     + "   GENDER         = {7} ,    "
     + "   CATEGORY       = {8} ,    "
     + "   TRIBE          = {9} ,    "
     + "   MARITAL_STATUS = {10} ,   "
     + "   RELIGION       = {11} ,   "
     + "   NATIONALITY    = {12} ,   "
     + "   BLOOD_GROUP    = {13} ,   "
     + "   IDENT_MARK     = {14} ,   "
     + "   PHY_CHALLENGE  = {15} ,   "
     + "   FATHER_NAME    = {16}  ,  "
     + "   FATHER_PHONE   = {17}  ,  "
     + "   MOTHER_NAME    = {18}  ,  "
     + "   MOTHER_PHONE   = {19}  ,  "
     + "   GUARDIAN_NAME  = {20}  ,  "
     + "   GUARDIAN_PHONE = {21}  ,  "
     + "   GUARDIAN_ADDR  = {22}  ,  "
     + "   PER_ADDR       = {23}  ,  "
     + "   PER_CITY_TOWN  = {24}  ,  "
     + "   PER_DIST       = {25}  ,  "
     + "   PER_STATE      = {26}  ,  "
     + "   PER_PIN        = {27}  ,  "
     + "   COMU_ADDR      = {28}  ,  "
     + "   COMU_CITY_TOWN = {29}  ,  "
     + "   COMU_DIST      = {30}  ,  "
     + "   COMU_STATE     = {31}  ,  "
     + "   COMU_PIN       = {32}  ,  "
     + "   PAYMENT_STAT   = {33} ,   "
     + "   APPROVAL_STAT  = {34} ,   "
     + "   UPDT_USER      = {35} ,   "
     + "   HOSTEL_REQ     = {36} ,   "
     + "   FORM_CMPL_STAT = {37} ,   "
     + "   REMARKS        = {38} ,   "
     + "   CORE_SUBJ      = {39} ,   "
     + "   GEN_SUBJ       = {40},    "
     + "   SUB1           = {41},    "
     + "   SUB2           = {42},    "
     + "   SUB3           = {43},    "
     + "   SUB4           = {44},    "
     + "   SUB5           = {45},    "
     + "   SUB6           = {46},    "
     + "   SUB7           = {47},    "
     + "   SUB8           = {48},    "
     + "   SUB9           = {49},    "
     + "   SUB10          = {50},    "
     + "   PREV_SCHOOL    = {51},    "
     + "   PREV_BOARD     = {52},    "
     + "   PREV_ROLL      = {53},    "
     + "   PREV_PASSYEAR  = {54},    "
     + "   PREV_DIV       = {55},    "
     + "   PREV_PERCENT   = {56},    "
     + "   PREV_CLASS     = {57},    "
     + "   GUARDIAN_REL   = {58},    "
     + "   FATHER_QUAL    = {59},    "
     + "   FATHER_OCU     = {60},    "
     + "   FATHER_DES     = {61},    "
     + "   MOTHER_QUAL    = {62},    "
     + "   MOTHER_OCU     = {63},    "
     + "   MOTHER_DES     = {64},    "
     + "   PER_LOC        = {65},    "
     + "   PER_WARD       = {66},    "
     + "   PER_PO         = {67},    "
     + "   COMU_LOC       = {68},    "
     + "   COMU_WARD      = {69},    "
     + "   COMU_PO        = {70},    "
     + "   PER_COMU_SAME  = {71},    "
     + "   YEAR           = {72},    "
     + "   SESSION        = {73},    "
     + "   ADMIN_IN_CLASS = {74},    "
     + "   CLASS          = {75},    "
     + "   REGN_NO        = {76},     "
     +"    DEL_FLG        = {77} ,     "
      +"    UPDT_STAMP        = SYSDATE()     "
     + " WHERE   ADM_ID    = {78}      ";
            _statement = string.Format(query,                                                                                         
                 string.IsNullOrWhiteSpace(adm.stream)           ? "STREAM" : string.Concat("'", adm.stream, "'"),              
                 string.IsNullOrWhiteSpace(adm.first_name)       ? "FIRST_NAME" : string.Concat("'", adm.first_name, "'"),      
                 string.IsNullOrWhiteSpace(adm.last_name)        ? "LAST_NAME" : string.Concat("'", adm.last_name, "'"),        
                 string.IsNullOrWhiteSpace(adm.middle_name)      ? "MIDDLE_NAME" : string.Concat("'", adm.middle_name, "'"),    
                 adm.dob.HasValue                                ? string.Concat("STR_TO_DATE('", adm.dob.Value.ToString("dd:MM:yyyy HH:mm:ss"), "',", "'%d:%m:%Y %H:%i:%S')") : "DOB",
                 string.IsNullOrWhiteSpace(adm.phone)            ? "PHONE" : string.Concat("'", adm.phone, "'"),                  
                 string.IsNullOrWhiteSpace(adm.email)            ? "EMAIL" : string.Concat("'", adm.email, "'"),                  
                 string.IsNullOrWhiteSpace(adm.gender)           ? "GENDER" : string.Concat("'", adm.gender, "'"),                
                 string.IsNullOrWhiteSpace(adm.category)         ? "CATEGORY" : string.Concat("'", adm.category, "'"),            
                 string.IsNullOrWhiteSpace(adm.tribe)            ? "TRIBE" : string.Concat("'", adm.tribe, "'"),                  
                 string.IsNullOrWhiteSpace(adm.marital_status)   ? "MARITAL_STATUS" : string.Concat("'", adm.marital_status, "'"),
                 string.IsNullOrWhiteSpace(adm.religion)         ? "RELIGION" : string.Concat("'", adm.religion, "'"),            
                 string.IsNullOrWhiteSpace(adm.nationality)      ? "NATIONALITY" : string.Concat("'", adm.nationality, "'"),      
                 string.IsNullOrWhiteSpace(adm.blood_group)      ? "BLOOD_GROUP" : string.Concat("'", adm.blood_group, "'"),      
                 string.IsNullOrWhiteSpace(adm.ident_mark)       ? "IDENT_MARK" : string.Concat("'", adm.ident_mark, "'"),        
                 string.IsNullOrWhiteSpace(adm.phy_challenge)    ? "PHY_CHALLENGE" : string.Concat("'", adm.phy_challenge, "'"),  
                 string.IsNullOrWhiteSpace(adm.father_name)      ? "FATHER_NAME" : string.Concat("'", adm.father_name, "'"),      
                 string.IsNullOrWhiteSpace(adm.father_phone)     ? "FATHER_PHONE" : string.Concat("'", adm.father_phone, "'"),    
                 string.IsNullOrWhiteSpace(adm.mother_name)      ? "MOTHER_NAME" : string.Concat("'", adm.mother_name, "'"),      
                 string.IsNullOrWhiteSpace(adm.mother_phone)     ? "MOTHER_PHONE" : string.Concat("'", adm.mother_phone, "'"),    
                 string.IsNullOrWhiteSpace(adm.guardian_name)    ? "GUARDIAN_NAME" : string.Concat("'", adm.guardian_name, "'"),  
                 string.IsNullOrWhiteSpace(adm.guardian_phone)   ? "GUARDIAN_PHONE" : string.Concat("'", adm.guardian_phone, "'"),
                 string.IsNullOrWhiteSpace(adm.guardian_addr)    ? "GUARDIAN_ADDR" : string.Concat("'", adm.guardian_addr, "'"),  
                 string.IsNullOrWhiteSpace(adm.per_addr)         ? "PER_ADDR" : string.Concat("'", adm.per_addr, "'"),            
                 string.IsNullOrWhiteSpace(adm.per_city_town)    ? "PER_CITY_TOWN" : string.Concat("'", adm.per_city_town, "'"),  
                 string.IsNullOrWhiteSpace(adm.per_dist)         ? "PER_DIST" : string.Concat("'", adm.per_dist, "'"),            
                 string.IsNullOrWhiteSpace(adm.per_state)        ? "PER_STATE" : string.Concat("'", adm.per_state, "'"),          
                 string.IsNullOrWhiteSpace(adm.per_pin)          ? "PER_PIN" : string.Concat("'", adm.per_pin, "'"),              
                 string.IsNullOrWhiteSpace(adm.comu_addr)        ? "COMU_ADDR" : string.Concat("'", adm.comu_addr, "'"),          
                 string.IsNullOrWhiteSpace(adm.comu_city_town)   ? "COMU_CITY_TOWN" : string.Concat("'", adm.comu_city_town, "'"),
                 string.IsNullOrWhiteSpace(adm.comu_dist)        ? "COMU_DIST" : string.Concat("'", adm.comu_dist, "'"),          
                 string.IsNullOrWhiteSpace(adm.comu_state)       ? "COMU_STATE" : string.Concat("'", adm.comu_state, "'"),        
                 string.IsNullOrWhiteSpace(adm.comu_pin)         ? "COMU_PIN" : string.Concat("'", adm.comu_pin, "'"),            
                 string.IsNullOrWhiteSpace(adm.payment_stat)     ? "PAYMENT_STAT" : string.Concat("'", adm.payment_stat, "'"),    
                 string.IsNullOrWhiteSpace(adm.approval_stat)    ? "APPROVAL_STAT" : string.Concat("'", adm.approval_stat, "'"),  
                 string.IsNullOrWhiteSpace(adm.updt_user)        ? "UPDT_USER" : string.Concat("'", adm.updt_user, "'"),          
                 string.IsNullOrWhiteSpace(adm.hostel_req)       ? "HOSTEL_REQ" : string.Concat("'", adm.hostel_req, "'"),        
                 string.IsNullOrWhiteSpace(adm.form_cmpl_stat)   ? "FORM_CMPL_STAT" : string.Concat("'", adm.form_cmpl_stat, "'"),
                 string.IsNullOrWhiteSpace(adm.remarks)          ? "REMARKS" : string.Concat("'", adm.remarks, "'"),              
                 string.IsNullOrWhiteSpace(adm.core_subj)        ? "CORE_SUBJ" : string.Concat("'", adm.core_subj, "'"),          
                 string.IsNullOrWhiteSpace(adm.gen_subj)         ? "GEN_SUBJ" : string.Concat("'", adm.gen_subj, "'"),            
                 string.IsNullOrWhiteSpace(adm.sub1)             ? "SUB1" : string.Concat("'",adm.sub1          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub2)             ? "SUB2" : string.Concat("'",adm.sub2          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub3)             ? "SUB3" : string.Concat("'",adm.sub3          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub4)             ? "SUB4" : string.Concat("'",adm.sub4          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub5)             ? "SUB5" : string.Concat("'",adm.sub5          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub6)             ? "SUB6" : string.Concat("'",adm.sub6          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub7)             ? "SUB7" : string.Concat("'",adm.sub7          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub8)             ? "SUB8" : string.Concat("'",adm.sub8          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub9)             ? "SUB9" : string.Concat("'",adm.sub9          ,"'"),            
                 string.IsNullOrWhiteSpace(adm.sub10)            ? "SUB10" : string.Concat("'",adm.sub10         ,"'"),           
                 string.IsNullOrWhiteSpace(adm.prev_school)      ? "PREV_SCHOO" : string.Concat("'",adm.prev_school   ,"'"),      
                 string.IsNullOrWhiteSpace(adm.prev_board)       ? "PREV_BOARD" : string.Concat("'",adm.prev_board    ,"'"),      
                 string.IsNullOrWhiteSpace(adm.prev_roll)        ? "PREV_ROLL" : string.Concat("'",adm.prev_roll     ,"'"),       
                 string.IsNullOrWhiteSpace(adm.prev_passyear)    ? "PREV_PASSYEAR" : string.Concat("'",adm.prev_passyear ,"'"),   
                 string.IsNullOrWhiteSpace(adm.prev_div)         ? "PREV_DIV" : string.Concat("'",adm.prev_div      ,"'"),        
                 string.IsNullOrWhiteSpace(adm.prev_percent)     ? "PREV_PERCENT" : string.Concat("'",adm.prev_percent  ,"'"),    
                 string.IsNullOrWhiteSpace(adm.prev_class)       ? "PREV_CLASS" : string.Concat("'",adm.prev_class    ,"'"),      
                 string.IsNullOrWhiteSpace(adm.guardian_rel)     ? "GUARDIAN_REL" : string.Concat("'",adm.guardian_rel  ,"'"),    
                 string.IsNullOrWhiteSpace(adm.father_qual)      ? "FATHER_QUAL" : string.Concat("'",adm.father_qual   ,"'"),     
                 string.IsNullOrWhiteSpace(adm.father_ocu)       ? "FATHER_OCU" : string.Concat("'",adm.father_ocu    ,"'"),      
                 string.IsNullOrWhiteSpace(adm.father_des)       ? "FATHER_DES" : string.Concat("'",adm.father_des    ,"'"),      
                 string.IsNullOrWhiteSpace(adm.mother_qual)      ? "MOTHER_QUAL" : string.Concat("'",adm.mother_qual   ,"'"),     
                 string.IsNullOrWhiteSpace(adm.mother_ocu)       ? "MOTHER_OCU" : string.Concat("'",adm.mother_ocu    ,"'"),      
                 string.IsNullOrWhiteSpace(adm.mother_des)       ? "MOTHER_DES" : string.Concat("'",adm.mother_des    ,"'"),      
                 string.IsNullOrWhiteSpace(adm.per_loc)          ? "PER_LOC" : string.Concat("'",adm.per_loc       ,"'"),         
                 string.IsNullOrWhiteSpace(adm.per_ward)         ? "PER_WARD" : string.Concat("'",adm.per_ward      ,"'"),        
                 string.IsNullOrWhiteSpace(adm.per_po)           ? "PER_PO" : string.Concat("'",adm.per_po        ,"'"),          
                 string.IsNullOrWhiteSpace(adm.comu_loc)         ? "COMU_LOC" : string.Concat("'",adm.comu_loc      ,"'"),        
                 string.IsNullOrWhiteSpace(adm.comu_ward)        ? "COMU_WARD" : string.Concat("'",adm.comu_ward     ,"'"),       
                 string.IsNullOrWhiteSpace(adm.comu_po)          ? "COMU_PO" : string.Concat("'",adm.comu_po       ,"'"),         
                 string.IsNullOrWhiteSpace(adm.per_comu_same)    ? "PER_COMU_SAME" : string.Concat("'",adm.per_comu_same ,"'"),
                 string.IsNullOrWhiteSpace(adm.year)             ? "YEAR" : string.Concat("'",adm.year          ,"'"),
                 string.IsNullOrWhiteSpace(adm.session)          ? "SESSION" : string.Concat("'",adm.session       ,"'"),
                 string.IsNullOrWhiteSpace(adm.admin_in_class)   ? "ADMIN_IN_CLASS" : string.Concat("'",adm.admin_in_class,"'"),
                 string.IsNullOrWhiteSpace(adm.cls)              ? "CLASS" : string.Concat("'",adm.cls         ,"'"),
                 string.IsNullOrWhiteSpace(adm.regn_no)          ? "REGN_NO" : string.Concat("'",adm.regn_no       ,"'"),
                 string.IsNullOrWhiteSpace(adm.del_flg)          ? "DEL_FLG" : string.Concat("'",adm.del_flg       ,"'"),
                 string.IsNullOrWhiteSpace(adm.adm_id)           ? "ADM_ID" : string.Concat("'", adm.adm_id, "'"));
                  using (var command = MySqlDbConnection.Command(connection, _statement))
                {
                    try{
                    command.ExecuteNonQuery();
                    return "0";
                    }
                    catch(Exception ex)
                    {
                        return ex.ToString();

                    }

                }
            }


            
        }
    }



}



