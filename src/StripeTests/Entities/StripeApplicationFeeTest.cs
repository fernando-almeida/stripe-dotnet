namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class StripeApplicationFeeTest : BaseStripeTest
    {
        [Fact]
        public void Deserialize()
        {
            string json = GetFixture("/v1/application_fees/fee_123");
            var applicationFee = Mapper<StripeApplicationFee>.MapFromJson(json);
            Assert.NotNull(applicationFee);
            Assert.IsType<StripeApplicationFee>(applicationFee);
            Assert.NotNull(applicationFee.Id);
            Assert.Equal("application_fee", applicationFee.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "account",
              "application",
              "balance_transaction",
              "charge",
              "originating_transaction",
            };

            string json = GetFixture("/v1/application_fees/fee_123", expansions);
            var applicationFee = Mapper<StripeApplicationFee>.MapFromJson(json);
            Assert.NotNull(applicationFee);
            Assert.IsType<StripeApplicationFee>(applicationFee);
            Assert.NotNull(applicationFee.Id);
            Assert.Equal("application_fee", applicationFee.Object);

            Assert.NotNull(applicationFee.Account);
            Assert.Equal("account", applicationFee.Account.Object);

            Assert.NotNull(applicationFee.Application);
            Assert.Equal("application", applicationFee.Application.Object);

            Assert.NotNull(applicationFee.BalanceTransaction);
            Assert.Equal("balance_transaction", applicationFee.BalanceTransaction.Object);

            Assert.NotNull(applicationFee.Charge);
            Assert.Equal("charge", applicationFee.Charge.Object);

            Assert.NotNull(applicationFee.OriginatingTransaction);
            Assert.Equal("charge", applicationFee.OriginatingTransaction.Object);
        }
    }
}
