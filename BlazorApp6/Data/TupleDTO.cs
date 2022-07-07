using Newtonsoft.Json.Linq;

namespace BlazorApp6.Data;

public class TupleDTO
{
    public string Item1 { get; set; }
    public int Item2 { get; set; }
    public  JObject Item3 { get; set; }
    public Dictionary<string, object> Item4 { get; set; }
    public Exception Item5 { get; set; }
}
