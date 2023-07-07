using FaceDetect.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace FaceDetect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string source = string.Empty;
        string ApplicationNum = string.Empty;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpPost]
        public List<Result> FindSimilarity(RequestSimilarityApi requestSimilarityApi)
        {
            List<Result> SimilarityPercentage = new List<Result>();
            string msg=string.Empty;
            try
            {
                string apiUrl = "http://172.20.8.11:8081/api/matchFace/azurefacesimilarity";
                var faceid = requestSimilarityApi.facelist[0].ToString().Split(",");
              
                StringBuilder sp = new StringBuilder();
                sp.Append("{");
                sp.Append("\"applicationnumber\":\"" + requestSimilarityApi.applicationnumber + "\",");
                sp.Append("\"source\":\"" + requestSimilarityApi.source + "\",");
                sp.Append("\"photofaceid\":\"" + requestSimilarityApi.photofaceid + "\",");
                sp.Append("\"facelist\":[");
                for (int x = 0; x < faceid.Count(); x++)
                {
                    //sp.Append("\"");
                    sp.Append("\"" + faceid[x] + "\"");
                    if (x != faceid.Count() - 1)
                    {
                        sp.Append(",");
                    }
                }
               // sp.=sp.ToString().TrimEnd(',');
                sp.Append("]");
                sp.Append("}");
                string inputJson = sp.ToString();
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(apiUrl));
                httpRequest.ContentType = "application/json";
                httpRequest.Method = "POST";

                byte[] bytes = Encoding.UTF8.GetBytes(inputJson);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    using (Stream stream = httpResponse.GetResponseStream())
                    {
                        msg = (new StreamReader(stream)).ReadToEnd();
                        ResponseSimilarityApi resp = JsonConvert.DeserializeObject<ResponseSimilarityApi>(msg);
                        for (int i = 0; i < resp.result.Length; i++)
                        {

                            int confidence= (int)Convert.ToDouble(resp.result[i].confidence)*100;
                            // string faceId = resp.result[i].faceId;

                            // SimilarityPercentage.Add(confidence,faceId);
                            SimilarityPercentage.Add(new Result { faceId = resp.result[i].faceId, confidence = confidence.ToString() } );
                          // SimilarityPercentage.Add(new Item({ Id = 2, Name = "Hat", Description = "Test" });


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg=ex.Message;
            }
            return SimilarityPercentage;
        }
        [HttpPost]
        public string SingleUploadFile(RequestFaceDetection requestFace)
        {
            try
            {

                var client = new RestClient("http://172.20.8.11:8081/api/detectFace/generate/azurefaceid");
                List<string> uploadedFiles = new List<string>();
                source = requestFace.source.ToString().Trim();
                ApplicationNum = requestFace.applicationnumber.ToString().Trim();
                foreach (var postedFile in requestFace.imgfile)
                {

                    var request = new RestRequest("http://172.20.8.11:8081/api/detectFace/generate/azurefaceid", Method.Post);

                    var fileName = this.Request.Form.Files[0].FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    //                string fileName1 = Path.GetFileName(postedFile.FileName);
                    string Filepath1 = filePath + fileName;
                    using (FileStream stream = new FileStream(Path.Combine(Filepath1), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);

                    }
                    request.AddFile("file", Path.Combine(Filepath1));
                    request.AddParameter("source", source);
                    request.AddParameter("applicationnumber", ApplicationNum);
                    RestResponse response = client.Execute(request);
                    ResponseFaceDetection faceResp = JsonConvert.DeserializeObject<ResponseFaceDetection>(response.Content);

                    return faceResp.faceId;
                }


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return "error";
            //return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public List<string> MultiUploadFile(RequestFaceDetection requestFace)
        {
            List<string> FaceId = new List<string>();
            try
            {

                var client = new RestClient("http://172.20.8.11:8081/api/detectFace/generate/azurefaceid");
                List<string> uploadedFiles = new List<string>();
                source = requestFace.source.ToString().Trim();
                ApplicationNum = requestFace.applicationnumber.ToString().Trim();
                foreach (var postedFile in requestFace.imgfile)
                {

                    var request = new RestRequest("http://172.20.8.11:8081/api/detectFace/generate/azurefaceid", Method.Post);

                    var fileName = this.Request.Form.Files[0].FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    //                string fileName1 = Path.GetFileName(postedFile.FileName);
                    string Filepath1 = filePath + fileName;
                    using (FileStream stream = new FileStream(Path.Combine(Filepath1), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);

                    }
                    request.AddFile("file", Path.Combine(Filepath1));
                    request.AddParameter("source", source);
                    request.AddParameter("applicationnumber", ApplicationNum);
                    RestResponse response = client.Execute(request);
                    ResponseFaceDetection faceResp = JsonConvert.DeserializeObject<ResponseFaceDetection>(response.Content);

                    FaceId.Add(faceResp.faceId);
                    //fuUpload.SaveAs(Filepath1);
                    // return ;
                }


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return FaceId;
            //return RedirectToAction("Index", "Home");

        }
        //public async Task<IActionResult> UploadFile(List<IFormFile> FormFile)

        //{
        //    var client = new RestClient("http://172.20.8.11:8081/api/detectFace/generate/azurefaceid");
        //    List<string> uploadedFiles = new List<string>();
        //    foreach (var postedFile in FormFile)
        //    {
        //        var request = new RestRequest("http://172.20.8.11:8081/api/detectFace/generate/azurefaceid", Method.Post);

        //        var fileName = this.Request.Form.Files[0].FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\", fileName);
        //        if (!Directory.Exists(filePath))
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        //                string fileName1 = Path.GetFileName(postedFile.FileName);
        //        string Filepath1 = filePath + "\\" + fileName;
        //        using (FileStream stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
        //        {
        //            postedFile.CopyTo(stream);
        //            uploadedFiles.Add(fileName);
        //        }
        //        request.AddFile("file", Path.Combine(Filepath1));
        //        RestResponse response = client.Execute(request);

        //    }

        //    return RedirectToAction("Index", "Home");

        //}
    }
}