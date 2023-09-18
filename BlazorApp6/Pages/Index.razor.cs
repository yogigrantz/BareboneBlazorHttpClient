using BlazorApp6.Data;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace BlazorApp6.Pages
{
    public partial class Index : ComponentBase
    {
        public List<SampleDTO> SampleData { get; set; }
        public Exception Exception { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TupleDTO t = await HttpClass.GetAsync<TupleDTO>("https://www.yogigrantz.com/api/webapidemo", null);

            if (t.Item5 == null)
            {
                JObject jo = t.Item3;

                SampleData = jo["Result"].ToObject<List<SampleDTO>>();
            }
            else
            {
                Exception = t.Item5;
                SampleData = new List<SampleDTO>();
            }
           
        }
    }
}
