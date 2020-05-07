using System;
using System.Collections.Generic;

public interface IRequest
{
    void MakeRequest(string id);
    Dictionary<string, int> GetAllRequests();
}