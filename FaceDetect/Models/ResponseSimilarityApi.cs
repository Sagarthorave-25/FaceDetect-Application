namespace FaceDetect.Models
{
    public class ResponseSimilarityApi
    {
        public string errorcode { get; set; }
        public string errormessage { get; set; }
        public Result[] result { get; set; }
        public string status { get; set; }
    }
    public class Result
    {

        public string confidence { get; set; }
        public string error { get; set; }
        public string faceId { get; set; }
    }

}
