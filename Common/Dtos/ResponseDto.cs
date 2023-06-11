// class named ResponseDto. Contains Data (Generic typed) and Errors (list of string) and IsSuccess booleian property

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.Dtos
{
    public class ResponseDto<T>
    {
        // private constructor
        private ResponseDto()
        {
        }

        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }
        
        [JsonIgnore]
        public int StatusCode { get; set; }

        // static method to create a new instance of ResponseDto
        // with IsSuccess set to true and Status Code set to 200
        public static ResponseDto<T> Success(T data)
        {
            return new ResponseDto<T>
            {
                Data = data,
                IsSuccess = true,
                StatusCode = 200
            };
        }

        // static method to create a new instance of ResponseDto
        // success, data is null, StatusCode is undocumented
        public static ResponseDto<T> Success()
        {
            return new ResponseDto<T>
            {
                Data = default,
                IsSuccess = true,
                StatusCode = 204
            };
        }

        // static method to create a new instance of ResponseDto
        // gets error messages and status code
        public static ResponseDto<T> Failure(List<string> errors, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                IsSuccess = false,
                StatusCode = statusCode
            };
        }

        // static method to create a new instance of ResponseDto
        // gets one error message and status code
        public static ResponseDto<T> Failure(string error, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string> {error},
                IsSuccess = false,
                StatusCode = statusCode
            };
        }

    }
}