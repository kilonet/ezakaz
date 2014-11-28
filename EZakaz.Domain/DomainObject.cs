
namespace EZakaz.Domain
{
    /// <summary>
    /// For a discussion of this object, see 
    /// http://devlicio.us/blogs/billy_mccafferty/archive/2007/04/25/using-equals-gethashcode-effectively.aspx
    /// </summary>
    public abstract class DomainObject<IdT>
    {
        /// <summary>
        /// ID may be of type string, int, custom type, etc.
        /// Setter is protected to allow unit tests to set this property via reflection and to allow 
        /// domain objects more flexibility in setting this for those objects with assigned IDs.
        /// </summary>
        public virtual IdT Id
        {
            get { return id; }
            protected set { id = value; }
        }

        public new virtual bool Equals(object obj)
        {
            DomainObject<IdT> compareTo = obj as DomainObject<IdT>;

            return (compareTo != null) &&
                   (HasSameNonDefaultIdAs(compareTo) ||
                    // Since the IDs aren't the same, either of them must be transient to 
                    // compare business value signatures
                    (((IsTransient()) || compareTo.IsTransient()) &&
                     HasSameBusinessSignatureAs(compareTo)));
        }

        /// <summary>
        /// Transient objects are not associated with an item already in storage.  For instance,
        /// a <see cref="Customer" /> is transient if its ID is 0.
        /// </summary>
        public virtual bool IsTransient()
        {
            return Id == null || Id.Equals(default(IdT));
        }

        /// <summary>
        /// Must be provided to properly compare two objects
        /// </summary>
        //public abstract override int GetHashCode();

        private bool HasSameBusinessSignatureAs(DomainObject<IdT> compareTo)
        {
            return GetHashCode().Equals(compareTo.GetHashCode());
        }

        /// <summary>
        /// Returns true if self and the provided persistent object have the same ID values 
        /// and the IDs are not of the default ID value
        /// </summary>
        private bool HasSameNonDefaultIdAs(DomainObject<IdT> compareTo)
        {
            return (Id != null && !Id.Equals(default(IdT))) &&
                   (compareTo.Id != null && !compareTo.Id.Equals(default(IdT))) &&
                   Id.Equals(compareTo.Id);
        }

        private IdT id = default(IdT);
    }
}