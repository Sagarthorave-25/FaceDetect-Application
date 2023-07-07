namespace FaceDetect.Models
{
    public class ResponseFaceDetection
    {
        public string errorcode { get; set; }
        public string errormessage { get; set; }
        public string faceId { get; set; }
        public Facedetectresponse[] facedetectresponse { get; set; }
    }
    public class Facedetectresponse { 
    public string faceId { get; set; }
    public FaceRectangle faceRectangle { get; set; }

    }
    public class FaceRectangle
    {
        public int height;
        public int width;
        public int left;
        public int top;
    }
}
