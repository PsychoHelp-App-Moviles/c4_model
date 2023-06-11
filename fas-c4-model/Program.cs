using Structurizr;
using Structurizr.Api;

namespace fas_c4_model
{
    class Program
    {
        static void Main(string[] args)
        {
            CODETECH();
        }

        static void CODETECH()
        {

            const long workspaceId = 82354;
            const string apiKey = "6c2d95cb-4bb3-463c-8a9f-7318f3713476";
            const string apiSecret = "203ee4b0-2460-43eb-ad62-4dddb4a0a27d";

            StructurizrClient structurizrClient = new StructurizrClient(apiKey, apiSecret);
            Workspace workspace = new Workspace("TechnoGym, inc.", "Sistema de entrenamiento personalizado");
            Model model = workspace.Model;
            ViewSet viewSet = workspace.Views;

            // 1. Diagrama de Contexto
            SoftwareSystem technogymSystem = model.AddSoftwareSystem("TechnoGym, inc. Platform", "Permite a los usuarios visualizar información.");
            SoftwareSystem googleCloud = model.AddSoftwareSystem("Serverless Computing", "Servicios de Google Cloud Run");
            SoftwareSystem stripe = model.AddSoftwareSystem("Stripe", "Servicio para el pago de suscripciones");
            Person customer = model.AddPerson("Customer", "Usuario que usa la plataforma para acceder a los servicios de entrenamiento");
            Person developer = model.AddPerson("Developer", "Usuario que usa mywellness para crear aplicaciones para los equipos con ejercicio con display");


            customer.Uses(technogymSystem, "Usa la plataforma");
            developer.Uses(technogymSystem, "Usa la plataforma");
            technogymSystem.Uses(googleCloud, "Permite acceder a los servicios necesarios para el app");
            technogymSystem.Uses(stripe, "Permite el pago de suscripciones en la plataforma");


            SystemContextView contextView = viewSet.CreateSystemContextView(technogymSystem, "Contexto", "Diagrama de contexto");
            contextView.PaperSize = PaperSize.A4_Landscape;
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            // Tags
            technogymSystem.AddTags("SoftwareSystem");
            googleCloud.AddTags("Serverless Computing");
            customer.AddTags("Customer");
            developer.AddTags("Developer");
            stripe.AddTags("Stripe");

            Styles styles = viewSet.Configuration.Styles;
            styles.Add(new ElementStyle("Customer") { Background = "#5ec4dd", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("Developer") { Background = "#5ec4dd", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("SoftwareSystem") { Background = "#5CC768", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Serverless Computing") { Background = "#1E5685", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Stripe") { Background = "#1E5685", Color = "#ffffff", Shape = Shape.RoundedBox });

            // 2. Diagrama de Contenedores
            Container webApplication = technogymSystem.AddContainer("Web Application", "Página Web de Technogym", "TypeScript y Angular Material");
            Container mobileApplication = technogymSystem.AddContainer("Mobile Application", "Aplicación Móvil de Technogym", "Kotlin en Android y Swift en iOS");
            Container apiGateway = technogymSystem.AddContainer("API Gateway", "API Gateway", "Serverless functions");
            
            Container sharedContext = technogymSystem.AddContainer("Shared Context", "Shared Kernel con elementos base o compartidos con otros bounded contexts.", "Spring Boot");
            Container identityaccessmanagementContext = technogymSystem.AddContainer("Identity & Access Management Context", "User Registry, Single-Sign-On para toda la plataforma, Authentication and Authorization Management", "Spring Boot");
            Container ecommercestoremanagementContext = technogymSystem.AddContainer("Ecommerce & Store Management Context", "Gestión de venta de productos online, en puntos de venta y venta de suscripciones, incluyendo integración con pasarela de pagos, control de deudas y vencimientos", "Spring Boot");
            Container inventorysupplychainContext = technogymSystem.AddContainer("Inventory & Supply Chain Context", "Catálogo de productos y servicios, manejo de inventarios, adquisiciones de productos y servicios.", "Spring Boot");
            Container accountsuserprofilesContext = technogymSystem.AddContainer("Accounts & User Profiles Context", "Información de accounts, perfiles y preferencias para usuarios individuales y perfiles para clientes business y fitness clubs", "Spring Boot");
            Container trainingservicesContext = technogymSystem.AddContainer("Training Services Context", "Diseño, ejecución y seguimiento de planes de entrenamiento considerando por ejemplo objetivos cardiovasculares, peso, máquinas de technogym a utilizar, pesas, actividades, repeticiones y otros relacionados con training, accesibles por el usuario vía Technogym App o Mywellness", "Spring Boot");
            Container businesssectorservicesContext = technogymSystem.AddContainer("Business Sector Services Context", "Los incluidos en Premium services for smart facilities, donde varios se integran con otros bounded contexts", "Spring Boot");
            Container contentstreamingmanagementservicesContext = technogymSystem.AddContainer("Content & Streaming Management Services Context", "Manejo del contenido de videos de entrenamiento, capacitación, assets de imagen, soporte de streaming para integrar en los productos de la plataforma", "Spring Boot");
            Container digitalAIcoachingContext = technogymSystem.AddContainer("Digital AI Coaching Context", "Elementos de IA y ML que ofrecen asistencia en sesiones de entrenamiento vía consolas de máquinas o aplicaciones para usuarios en la plataforma", "Spring Boot");
            Container dataanalyticsrecommendationsContext = technogymSystem.AddContainer("Data Analytics & Recommendations Context", "Gestión unificada de registros de actividades en los diversos productos y servicios que sirven de base para los asistentes de IA y la labor de los técnicos de mantenimiento de equipos de entrenamiento", "Spring Boot");
            ;
            Container bus = technogymSystem.AddContainer("Bus de Mensajería", "Transporte de eventos del dominio", "Google Cloud Messaging");

            Container sharedContextDataBase = technogymSystem.AddContainer("Shared Context Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container identityaccessmanagementContextDataBase = technogymSystem.AddContainer("Identity & Access Management Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container ecommercestoremanagementDataBase = technogymSystem.AddContainer("Ecommerce & Store Management Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container inventorysupplychainContextDataBase = technogymSystem.AddContainer("Inventory & Supply Chain Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container accountsuserprofilesContextDataBase = technogymSystem.AddContainer("Accounts & User Profiles Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container trainingservicesContextDataBase = technogymSystem.AddContainer("Training Services Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container businesssectorservicesContextDataBase = technogymSystem.AddContainer("Business Sector Services Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container contentstreamingmanagementservicesContextDataBase = technogymSystem.AddContainer("Content & Streaming Management Services Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container digitalAIcoachingDataBase = technogymSystem.AddContainer("Digital AI Coaching Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");
            Container dataanalyticsrecommendationsDataBase = technogymSystem.AddContainer("Data Analytics & Recommendations Data Base", "Permite el almacenamiento de Informacion", "Google Database Storage");

            customer.Uses(webApplication, "Accede");
            developer.Uses(webApplication, "Accede");
            customer.Uses(mobileApplication, "Accede");
            developer.Uses(mobileApplication, "Accede");

            webApplication.Uses(apiGateway, "API Request", "JSON/HTTPS");
            mobileApplication.Uses(apiGateway, "API Request", "JSON/HTTPS");

            apiGateway.Uses(sharedContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(identityaccessmanagementContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(ecommercestoremanagementContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(inventorysupplychainContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(accountsuserprofilesContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(trainingservicesContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(businesssectorservicesContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(contentstreamingmanagementservicesContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(digitalAIcoachingContext , "API Request", "JSON/HTTPS");
            apiGateway.Uses(dataanalyticsrecommendationsContext, "API Request", "JSON/HTTPS");

            sharedContext.Uses(bus, "Publica y consume eventos del dominio");
            identityaccessmanagementContext.Uses(bus, "Publica y consume eventos del dominio");
            ecommercestoremanagementContext.Uses(bus, "Publica y consume eventos del dominio");
            ecommercestoremanagementContext.Uses(stripe, "Para el pago de suscripciones");
            inventorysupplychainContext.Uses(bus, "Publica y consume eventos del dominio");
            accountsuserprofilesContext.Uses(bus, "Publica y consume eventos del dominio");
            trainingservicesContext.Uses(bus, "Publica y consume eventos del dominio");
            businesssectorservicesContext.Uses(bus, "Publica y consume eventos del dominio");
            contentstreamingmanagementservicesContext.Uses(bus, "Publica y consume eventos del dominio");
            digitalAIcoachingContext.Uses(bus, "Publica y consume eventos del dominio");
            dataanalyticsrecommendationsContext.Uses(bus, "Publica y consume eventos del dominio");

            sharedContext.Uses(sharedContextDataBase,"Lee y escribe");
            identityaccessmanagementContext.Uses(identityaccessmanagementContextDataBase, "Lee y escribe");
            ecommercestoremanagementContext.Uses(ecommercestoremanagementDataBase, "Lee y escribe");
            inventorysupplychainContext.Uses(inventorysupplychainContextDataBase, "Lee y escribe");
            accountsuserprofilesContext.Uses(accountsuserprofilesContextDataBase, "Lee y escribe");
            trainingservicesContext.Uses(trainingservicesContextDataBase, "Lee y escribe");
            businesssectorservicesContext.Uses(businesssectorservicesContextDataBase , "Lee y escribe");
            contentstreamingmanagementservicesContext.Uses(contentstreamingmanagementservicesContextDataBase, "Lee y escribe");
            digitalAIcoachingContext.Uses(digitalAIcoachingDataBase, "Lee y escribe");
            dataanalyticsrecommendationsContext.Uses(dataanalyticsrecommendationsDataBase , "Lee y escribe");




            // Tags
            webApplication.AddTags("WebApp");
            mobileApplication.AddTags("MobileApp");

            apiGateway.AddTags("APIGateway");
            bus.AddTags("Bus");

            sharedContext.AddTags("sharedContext");
            identityaccessmanagementContext.AddTags("identityaccessmanagementContext");
            ecommercestoremanagementContext.AddTags("ecommercestoremanagementContext");
            inventorysupplychainContext.AddTags("inventorysupplychainContext");
            accountsuserprofilesContext.AddTags("accountsuserprofilesContext");
            trainingservicesContext.AddTags("trainingservicesContext");
            businesssectorservicesContext.AddTags("businesssectorservicesContext");
            contentstreamingmanagementservicesContext.AddTags("contentstreamingmanagementservicesContext");
            digitalAIcoachingContext.AddTags("digitalAIcoachingContext");
            dataanalyticsrecommendationsContext.AddTags("dataanalyticsrecommendationsContext");

            sharedContextDataBase.AddTags("sharedContextDataBase");
            identityaccessmanagementContextDataBase.AddTags("identityaccessmanagementContextDataBase");
            ecommercestoremanagementDataBase.AddTags("ecommercestoremanagementDataBase");
            inventorysupplychainContextDataBase.AddTags("inventorysupplychainContextDataBase");
            accountsuserprofilesContextDataBase.AddTags("accountsuserprofilesContextDataBase");
            trainingservicesContextDataBase.AddTags("trainingservicesContextDataBase");
            businesssectorservicesContextDataBase.AddTags("businesssectorservicesContextDataBase");
            contentstreamingmanagementservicesContextDataBase.AddTags("contentstreamingmanagementservicesContextDataBase");
            digitalAIcoachingDataBase.AddTags("digitalAIcoachingDataBase");
            dataanalyticsrecommendationsDataBase.AddTags("dataanalyticsrecommendationsDataBase");

            styles.Add(new ElementStyle("WebApp") { Background = "#A24108", Color = "#ffffff", Shape = Shape.WebBrowser, Icon = "" });
            styles.Add(new ElementStyle("MobileApp") { Background = "#A24108", Color = "#ffffff", Shape = Shape.MobileDevicePortrait, Icon = "" });
            styles.Add(new ElementStyle("APIGateway") { Shape = Shape.RoundedBox, Background = "#0000ff", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("Bus") { Width = 850, Background = "#fd8208", Color = "#ffffff", Shape = Shape.Pipe, Icon = "" });

            styles.Add(new ElementStyle("sharedContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff" , Icon = "" });
            styles.Add(new ElementStyle("identityaccessmanagementContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("ecommercestoremanagementContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("inventorysupplychainContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("accountsuserprofilesContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("trainingservicesContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("businesssectorservicesContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("contentstreamingmanagementservicesContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("digitalAIcoachingContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("dataanalyticsrecommendationsContext") { Shape = Shape.Hexagon, Background = "#B580AB", Color = "#ffffff", Icon = "" });

            styles.Add(new ElementStyle("sharedContextDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("identityaccessmanagementContextDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("ecommercestoremanagementDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("inventorysupplychainContextDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("accountsuserprofilesContextDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("trainingservicesContextDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("businesssectorservicesContextDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("contentstreamingmanagementservicesContextDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("digitalAIcoachingDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("dataanalyticsrecommendationsDataBase") { Shape = Shape.Cylinder, Background = "#A73AB7", Color = "#ffffff", Icon = "" });

            ContainerView containerView = viewSet.CreateContainerView(technogymSystem, "Contenedor", "Diagrama de contenedores");
            contextView.PaperSize = PaperSize.A4_Landscape;
            containerView.AddAllElements();

            structurizrClient.UnlockWorkspace(workspaceId);
            structurizrClient.PutWorkspace(workspaceId, workspace);
        }
    }
}