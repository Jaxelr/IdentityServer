# IdentityServer implementation

## Api Authentication Challenge (.Net)

The Api must include the following AspnetCore library:

`Install-Package Microsoft.AspNetCore.Authentication.JwtBearer`

On the Startup.cs file add the following instructions:

```c#
    public void ConfigureServices(IServiceCollection services)
    {
        //
        //The rest of your code goes above here...
        //
        services.AddAuthorization();
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "<<AuthServerGoesHere>>";   
                options.RequireHttpsMetadata = false;           //If its on HTTP
                options.Audience = "<<YourScopeGoesHere>>";
            });
    }
```

And on your controllers add the `[Authorization]` attribute

## Client consumption (.Net)

The client must use the following nuget library:

`Install-Package IdentityModel`

This is a sample installation, it assumes that the client is still on http, hopefully this will change:

``` c#
    //Put Auth production server here
    string address = "";
    // discover endpoints from metadata
    var client = new HttpClient();

    var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
    {
        Address = address,
        Policy = new DiscoveryPolicy() { RequireHttps = false } //currently only available on http
    }).ConfigureAwait(false);

    if (disco.IsError)
    {
        Console.WriteLine(disco.Error);
        return;
    }

    // request token
    var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
    {
        Address = disco.TokenEndpoint,
        ClientId = "<ClientIdGoesHere>",
        ClientSecret = "<ClientSecretGoesHere>",

        Scope = "<ScopeGoesHere>"
    }).ConfigureAwait(false);

    if (tokenResponse.IsError)
    {
        Console.WriteLine(tokenResponse.Error);
        return;
    }

    //This token has to be added to an Authorization Bearer header in order for the API to challenge it.
    Console.WriteLine(tokenResponse.Json);
    Console.WriteLine("\n\n");

    Console.Read();
```