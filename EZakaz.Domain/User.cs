using System;
using System.Collections.Generic;
using System.Text;
using Iesi.Collections.Generic;

namespace EZakaz.Domain
{
    public class User: DomainObject<int>
    {
        private string login;
        private byte[] passwordHash;
        private string name;
        private string email;
        private string address;
        private string phone;
        private string contactName;
        private bool isActive = false;
        private PriceType priceType;
        private Role role;
        private ISet<Order> orders = new HashedSet<Order>();
    	private bool isNew = true;
        private int accessId;

    	public User() {}

    	public User(string login, byte[] passwordHash, string name, string email, string address,
            string phone, string contactName, Role role, bool isActive, PriceType priceType, bool isNew, int accessId)
        {
            this.login = login;
            this.passwordHash = passwordHash;
            this.name = name;
            this.email = email;
            this.address = address;
            this.phone = phone;
            this.contactName = contactName;
            this.role = role;
    		this.isActive = isActive;
    	    this.priceType = priceType;
    	    this.isNew = isNew;
    	    this.accessId = accessId;
        }

    	public virtual int AccessId
        {
            get { return accessId; }
            set { accessId = value; }
        }

		public virtual bool IsNew
    	{
    		get { return isNew; }
    		set { isNew = value; }
    	}

    	public virtual PriceType PriceType
        {
            get { return priceType; }
            set { priceType = value; }
        }

        public virtual ISet<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public virtual Role Role
        {
            get { return role; }
            set { role = value; }
        }

        public virtual bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public virtual string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        public virtual string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public virtual string Address
        {
            get { return address; }
            set { address = value; }
        }

        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual byte[] PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }

        public virtual string Login
        {
            get { return login; }
            set { login = value; }
        }

        public virtual bool IsAdmin
        {
            get { return role == Domain.Role.Admin; }
        }

        public virtual bool IsStaff
        {
            get { return role == Domain.Role.Staff; }
        }

        public virtual bool IsClient
        {
            get { return role == Domain.Role.Client; }
        }

        public virtual bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (User)) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
