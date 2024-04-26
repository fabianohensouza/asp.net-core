namespace PartyInvites.Models
{
    public static class Repository
    {
        private static List<GuestResponse> responses = new();

        //This property create a public access to the response data
        public static IEnumerable<GuestResponse> Responses => responses;
        public static void AddResponse(GuestResponse response)
        {
            Console.WriteLine(response);
            responses.Add(response);
        }
    }
}
