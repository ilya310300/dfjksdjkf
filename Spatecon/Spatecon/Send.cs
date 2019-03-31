using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Spatecon
{
    public class ExceptionInfo
    {
        public Exception exception { get; set; }
        public object info { get; set; }
    }

    [DataContract]
    public class Info
    {
        [DataMember] public string image { get; set; }
    }

    public static class GetRequest
    {
        public static ExceptionInfo GET(string Data, object classInfo)
        {
            ExceptionInfo exceptionInfo = new ExceptionInfo();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://food.spatecon.ru/api/" + Data);
                WebResponse response = request.GetResponse();
                Stream dataSteam = response.GetResponseStream();
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(classInfo.GetType());
                exceptionInfo.info = jsonFormatter.ReadObject(dataSteam);
                exceptionInfo.exception = null;
                return exceptionInfo;
            }
            catch (Exception ex)
            {
                exceptionInfo.info = null;
                exceptionInfo.exception = ex;
                return exceptionInfo;
            }
        }

    }
}
