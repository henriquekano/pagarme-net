using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PagarMe.Model;
using PagarMe.Enumeration;

namespace PagarMe.Tests
{
    [TestFixture]
    class PostbackTest
    {

		[Test]
		public void ValidatePostbackTest()
		{
			var rawBody = "id=1661141&fingerprint=063f0552a369001b944ca4fefc02e54ea3f5d20c&event=transaction_status_changed&old_status=processing&desired_status=paid&current_status=paid&object=transaction&transaction%5Bobject%5D=transaction&transaction%5Bstatus%5D=paid&transaction%5Brefuse_reason%5D=&transaction%5Bstatus_reason%5D=acquirer&transaction%5Bacquirer_response_code%5D=0000&transaction%5Bacquirer_name%5D=pagarme&transaction%5Bacquirer_id%5D=56d0a16d10c1234e30555b77&transaction%5Bauthorization_code%5D=231338&transaction%5Bsoft_descriptor%5D=&transaction%5Btid%5D=1661141&transaction%5Bnsu%5D=1661141&transaction%5Bdate_created%5D=2017-06-27T22%3A53%3A00.717Z&transaction%5Bdate_updated%5D=2017-06-27T22%3A53%3A01.184Z&transaction%5Bamount%5D=1000&transaction%5Bauthorized_amount%5D=1000&transaction%5Bpaid_amount%5D=1000&transaction%5Brefunded_amount%5D=0&transaction%5Binstallments%5D=1&transaction%5Bid%5D=1661141&transaction%5Bcost%5D=50&transaction%5Bcard_holder_name%5D=sa44444444444444444444444467444445555555488444dasd&transaction%5Bcard_last_digits%5D=2537&transaction%5Bcard_first_digits%5D=491676&transaction%5Bcard_brand%5D=visa&transaction%5Bcard_pin_mode%5D=&transaction%5Bpostback_url%5D=https%3A%2F%2Frequestb.in%2F12dkl9n1&transaction%5Bpayment_method%5D=credit_card&transaction%5Bcapture_method%5D=ecommerce&transaction%5Bantifraud_score%5D=&transaction%5Bboleto_url%5D=&transaction%5Bboleto_barcode%5D=&transaction%5Bboleto_expiration_date%5D=&transaction%5Breferer%5D=api_key&transaction%5Bip%5D=179.191.82.50&transaction%5Bsubscription_id%5D=&transaction%5Bphone%5D%5Bobject%5D=phone&transaction%5Bphone%5D%5Bddi%5D=55&transaction%5Bphone%5D%5Bddd%5D=11&transaction%5Bphone%5D%5Bnumber%5D=87654321&transaction%5Bphone%5D%5Bid%5D=124549&transaction%5Baddress%5D%5Bobject%5D=address&transaction%5Baddress%5D%5Bstreet%5D=Avenida%20Atl%C3%A2ntica&transaction%5Baddress%5D%5Bcomplementary%5D=ZApto.%201701&transaction%5Baddress%5D%5Bstreet_number%5D=4330&transaction%5Baddress%5D%5Bneighborhood%5D=Centro&transaction%5Baddress%5D%5Bcity%5D=&transaction%5Baddress%5D%5Bstate%5D=&transaction%5Baddress%5D%5Bzipcode%5D=88330027&transaction%5Baddress%5D%5Bcountry%5D=&transaction%5Baddress%5D%5Bid%5D=127515&transaction%5Bcustomer%5D%5Bobject%5D=customer&transaction%5Bcustomer%5D%5Bid%5D=203997&transaction%5Bcustomer%5D%5Bexternal_id%5D=&transaction%5Bcustomer%5D%5Btype%5D=&transaction%5Bcustomer%5D%5Bcountry%5D=&transaction%5Bcustomer%5D%5Bdocument_number%5D=35965816804&transaction%5Bcustomer%5D%5Bdocument_type%5D=cpf&transaction%5Bcustomer%5D%5Bname%5D=Henrique%20Foletto&transaction%5Bcustomer%5D%5Bemail%5D=dwrgve%40wefb.com&transaction%5Bcustomer%5D%5Bphones%5D=&transaction%5Bcustomer%5D%5Bborn_at%5D=&transaction%5Bcustomer%5D%5Bbirthday%5D=&transaction%5Bcustomer%5D%5Bgender%5D=&transaction%5Bcustomer%5D%5Bdate_created%5D=2017-06-27T22%3A53%3A00.651Z&transaction%5Bbilling%5D=&transaction%5Bshipping%5D=&transaction%5Bcard%5D%5Bobject%5D=card&transaction%5Bcard%5D%5Bid%5D=card_cj4g6480z003ghe6e32x074fh&transaction%5Bcard%5D%5Bdate_created%5D=2017-06-27T22%3A53%3A00.709Z&transaction%5Bcard%5D%5Bdate_updated%5D=2017-06-27T22%3A53%3A00.709Z&transaction%5Bcard%5D%5Bbrand%5D=visa&transaction%5Bcard%5D%5Bholder_name%5D=sa44444444444444444444444467444445555555488444dasd&transaction%5Bcard%5D%5Bfirst_digits%5D=491676&transaction%5Bcard%5D%5Blast_digits%5D=2537&transaction%5Bcard%5D%5Bcountry%5D=BR&transaction%5Bcard%5D%5Bfingerprint%5D=DLX%2F32QbaNYt&transaction%5Bcard%5D%5Bvalid%5D=&transaction%5Bcard%5D%5Bexpiration_date%5D=0119&transaction%5Bsplit_rules%5D=&transaction%5Bmetadata%5D%5BidProduto%5D=teste"; 
			var signature = "sha1=6d82b90fa507fb754bdfae90a9fb3057cefc61ac";
			var pagarmeService = new PagarMeService("ak_test_Q2D2qDYGJSyeR1KbI4sLzGACEr73MF", "ek_test_ZsiQ61rmOmB8mh055slzu1nxfVbAFa");
			Assert.IsTrue(pagarmeService.ValidatePostback(signature, rawBody));
		}

        [Test]
        public void FindAllPostbacksTest()
        {
            var transaction = PagarMeTestFixture.CreateTestBoletoTransactionWithPostbackUrl();
            transaction.Save();
            transaction.Status = TransactionStatus.Paid;
            transaction.Save();

            var postbacks = transaction.Postbacks.FindAll(new Postback());

            foreach (var postback in postbacks)
            {
                Assert.IsTrue(postback.ModelId.Equals(transaction.Id));
            }
        }

        [Test]
        public void FindPostbackTest()
        {
            var transaction = PagarMeTestFixture.CreateTestBoletoTransactionWithPostbackUrl();
            transaction.Save();
            transaction.Status = TransactionStatus.Paid;
            transaction.Save();

            Postback postback = transaction.Postbacks.FindAll(new Postback()).First();
            Postback postbackReturned = transaction.Postbacks.Find(postback.Id);

            Assert.IsTrue(postback.Id.Equals(postbackReturned.Id));
            Assert.IsTrue(postback.Status.Equals(postbackReturned.Status));
            Assert.IsTrue(postback.ModelId.Equals(postbackReturned.ModelId));
        }

        [Test]
        public void RedeliverPostbackTest()
        {
            var transaction = PagarMeTestFixture.CreateTestBoletoTransactionWithPostbackUrl();
            transaction.Save();
            transaction.Status = TransactionStatus.Paid;
            transaction.Save();

            Postback postback = transaction.Postbacks.FindAll(new Postback()).First();
            postback.Redeliver();

            Assert.IsTrue(postback.Status == PostbackStatus.PendingRetry);
        }
    }
}
