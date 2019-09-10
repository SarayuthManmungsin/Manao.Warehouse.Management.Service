using MongoDB.Bson;
using System;

namespace Manao.Warehouse.Management.Domain
{
    public abstract class DomainBase : IDomainBase
    {
        #region Fields

        private ObjectId __id;
        public virtual bool IsActive { get; set; }

        public virtual string Details { get; set; }

        #endregion

        #region Construcotrs

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected DomainBase()
        {

        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="key">An <see cref="System.Object"/> that 
        /// represents the primary identifier value for the 
        /// class.</param>
        protected DomainBase(Guid key)
        {
            this.__id = new ObjectId(key.ToString());
            if (this.__id == null)
            {
                this.__id = new ObjectId();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// An <see cref="System.Object"/> that represents the 
        /// primary identifier value for the class.
        /// </summary>
        public virtual ObjectId _id
        {
            get
            {
                if (this.__id == ObjectId.Empty)
                    this.__id = GenerateNewId();

                return this.__id;
            }
            protected set
            {
                this.__id = value;
            }
        }

        #endregion

        #region New

        public static ObjectId GenerateNewId()
        {
            return ObjectId.GenerateNewId();
        }

        #endregion

        #region Equality Tests

        /// <summary>
        /// Determines whether the specified domain is equal to the 
        /// current instance.
        /// </summary>
        /// <param name="domainBase">An <see cref="System.Object"/> that 
        /// will be compared to the current instance.</param>
        /// <returns>True if the passed in domain is equal to the 
        /// current instance.</returns>
        public override bool Equals(object domainBase)
        {
            return domainBase != null
                && domainBase is DomainBase
                && this == (DomainBase)domainBase;
        }

        /// <summary>
        /// Operator overload for determining equality.
        /// </summary>
        /// <param name="base1">The first instance of an 
        /// <see cref="DomainBase"/>.</param>
        /// <param name="base2">The second instance of an 
        /// <see cref="DomainBase"/>.</param>
        /// <returns>True if equal.</returns>
        public static bool operator ==(DomainBase base1, DomainBase base2)
        {
            // check for both null (cast to object or recursive loop)
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }

            // check for either of them == to null
            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }

            if (base1._id == ObjectId.Empty && base2._id == ObjectId.Empty)
            {
                return false;
            }

            if (!base1._id.Equals(base2._id))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Operator overload for determining inequality.
        /// </summary>
        /// <param name="base1">The first instance of an 
        /// <see cref="DomainBase"/>.</param>
        /// <param name="base2">The second instance of an 
        /// <see cref="DomainBase"/>.</param>
        /// <returns>True if not equal.</returns>
        public static bool operator !=(DomainBase base1, DomainBase base2)
        {
            return (!(base1 == base2));
        }

        /// <summary>
        /// Serves as a hash function for this type.
        /// </summary>
        /// <returns>A hash code for the current Key 
        /// property.</returns>
        public override int GetHashCode()
        {
            if (this.__id != null)
            {
                return this.__id.GetHashCode();
            }
            else
            {
                return 0;
            }
        }

        #endregion
    }
}