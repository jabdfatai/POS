using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Response
{
    public class CommandResponse
    {
        public int ResponseValue { get; set; }
        public string misc { get; set; }
        public string misc2 { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public bool IsSuccessful { get; set; }

        public static CommandResponse Load(int responsevalue)
        {
            if (responsevalue > 0)
            {
                return new CommandResponse
                {
                    ResponseValue = responsevalue,
                    IsSuccessful = true,
                    ResponseCode = "200",
                    ResponseDescription = "Operation Successful"
                };
            }
            else
            {
                return new CommandResponse
                {
                    ResponseValue = responsevalue,
                    IsSuccessful = false,
                    ResponseCode = "400",
                    ResponseDescription = "No Records Affected"
                };
            }
        }


        public static CommandResponse Load(CommandResponse commandResponse)
        {
            if (commandResponse.IsSuccessful)
            {
                return new CommandResponse
                {
                    ResponseValue = commandResponse.ResponseValue,
                    IsSuccessful = true,
                    misc = commandResponse.misc,
                    misc2 = commandResponse.misc2,
                    ResponseCode = "200",
                    ResponseDescription = "Operation Successful"
                };
            }
            else
            {
                return new CommandResponse
                {
                    ResponseValue = commandResponse.ResponseValue,
                    IsSuccessful = false,
                    misc = commandResponse.misc,
                    misc2 = commandResponse.misc2,
                    ResponseCode = "400",
                    ResponseDescription = "Operation Failed"
                };
            }
        }


        public static CommandResponse Load(bool responsevalue)
        {
            if (responsevalue)
            {
                return new CommandResponse
                {
                    ResponseValue = 1,
                    IsSuccessful = true,
                    ResponseCode = "200",
                    ResponseDescription = "Operation Successful"
                };
            }
            else
            {
                return new CommandResponse
                {
                    ResponseValue = 0,
                    IsSuccessful = false,
                    ResponseCode = "400",
                    ResponseDescription = "No Records Affected"
                };
            }
        }


    }
    public class QueryResponse<T>
    {
        public T Data { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public bool HasResult { get; set; }

        public static QueryResponse<T> Load(T Data)
        {
            if (Data != null)
            {
                return new QueryResponse<T>
                {
                    Data = Data,
                    HasResult = true,
                    ResponseCode = "200",
                    ResponseDescription = "Operation Successful"
                };
            }
            else
            {
                return new QueryResponse<T>
                {
                    Data = Data,
                    HasResult = false,
                    ResponseCode = "200",
                    ResponseDescription = "No Record Found"
                };
            }
        }

    }
}
