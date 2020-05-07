using System;
using System.Collections.Generic;

public class Request : IRequest
{
    public int id{get; set;}

    public Dictionary<string, int> GetAllRequests()
    {
        throw new NotImplementedException();
    }

    public void MakeRequest(string id)
    {
       // Dictionary<string, int> requests
    }

    


}