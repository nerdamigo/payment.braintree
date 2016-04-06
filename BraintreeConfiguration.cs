using NerdAmigo.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT = Braintree;

namespace NerdAmigo.Payment.Braintree
{
    public class BraintreeConfiguration : ICloneable
    {
        public string MerchantID { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string EnvironmentID { get; set; }

        public BT.Environment GetEnvironment()
        {
            if (String.IsNullOrEmpty(this.EnvironmentID))
            {
                throw new Exception("Missing EnvironmentName in BraintreeConfiguration");
            }

            switch (this.EnvironmentID.ToUpper())
            {
                case "DEVELOPMENT":
                    return BT.Environment.DEVELOPMENT;
                case "SANDBOX":
                    return BT.Environment.SANDBOX;
                case "QA":
                    return BT.Environment.QA;
                case "PRODUCTION":
                    return BT.Environment.PRODUCTION;
                default:
                    throw new Exception("Invalid EnvironmentName declared in BraintreeConfiguration");
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as BraintreeConfiguration;
            if (other == null)
            {
                return false;
            }

            return this.MerchantID == other.MerchantID &&
                this.PublicKey == other.PublicKey &&
                this.PrivateKey == other.PrivateKey &&
                this.EnvironmentID == other.EnvironmentID;
        }

        public override int GetHashCode()
        {
            return this.MerchantID.GetHashCode() ^
                this.PublicKey.GetHashCode() ^
                this.PrivateKey.GetHashCode() ^
                this.EnvironmentID.GetHashCode();
        }

        public object Clone()
        {
            return new BraintreeConfiguration
            {
                MerchantID = this.MerchantID,
                PublicKey = this.PublicKey,
                PrivateKey = this.PrivateKey,
                EnvironmentID = this.EnvironmentID
            };
        }
    }
}
