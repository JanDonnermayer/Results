using System;
using System.Threading.Tasks;
using static Results.Result;


namespace Results.SampleApp
{
    class Program
    {
        static Task Main(string[] args) =>
            GetGreetingAsync()
                .HandleAsync(
                    dataHandler: Console.WriteLine,
                    errorHandler: Console.Error.WriteLine
                );

        private static async Task<IResult<string>> GetGreetingAsync()
        {
            await Task.Yield();

            try
            {
                if (DateTime.Now.Millisecond % 2 == 1)
                    throw new Exception("An error occurred :(");

                return Ok("Hello World!");

            }
            catch (Exception ex)
            {
                return Error<string>(ex);
            }
        }
    }
}
