namespace CarDispensary.Controllers
{
    internal class RegistrationResponse
    {
        public string Token { get; set; } 

        public string Status { get; set; }
        public string Message { get; set; }

        public int CustomerId { get; set; } 
    }
}