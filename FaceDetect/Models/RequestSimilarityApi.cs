namespace FaceDetect.Models
{
    public class RequestSimilarityApi
    {
        public string photofaceid { get; set; }
        public string applicationnumber { get; set; }
        public string source { get; set; }
        public string[] facelist { get; set; }
    }
}
