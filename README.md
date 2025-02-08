# ExternalApiConsumer

<span>
This is a simple, yet slightly overengineered, weekend project designed to consume an external API using the <a href="https://github.com/reactiveui/refit">Refit</a> NuGet package.</br>
This ASP.NET Core Web API interacts with another <a href="https://github.com/JGMelon22/DataFakerDemo">external Web API</a>, built with Java + Spring and deployed on <a href="https://render.com/">Render</a>. Note that the external API is on Render's free tier, which spins down after periods of inactivity.
</span>

<h3>Tech Stack</h3>
<div style="display: flex; gap: 10px;">
    <img height="32" width="32" src="https://cdn.simpleicons.org/dotnet" alt="dotnet" />&nbsp;
    <img height="32" width="32" src="https://cdn.simpleicons.org/swagger" alt="swagger" />&nbsp;
    <img height="32" width="32" src="https://cdn.simpleicons.org/zedindustries" alt="zedindustries" />&nbsp;
</div>

### Dependencies (NuGet Packages)
<ul>
    <li>Base Project
        <ul>
            <li>Refit</li>
            <li>MediatR</li>
            <li>Refit.HttpClientFactory</li>
            <li>Swashbuckle.AspNetCore</li>
        </ul>
    </li></br>
    <li>Unit Tests
        <ul>
            <li>coverlet.collector</li>
            <li><a href="https://github.com/shouldly/shouldly">Shouldly<a/></li>
            <li>Microsoft.NET.Test.Sdk</li>
            <li>Moq</li>
            <li>xunit</li>
            <li>xunit.runner.visualstudio</li>
        </ul>
    </li>
</ul>

<table style="width: 100%; text-align: center; border-spacing: 20px;">
  <tr>
    <td style="border: 1px solid #ddd; padding: 10px;">
      <img src="https://github.com/user-attachments/assets/70e41027-b268-4556-a35e-a7e1c935fc38" alt="Zed Editor" width="870">
    </td>
  </tr>
  <tr>
    <td style="border: 1px solid #ddd; padding: 10px;">
      <img src="https://github.com/user-attachments/assets/997f7d4f-c9eb-409a-8e3f-6171c42e28d7" alt="Swagger UI" width="870">
    </td>
  </tr>
</table>

<h3>References 📚</h3>
<a href="https://medium.com/net-core/using-refit-in-net-0843bb199987">Using Refit in .NET</a><br/>
<a href="https://www.milanjovanovic.tech/blog/refit-in-dotnet-building-robust-api-clients-in-csharp">Refit in .NET: Building Robust API Clients in C#</a><br/>
<a href="https://macoratti.net/22/06/aspn_refit1.htm">ASP. NET Core Web API -  Usando Refit</a><br/>
<a href="https://github.com/reactiveui/refit">Refit: The automatic type-safe REST library for .NET Core, Xamarin and .NET</a><br/>
