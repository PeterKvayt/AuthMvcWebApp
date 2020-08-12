using System;

namespace Core.Models
{
    [Serializable]
    public sealed class Role
    {
        public Role()
        {
                
        }

        public Role(string name)
        {
            Name = name;
        }

        #region Properties

        public string Name { get; set; }
        //{
        //    get { return Name; }
        //    set
        //    {
        //        if (!string.IsNullOrWhiteSpace(value))
        //        {
        //            Name = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException();
        //        }
        //    }
        //}

    #endregion
}
}
