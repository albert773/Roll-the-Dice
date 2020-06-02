using System;

namespace RolltheDiceService.IoC
{
    public class InjectableAttribute
    {
        public class InjectableAttributeTransient : Attribute
        {

        }

        public class InjectableAttributeScoped : Attribute
        {

        }

        public class InjectableAttributeSingleton : Attribute
        {

        }
    }
}