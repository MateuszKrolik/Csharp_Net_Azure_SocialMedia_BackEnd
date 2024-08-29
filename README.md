<a name="readme-top"></a>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd">
    <img src="images/logo.svg" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">Csharp_Net_Azure_PlacesSocialMedia_BackEnd</h3>

  <p align="center">
    <br />
    <a href="https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd">View Demo</a>
    ·
    <a href="https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd/issues/new?assignees=&labels=bug&projects=&template=bug-report.md" >Report Bug</a>
    ·
    <a href="https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd/issues/new?assignees=&labels=enhancement&projects=&template=feature-request.md">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#roadmap--usage">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->

To test out the REST API yourself, you can use the following 😉
link: [Project Link](https://mkrolik-places.ashycoast-2fd8c4d9.germanywestcentral.azurecontainerapps.io/swagger/index.html)

https://github.com/user-attachments/assets/570cf329-3ceb-4fc7-8cfc-d871d94c319b

https://github.com/user-attachments/assets/44000d0b-3b91-4d9e-a039-a8c7543e90c4

## DataBase ERD Diagram

![alt text](images/chart.svg)

[Swagger Schema Link (for future FrontEnd Client integration)](https://mkrolik-places.ashycoast-2fd8c4d9.germanywestcentral.azurecontainerapps.io/swagger/v1/swagger.json)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

<!-- Programming Languages -->

- [![C#][Csharp.com]][Csharp-url]
<!-- Web Technologies -->
- [![ASP.NET][ASPNET.com]][ASPNET-url]
- [![Entity Framework][EntityFramework.com]][EntityFramework-url]
- [![AutoMapper][AutoMapper.com]][AutoMapper-url]
<!-- Cloud Deployment Services -->
- [![Azure][Azure.com]][Azure-url]
- [![Azure Container Apps][AzureContainerApps.com]][AzureContainerApps-url]
- [![Azure Resource Manager][AzureResourceManager.com]][AzureResourceManager-url]
- [![Azure Blob Storage][AzureBlobStorage.com]][AzureBlobStorage-url]
<!-- DataBases -->
- [![Microsoft SQL Server][MicrosoftSQLServer.com]][MicrosoftSQLServer-url]
- [![Azure SQL Database][AzureSQLDatabase.com]][AzureSQLDatabase-url]
<!-- External APIs -->
- [![SendGrid][SendGrid.com]][SendGrid-url]
- [![Google Maps][GoogleMaps.com]][GoogleMaps-url]
<!-- DevTools -->
- [![Bash][Bash.com]][Bash-url]
- [![Docker][Docker.com]][Docker-url]
- [![Linux][Linux.com]][Linux-url]
- [![Swagger][Swagger.com]][Swagger-url]
- [![.ENV][Dotenv.com]][Dotenv-url]
<!-- DataFormats -->
- [![JSON][JSON.com]][JSON-url]
- [![YAML][YAML.com]][YAML-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

When setting up the project locally, I suggest adding your own custom environment variables via ".env" and "parameters.json" files,
also run chmod +x to make BASH Scripts Executable.

### Prerequisites

You should have .NET SDK, DockerDesktop, MsSQLExpress and Azure CLI (Requires Python) installed.

I also suggest setting up Azure Data Studio (for ARM/64 users) for smooth DataBase Management.

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd.git
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ROADMAP & USAGE -->

## Roadmap & Usage

- [x] BackEnd REST API development via:
  - [x] C#
  - [x] ASP.NET Core
  - [x] Entity Framework
  - [x] Identity
  - [x] MsSqlServer
- [x] Security from SQL-Injection with Entity Framework
- [x] 1:N Relationship between Users & Places via Entity Framework & Identity
- [x] HATEOAS (Hypermedia as the Engine of Application State ) via REST API Location Headers
- [x] Data transfer with AutoMapper Library
- [x] Loose-Coupling and Abstraction of Services with Interfaces in Repository OOP Design Pattern
- [x] Constructor Dependency Injection for:
  - [x] Azure Blob Storage Image Upload
  - [x] Google’s GeoLocation API
- [x] SMTP Mailing provider for:
  - [x] “Confirm Password” functionality
  - [x] “Reset Password” functionality
- [x] Bearer Token User Authentication & Authorization for API route protection
- [x] Google's GeoLocation API Address Conversion
- [x] User Passwords hashing in MsSQL T-SQL DataBase with .NET Identity Framework
- [x] T-SQL MsSQL DataBase Management with Azure Data Studio
- [x] Azure SQL DataBase Service for hosting
- [x] Optimized Docker Image of the REST API with .NET SDK & BASH
- [x] DockerHub storage for Docker Image
- [x] Infrastructure-as-Code (IaC) with Azure Resource Manager (ARM) using JSON Deployment Template
- [x] Secure loading of JSON Parameter EnvironmentVariable Secrets during Azure CLI Deployment with BASH Script
- [x] Deployment of the C# .NET REST API to Azure Container Apps Service from DockerHub Container Registry via IaC
- [x] Cross-Origin Resource Sharing (CORS) for future FrontEnd API access

See the [open documentation](https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd/issues) for a full
list of proposed features (and
known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any
contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also
simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->

## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->

## Contact

Mateusz Królik - mateuszkrolik87@gmail.com

Project
Link: [https://ys7jaqt5djj6zgrv5fktk5b7ky0iotut.lambda-url.eu-central-1.on.aws/docs](https://ys7jaqt5djj6zgrv5fktk5b7ky0iotut.lambda-url.eu-central-1.on.aws/docs)

Project Repository
Link: [https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd](https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd.svg?style=for-the-badge
[contributors-url]: https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd.svg?style=for-the-badge
[forks-url]: https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd/network/members
[stars-shield]: https://img.shields.io/github/stars/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd.svg?style=for-the-badge
[stars-url]: https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd/stargazers
[issues-shield]: https://img.shields.io/github/issues/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd.svg?style=for-the-badge
[issues-url]: https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd/issues
[license-shield]: https://img.shields.io/github/license/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd.svg?style=for-the-badge
[license-url]: https://github.com/MateuszKrolik/Csharp_Net_Azure_SocialMedia_BackEnd/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/mateusz-kr%C3%B3lik-8b1862262/
[product-screenshot]: images/screenshot.png
[Linux.com]: https://img.shields.io/badge/Linux-FCC624?style=for-the-badge&logo=linux&logoColor=black
[Linux-url]: https://www.linux.org/
[Docker.com]: https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white
[Docker-url]: https://www.docker.com/
[Swagger.com]: https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black
[Swagger-url]: https://swagger.io/
[Dotenv.com]: https://img.shields.io/badge/.ENV-ECD53F?style=for-the-badge&logo=dotenv&logoColor=black
[Dotenv-url]: https://github.com/theskumar/python-dotenv
[JSON.com]: https://img.shields.io/badge/JSON-000000?style=for-the-badge&logo=json&logoColor=white
[JSON-url]: https://www.json.org/
[YAML.com]: https://img.shields.io/badge/YAML-000000?style=for-the-badge&logo=yaml&logoColor=white
[YAML-url]: https://yaml.org/
[Bash.com]: https://img.shields.io/badge/Bash-4EAA25?style=for-the-badge&logo=gnu-bash&logoColor=white
[Bash-url]: https://www.gnu.org/software/bash/
[Csharp.com]: https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white
[Csharp-url]: https://docs.microsoft.com/en-us/dotnet/csharp/
[ASPNET.com]: https://img.shields.io/badge/ASP.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[ASPNET-url]: https://dotnet.microsoft.com/apps/aspnet
[EntityFramework.com]: https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[EntityFramework-url]: https://docs.microsoft.com/en-us/ef/
[Azure.com]: https://img.shields.io/badge/Azure-0089D6?style=for-the-badge&logo=microsoft-azure&logoColor=white
[Azure-url]: https://azure.microsoft.com/
[AzureSQLDatabase.com]: https://img.shields.io/badge/Azure_SQL_Database-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white
[AzureSQLDatabase-url]: https://azure.microsoft.com/products/azure-sql/database/
[AzureBlobStorage.com]: https://img.shields.io/badge/Azure_Blob_Storage-0089D6?style=for-the-badge&logo=microsoft-azure&logoColor=white
[AzureBlobStorage-url]: https://azure.microsoft.com/services/storage/blobs/
[AutoMapper.com]: https://img.shields.io/badge/AutoMapper-BE161D?style=for-the-badge
[AutoMapper-url]: https://automapper.org/
[AzureContainerApps.com]: https://img.shields.io/badge/Azure_Container_Apps-38A169?style=for-the-badge
[AzureContainerApps-url]: https://azure.microsoft.com/services/container-apps/
[MicrosoftSQLServer.com]: https://img.shields.io/badge/Microsoft_SQL_Server-4A154B?style=for-the-badge
[MicrosoftSQLServer-url]: https://www.microsoft.com/en-us/sql-server
[GoogleMaps.com]: https://img.shields.io/badge/Google_Maps-ED8936?style=for-the-badge
[GoogleMaps-url]: https://developers.google.com/maps
[SendGrid.com]: https://img.shields.io/badge/SendGrid-9F7AEA?style=for-the-badge
[SendGrid-url]: https://sendgrid.com/
[AzureResourceManager.com]: https://img.shields.io/badge/Azure_Resource_Manager-48BB78?style=for-the-badge
[AzureResourceManager-url]: https://docs.microsoft.com/en-us/azure/azure-resource-manager/
