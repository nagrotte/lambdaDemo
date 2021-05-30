using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace lambdaDemo
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {

            string name = "no name";

            if (request.QueryStringParameters != null && request.QueryStringParameters.ContainsKey("name"))
            {
                name = request.QueryStringParameters["name"];

            }
                
                context.Logger.Log($"Got Name: {name}");
            return new APIGatewayProxyResponse
            {

                StatusCode = 200,
                Body = $"Nmae Passed:{name}"
            };

            
            
        }
    }
}
