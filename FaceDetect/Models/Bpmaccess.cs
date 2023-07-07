namespace FaceDetect.Models
{
    public class Bpmaccess
    {
        public class BPMRequest
        {
            public string Taskid { get; set; }
            public string source { get; set; }
        }
        public class BPMResponse
        {
            public string Taskid { get; set; }
            public string ISACTIVE { get; set; }
            public string USERGRP { get; set; }
            public string BPMUSERNAME { get; set; }
            public string USERID { get; set; }
            public string BPMBRANCHCODE { get; set; }
            public string BPMBRANCHNAME { get; set; }
            public string LIFEASIAUSERID { get; set; }
            public string MENUNAME { get; set; }
            public string BUSSINESSDATE { get; set; }
            public string BPMUSERBRANCH { get; set; }
            public string USERNAME { get; set; }
            public int CARRIERCODE { get; set; }
            public int USERROLE { get; set; }
            public string VALIDUSER { get; set; }
            public string REDIRECTURL { get; set; }


        }

        public partial class LF_OFAC
        {
            public int SrNo { get; set; }
            public string FullName { get; set; }
            public string Publish_Date { get; set; }
            public Nullable<double> Record_Count { get; set; }
            public Nullable<double> uid { get; set; }
            public string lastName { get; set; }
            public string sdnType { get; set; }
            public string program { get; set; }
            public Nullable<double> uid2 { get; set; }
            public string type { get; set; }
            public string category { get; set; }
            public string lastName3 { get; set; }
            public string firstName { get; set; }
            public Nullable<double> uid4 { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string address1 { get; set; }
            public string postalCode { get; set; }
            public string address2 { get; set; }
            public string stateOrProvince { get; set; }
            public string address3 { get; set; }
            public string firstName5 { get; set; }
            public string title { get; set; }
            public string uid6 { get; set; }
            public string dateOfBirth { get; set; }
            public string mainEntry { get; set; }
            public string uid7 { get; set; }
            public string placeOfBirth { get; set; }
            public string mainEntry8 { get; set; }
            public string uid9 { get; set; }
            public string idType { get; set; }
            public string idNumber { get; set; }
            public string idCountry { get; set; }
            public string issueDate { get; set; }
            public string expirationDate { get; set; }
            public string remarks { get; set; }
            public string callSign { get; set; }
            public string vesselType { get; set; }
            public string vesselFlag { get; set; }
            public string vesselOwner { get; set; }
            public string tonnage { get; set; }
            public string grossRegisteredTonnage { get; set; }
            public string uid10 { get; set; }
            public string country11 { get; set; }
            public string mainEntry12 { get; set; }
            public string uid13 { get; set; }
            public string country14 { get; set; }
            public string mainEntry15 { get; set; }
        }

    }
}
