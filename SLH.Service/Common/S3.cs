using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLH.Service.Common
{
    public class S3
    {
        private AmazonS3Client _s3Client;
        private readonly string _BucketName = "";
        private readonly string _accessKey = "";
        private readonly string _secretKey = "";

        public S3()
        {
            _BucketName = "hbn-static";
            _accessKey = "AKIASDNOGOEMFHCKFZHM";
            _secretKey = "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";
            _s3Client = new AmazonS3Client(_accessKey, _secretKey, RegionEndpoint.USEast2);
        }

        public string GeneratePreSignedVideoURL(string key, DateTime expiryTime)
        {
            string urlString = "";

            //check extension is valid
            string mimeType = FileLogic.CalculateMimeType(key);
            if (string.IsNullOrWhiteSpace(mimeType))
                return null;


            GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
            {
                BucketName = _BucketName,
                Key = key,
                Expires = expiryTime,
                ContentType = mimeType,
                Verb = HttpVerb.PUT,
                Protocol = Protocol.HTTPS
            };
            urlString = _s3Client.GetPreSignedURL(request1);

            return urlString;
        }
    }
}
