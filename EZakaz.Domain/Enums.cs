using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain
{
    public enum Role
    {
        Admin = 0,
        Staff = 1,
        Client = 2
    }

	public enum OrderState
	{
		Draft,
		Sent
	}

    public enum PriceType
    {
        Price1 = 1,
        Price2 = 2,
        Price3 = 3
    }
}
