namespace FooLibrary
{

    using System;

    public class ClassFoo
    {

        private readonly DateTime _dateStamp;

        public ClassFoo()
        {
            this._dateStamp = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return this._dateStamp.ToString("dd/MM/yyyy HH:mm:ss");
        }

    }

}