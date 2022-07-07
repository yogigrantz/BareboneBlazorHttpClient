# BareboneBlazorHttpClient
Barebone Blazor UI connecting to WebAPI with HttpClient GetAsync and PostAsync, expecting generic Tuple of 5 items

The WebAPI (source not included) will always output Tuple of 5 items:
Item1: Custom /error message
Item2: Return code from database
Item3: Json representation of Sql DataSet
Item4: Json representation of Dictionary<string, object>
Item5: Exception object

Dependency Injection of HttpClass with two methods: GetAsync and PostAsync

Showing sample output of part of SampleDTO

