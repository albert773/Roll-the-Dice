using System;

namespace Roll_the_Dice_Service.IoC
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