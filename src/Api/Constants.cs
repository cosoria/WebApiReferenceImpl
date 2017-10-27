namespace WebApiReferenceImpl
{
    public class Constants
    {
        public class Routing
        {
            public const string ApiRootEndPoint = "api";
            public const string ApiEndPointCurrentVersion = ApiRootEndPoint + "/v1";
            
            public class Pets
            {
                public const string ApiEndPoint = ApiEndPointCurrentVersion + "/pets";
            }

            public class Owners
            {
                public const string ApiEndPoint = ApiEndPointCurrentVersion + "/owners";
            }

            public class Clinics
            {
                public const string ApiEndPoint = ApiEndPointCurrentVersion + "/clinics";
            }
        }
    }
}