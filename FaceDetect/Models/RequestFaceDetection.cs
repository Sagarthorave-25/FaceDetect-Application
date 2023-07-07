namespace FaceDetect.Models
{
    public class RequestFaceDetection
    {
         public IFormFile[] imgfile { get; set; }
        public string source { get; set; }
        public string applicationnumber { get; set; }
    }
}
