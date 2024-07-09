using System.Reflection;

namespace EventCase.Domain
{

    public static class EventCasePermissions
    {
        public const string GroupName = "EventCase";

        public const string CreateConst = ".Create";
        public const string UpdateConst = ".Update";
        public const string DeleteConst = ".Delete";
        public const string ReadConst = ".Read";

        public static class Employee
        {
            public const string Default = $"{GroupName}.{nameof(Employee)}";
            public const string Read = $"{Default}{ReadConst}";
            public const string Create = $"{Default}{CreateConst}";
            public const string Update = $"{Default}{UpdateConst}";
            public const string Delete = $"{Default}{DeleteConst}";
        }

        public static List<string> GetPermissions()
        {
            var list = new List<string>();
            var permissionType = typeof(EventCasePermissions);
            var nestedTypes = permissionType.GetNestedTypes();
            foreach (var nestedType in nestedTypes)
            {
                //object nestedInstance = Activator.Cre(nestedType);
                FieldInfo[] properties = nestedType.GetFields();

                foreach (var property in properties)
                {
                    object value = property.GetValue(nestedType);
                    list.Add(value.ToString());
                }
            }



            return list;
        }
    }
}
