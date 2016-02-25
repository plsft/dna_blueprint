using System;

namespace Blue.Data.CustomModels
{
    public sealed class CustomerInvoicePartModel : ICustomModel
    {
        public int ID { get; set; }
        public string Firstname { get; set;  }
        public string Lastname { get; set;  }
        public string Phone { get; set;  }
        public string Email { get; set;  }
        public string Part { get; set;  }
        public DateTime Created { get; set;  }
    }
}
