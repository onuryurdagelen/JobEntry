using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Business.Utilities.Responses
{
	public class ServiceResponse<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public int StatusCode { get; set; }
		public T Data { get; set; }
		public List<string> Errors { get; set; }

        public ServiceResponse()
        {
            Errors = new List<string>();
			Success = true;
			StatusCode = 200;
        }
        
        public ServiceResponse(bool success,T data)
        {
            Success = success;
			StatusCode=200;
            Data = data;
        }
		public ServiceResponse(bool succcess,int statusCode, T data,string message)
		{
			Success = succcess;
			StatusCode=statusCode;
			Data = data;
			Message = message;
		}

		public void AddError(string error) => Errors.Add(error);
		public void AddErrors(List<string> errors) => Errors.AddRange(errors);

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
	
}
